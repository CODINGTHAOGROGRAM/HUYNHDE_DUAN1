using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.Extensions;
using Aspose.Cells;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Data;
using DAL;
using NPOI.SS.Formula.Functions;
using DTO;

namespace BUS
{
    public class BUS_GiaoDichTraiPhieu
    {
        private static BUS_GiaoDichTraiPhieu instance;

        public static BUS_GiaoDichTraiPhieu Instance
        {
            get { if (instance == null) instance = new BUS_GiaoDichTraiPhieu(); return BUS_GiaoDichTraiPhieu.instance; }

            private set { BUS_GiaoDichTraiPhieu.instance = value; }
        }

        public void Update(DateTime fromd,DateTime tod)
        {
            DTO_GiaoDichTraiPhieu GDTP = new DTO_GiaoDichTraiPhieu();
            char[] charsToTrim = { '1', '.', ' ' };

            string folderName = "DATA_TPDN";

            var chromeOptions = new ChromeOptions();
            var CurrentDirectory = Directory.GetCurrentDirectory();
            var downloadDirectory = $"{CurrentDirectory}" + @"\DATA_TPDN";
            string pathfile = $"{downloadDirectory}" + @"\remember_file.txt";

            if (!Directory.Exists(folderName))
            {
                Directory.CreateDirectory(folderName);
            }

            if (!System.IO.File.Exists(pathfile))
            {
                System.IO.File.Create(pathfile);
            }

            //read file .txt
            var logFile = System.IO.File.ReadAllLines(pathfile);
            var xlsFileExist = new List<string>(logFile);

            chromeOptions.AddUserProfilePreference("download.default_directory", downloadDirectory);
            chromeOptions.AddUserProfilePreference("download.prompt_for_download", false);
            chromeOptions.AddUserProfilePreference("disable-popup-blocking", "true");

            IWebDriver chromeDriver = new ChromeDriver(chromeOptions);
            chromeDriver.Url = "https://www.hnx.vn/vi-vn/thong-tin-cong-bo-ny-hnx.html";
            chromeDriver.Navigate();
            chromeDriver.Manage().Window.Maximize();
            WebClient download = new WebClient();

            Thread.Sleep(2000);

            var from = chromeDriver.FindElement(By.XPath("//*[@id=\"txtTuNgay\"]"));
            from.SendKeys(fromd.ToString("dd/MM/yyyy"));

            var to = chromeDriver.FindElement(By.XPath("//*[@id=\"txtDenNgay\"]"));
            to.SendKeys(tod.ToString("dd/MM/yyyy"));

            var title = chromeDriver.FindElement(By.XPath("//*[@id=\"txtTieuDeTin\"]"));
            title.SendKeys("Kết quả giao dịch Trái phiếu doanh nghiệp ngày");

            Thread.Sleep(1000);
            var button_find = chromeDriver.FindElement(By.XPath("//*[@id=\"btn_searchL\"]"));
            button_find.Click();

            Thread.Sleep(1000);
            var select_show_more = chromeDriver.FindElement(By.XPath("//*[@id=\"divNumberRecordOnPage\"]"));
            select_show_more.Click();

            Thread.Sleep(1000);
            var select = chromeDriver.FindElement(By.XPath("//*[@id=\"divNumberRecordOnPage\"]/option[5]"));
            select.Click();

            int startPage = 1;
            while (true)
            {
                try
                {
                    int stt = 1;
                    while (true)
                    {
                        bool check_filename = false;

                        Thread.Sleep(1000);
                        chromeDriver.ExecuteJavaScript($"var content = document.querySelector(\"#_tableDatas > tbody > tr:nth-child({stt}) > td.tdLeftAlign > a\").click()");

                        Thread.Sleep(3000);
                        var file_text = chromeDriver.FindElement(By.XPath("//*[@id=\"divViewDetailArticles\"]/div[2]/div[3]/p/a")).Text.ToUpper().Trim(charsToTrim);
                        var file_link = chromeDriver.FindElement(By.XPath("//*[@id=\"divViewDetailArticles\"]/div[2]/div[3]/p/a")).GetAttribute("href");

                        //check filename
                        for (int j = 0; j < xlsFileExist.Count; j++)
                        {
                            if (xlsFileExist[j].CompareTo(file_text) == 0)
                            {
                                check_filename = true;
                                break;
                            }
                        }

                        if (check_filename == false)
                        {
                            //save filename
                            System.IO.File.AppendAllText(pathfile, file_text + Environment.NewLine);
                            chromeDriver.ExecuteJavaScript("var content = document.querySelector(\"#divViewDetailArticles > div.divContentArticlesDetail > div.divLstFileAttach > p > a\").click()");
                            download.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
                            download.DownloadFile(file_link, file_text);
                            Thread.Sleep(1000);

                            FileInfo newestFile = GetNewestFile(new DirectoryInfo(downloadDirectory));
                            DeleteRows(newestFile.ToString().Trim(), 6);
                            EditCells(newestFile.ToString().Trim());
                            DAL_GiaoDichTraiPhieu.Instance.ImportExcelInDB(newestFile.ToString().Trim());
                            System.IO.File.Delete($"{downloadDirectory}" + @"\" + $"{file_text}");
                        }
                        var esc = chromeDriver.FindElement(By.XPath("//*[@id=\"divViewDetailArticles\"]/div[5]/input"));
                        esc.Click();

                    }
                }
                catch (Exception)
                {
                    chromeDriver.Quit();
                }
            }
        }

        public static FileInfo GetNewestFile(DirectoryInfo directory)
        {
            return directory.GetFiles()
                .Union(directory.GetDirectories().Select(d => GetNewestFile(d)))
                .OrderByDescending(f => (f == null ? DateTime.MinValue : f.LastWriteTime))
                .FirstOrDefault();
        }
        private void DeleteRows(string filename, int rows)
        {
            var CurrentDirectory = Directory.GetCurrentDirectory();
            var path = $"{CurrentDirectory}" + @"\DATA_TPDN\" + $"{filename}";
            //Apose.Cell

            Workbook workbook = new Workbook(path);
            Worksheet worksheet = workbook.Worksheets[0];
            //delete rows
            worksheet.Cells.DeleteRows(0, rows);
            workbook.Save(path);
        }

        private void EditCells(string filename)
        {
            var CurrentDirectory = Directory.GetCurrentDirectory();
            var path = $"{CurrentDirectory}" + @"\DATA_TPDN\" + $"{filename}";
            //Apose.Cell

            Workbook workbook = new Workbook(path);
            Worksheet worksheet = workbook.Worksheets[0];

            worksheet.Cells["B1"].PutValue("Ngay_GD");
            worksheet.Cells["C1"].PutValue("Ma_CK");
            worksheet.Cells["D1"].PutValue("Gia_DC");
            worksheet.Cells["E1"].PutValue("TKL_GDKL_LoChan");
            worksheet.Cells["F1"].PutValue("TGT_GDKL_LoChan");
            worksheet.Cells["G1"].PutValue("TKL_GDKL_LoLe");
            worksheet.Cells["H1"].PutValue("TGT_GDKL_LoLe");
            worksheet.Cells["I1"].PutValue("Tong_KLGD_TT_LoChan");
            worksheet.Cells["J1"].PutValue("Tong_GTGD_TT_LoChan");
            worksheet.Cells["K1"].PutValue("Tong_KLGD_TT_LoLe");
            worksheet.Cells["L1"].PutValue("Tong_GTGD_TT_LoLe");

            string[] date = worksheet.Cells[1, 1].Value.ToString().Split('/');
            string new_format = date[2] + "/" + date[1] + "/" + date[0];

            for (int r = 1; r <= worksheet.Cells.Rows.Count - 2; r++)
            {
                worksheet.Cells[r, 1].PutValue(Convert.ToDateTime(new_format).ToShortDateString());
            }

            workbook.Save(path);
        }
        
    }
}
