using Aspose.Cells;
using DAL;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace BUS
{
    public class BUS_HoSoCuPhieu
    {
        DAL_HoSoCoPhieu hoso = new DAL_HoSoCoPhieu();

        private static BUS_HoSoCuPhieu instance;

        public static BUS_HoSoCuPhieu Instance
        {
            get { if (instance == null) instance = new BUS_HoSoCuPhieu(); return BUS_HoSoCuPhieu.instance; }

            private set { BUS_HoSoCuPhieu.instance = value; }
        }
        private BUS_HoSoCuPhieu() { }

        public DataTable LoadGriHoSo()
        {
            return hoso.LoadGriHoSo();
        }

        public DataTable FindListHoSo(string MaCk, string TenTCPH)
        {
            return DAL_HoSoCoPhieu.Instance.FindListHoSo(MaCk, TenTCPH);
        }

       public bool upGradeDataHoSo(string MaCk, string TenTCPH, string TruSoChinh, string DiaChiLienlac, string GPTL, string TenNganh, string NguoiDaiDien, string NguoiCongBo, string BanCaoBach, string TrangThaiKiemSoat, string TrangThaiGiaoDich, DateTime NgayGDDauTien, float VonDieuLe, float KLLH, float KLNY, string Link_BanCaoBach)
       {
            return DAL_HoSoCoPhieu.Instance.upGradeDataHoSo(MaCk, TenTCPH, TruSoChinh, DiaChiLienlac, GPTL, TenNganh, NguoiDaiDien, NguoiCongBo, BanCaoBach, TrangThaiKiemSoat, TrangThaiGiaoDich, NgayGDDauTien, VonDieuLe, KLLH, KLNY, Link_BanCaoBach);
       }
        public void DeleteData(string MaCK)
        {
            DataProvider.Instance.Executequery("Delete_HSCP @Mack",new object[] {MaCK});
        }
        public bool addDataHoSo(string MaCk, string TenTCPH, string TruSoChinh, string DiaChiLienlac, string GPTL, string TenNganh, string NguoiDaiDien, string NguoiCongBo, string BanCaoBach, string TrangThaiKiemSoat, string TrangThaiGiaoDich, DateTime NgayGDDauTien, float VonDieuLe, float KLLH, float KLNY, string Link_BanCaoBach)
        {
            return DAL_HoSoCoPhieu.Instance.addDataHoSo(MaCk, TenTCPH, TruSoChinh, DiaChiLienlac, GPTL, TenNganh, NguoiDaiDien, NguoiCongBo, BanCaoBach, TrangThaiKiemSoat, TrangThaiGiaoDich, NgayGDDauTien, VonDieuLe, KLLH, KLNY, Link_BanCaoBach);
        }
        public void upGradeHoSo()
        {
            ChromeDriver chromeDriver = new ChromeDriver();
            chromeDriver.Manage().Window.Maximize();
            chromeDriver.Navigate().GoToUrl("https://hnx.vn/vi-vn/");
            string queryProc = "HoSoProc_getHoSoByMaCk @MaCk";
            IWebElement ele = chromeDriver.FindElement(By.XPath("//*[@id=\"cssmenu\"]/ul/li[3]/a"));
            Actions action = new Actions(chromeDriver);
            //Performing the mouse hover action on the target element.
            action.MoveToElement(ele).Perform();
            Thread.Sleep(2000);
            IWebElement ele1 = chromeDriver.FindElement(By.XPath("//*[@id=\"cssmenu\"]/ul/li[3]/ul/li[1]/a"));
            action.MoveToElement(ele1).Perform();
            chromeDriver.ExecuteScript("document.querySelector(\"#cssmenu > ul > li:nth-child(3) > ul > li:nth-child(1) > ul > li:nth-child(3) > a\").click()");
            chromeDriver.ExecuteScript("document.querySelector(\"#_tableDatas_wrapper > div > div.DTFC_LeftWrapper > div.DTFC_LeftBodyWrapper > div > table > tbody > tr:nth-child(1) > td.tdCenterAlign.STOCK_CODE > a\").click()");
            DataTable dataTableGridHoSo = new DataTable("HoSoCoPhieu");
            dataTableGridHoSo.Columns.Add("MaCk");
            dataTableGridHoSo.Columns.Add("TenTCPH");
            dataTableGridHoSo.Columns.Add("TruSoChinh");
            dataTableGridHoSo.Columns.Add("DiaChiLienlac");
            dataTableGridHoSo.Columns.Add("GPTL");
            dataTableGridHoSo.Columns.Add("TenNganh");
            dataTableGridHoSo.Columns.Add("NguoiDaiDien");
            dataTableGridHoSo.Columns.Add("NguoiCongBo");
            dataTableGridHoSo.Columns.Add("BanCaoBach");
            dataTableGridHoSo.Columns.Add("TrangThaiKiemSoat");
            dataTableGridHoSo.Columns.Add("TrangThaiGiaoDich");
            dataTableGridHoSo.Columns.Add("NgayGDDauTien");
            dataTableGridHoSo.Columns.Add("VonDieuLe");
            dataTableGridHoSo.Columns.Add("KLLH");
            dataTableGridHoSo.Columns.Add("KLNY");
            dataTableGridHoSo.Columns.Add("Link_BanCaoBach");
            Thread.Sleep(2000);
            try
            {
                IList<IWebElement> listCount = chromeDriver.FindElements(By.XPath($"//*[@id=\"divSearchContentArticle\"]/ul/li[2]/div/div/div[2]/ul/li"));
                // MessageBox.Show(Convert.ToString(listCount.Count));
                for (int i = 1; i < listCount.Count; i++)
                {
                    chromeDriver.FindElement(By.XPath("//*[@id=\"divSearchContentArticle\"]/ul/li[2]/div/button/div")).Click();
                    Thread.Sleep(3000);
                    chromeDriver.FindElement(By.XPath($"//*[@id=\"divSearchContentArticle\"]/ul/li[2]/div/div/div[2]/ul/li[{i}]/label")).Click();
                    Thread.Sleep(2000);
                    chromeDriver.FindElement(By.XPath("//*[@id=\"btnSearchSymbolOnDetail\"]")).Click();
                    Thread.Sleep(2000);
                    IList<IWebElement> dataColumns = chromeDriver.FindElements(By.XPath($"//*[@id=\"_TabDiv_1\"]/div/div[2]"));
                    string MaCk = chromeDriver.FindElement(By.XPath("//*[@id=\"_TabDiv_1\"]/div[1]/div[2]")).Text;
                    string Link_BanCaoBach = chromeDriver.FindElement(By.XPath("//*[@id=\"_TabDiv_1\"]/div[9]/div[2]/a")).GetAttribute("href");

                    if (checkColumnsData(MaCk, queryProc) == false)
                    {
                        string TenTCPH = dataColumns[1].Text;
                        string TruSoChinh = dataColumns[2].Text;
                        string DiaChiLienlac = dataColumns[3].Text;
                        string GPTL = dataColumns[4].Text;
                        string TenNganh = dataColumns[5].Text;
                        string NguoiDaiDien = dataColumns[6].Text;
                        string NguoiCongBo = dataColumns[7].Text;
                        string BanCaoBach = dataColumns[8].Text;
                        string TrangThaiKiemSoat = dataColumns[9].Text;
                        string TrangThaiGiaoDich = dataColumns[10].Text;
                        DateTime NgayGDDauTien = DateTime.ParseExact(dataColumns[11].Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        double VonDieuLe = Convert.ToDouble(dataColumns[12].Text.Replace(".", ""));
                        double KLLH = Convert.ToDouble(dataColumns[13].Text.Replace(".", ""));
                        double KLNY = Convert.ToDouble(dataColumns[14].Text.Replace(".", ""));
                        dataTableGridHoSo.Rows.Add(MaCk, TenTCPH, TruSoChinh, DiaChiLienlac, GPTL, TenNganh, NguoiDaiDien, NguoiCongBo, BanCaoBach, TrangThaiKiemSoat, TrangThaiGiaoDich, NgayGDDauTien, VonDieuLe, KLLH, KLNY, Link_BanCaoBach);
                    }
                    Thread.Sleep(2000);
                }
                DataProvider.Instance.insertDB(dataTableGridHoSo);
                chromeDriver.Quit();
            }
            catch (Exception ex)
            {
                chromeDriver.Quit();

            }

        }
        public bool checkColumnsData(string mack, string queryEx)
        {
            var i = DataProvider.Instance.Executequery(queryEx, new object[] { mack });
            if (i.Rows.Count > 0) { return true; }
            return false;
        }



        public void ToCsV(DataGridView dgv, string name, string age, string address, string title, string filename)
        {
            //========Data from textbox==========//        
            string stOutput = "";
            string stTitle = "";
            string sHeaders = "";
            string stName = "";
            string stAge = "";
            string stAdrress = "";
            stTitle = "\r\n" + title + "\r\n\n";
            stName = "\n" + name + "\r";
            stAdrress = "\n" + address + "\r";
            stAge = "\n" + age + "\r";
            stOutput += title;
            stOutput += stName;
            stOutput += stAdrress;
            stOutput += stAge;
            for (int j = 0; j < dgv.Columns.Count; j++)
                sHeaders = sHeaders.ToString() + Convert.ToString(dgv.Columns[j].HeaderText) + "\t";
            stOutput += sHeaders + "\r\n";
            // Export data.  
            for (int i = 0; i < dgv.RowCount - 1; i++)
            {
                string stLine = "";
                for (int j = 0; j < dgv.Rows[i].Cells.Count; j++)
                    stLine = stLine.ToString() + Convert.ToString(dgv.Rows[i].Cells[j].Value) + "\t";
                stOutput += stLine + "\r\n";
            }
            Encoding utf16 = Encoding.GetEncoding(1254);
            byte[] output = utf16.GetBytes(stOutput);
            FileStream fs = new FileStream(filename, FileMode.Create);
            BinaryWriter bw = new BinaryWriter(fs);

            bw.Write(output, 0, output.Length); //write the encoded file  
            bw.Flush();
            bw.Close();
            fs.Close();
        }
        private Worksheet FindSheet(Workbook workbook, string sheet_name)
        {
            foreach (Worksheet sheet in workbook.Worksheets)
            {
                if (sheet.Name == sheet_name) return sheet;
            }
            return null;
        }
        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

    }

}



