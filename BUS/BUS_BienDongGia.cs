﻿using DAL;
using DTO;
using NPOI.XSSF.UserModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BUS
{
    public class BUS_BienDongGia
    {
        private static BUS_BienDongGia instance;

        public static BUS_BienDongGia Instance
        {
            get { if (instance == null) instance = new BUS_BienDongGia(); return BUS_BienDongGia.instance; }

            private set { BUS_BienDongGia.instance = value; }
        }
        public void DongBoBDG()
        {
            ChromeDriverService service = ChromeDriverService.CreateDefaultService();
            service.HideCommandPromptWindow = true;

            var options = new ChromeOptions();
            options.AddArgument("window-position=-32000,-32000");
            IWebDriver driver = new ChromeDriver(service,options);
            
            driver.Navigate().GoToUrl("https://www.hnx.vn/cophieu-etfs/chi-tiet-chung-khoan-ny-AAV.html?_des_tab=2");

            DataTable dt = new DataTable("BienDongGia");

            dt.Columns.Add("NgayGiaoDich", typeof(DateTime));
            dt.Columns.Add("MaCk");
            dt.Columns.Add("GiaThamChieu");
            dt.Columns.Add("GiaTran");
            dt.Columns.Add("GiaSan");
            dt.Columns.Add("GiaMo");
            dt.Columns.Add("GiaDong");
            dt.Columns.Add("GiaCao");
            dt.Columns.Add("GiaThap");
            dt.Columns.Add("Diem");
            dt.Columns.Add("PhanTram");

            Thread.Sleep(2000);

            IList<IWebElement> links = driver.FindElements(By.XPath("//*[@id=\"divSearchContentArticle\"]/ul/li[2]/div/div/div[2]/ul/li/label/input"));
            string query = "exec dbo.BDGiaProc_getByMaCk @mack , @ngayGiaoDich";

            for (int i = 0; i < 2; i++)
            {
                string MaCk = links[i].GetAttribute("value");
                var url = "https://www.hnx.vn/cophieu-etfs/chi-tiet-chung-khoan-ny-" + links[i].GetAttribute("value").ToLower() + ".html?_ces_tab=2";
                driver.Navigate().GoToUrl(url);
                Thread.Sleep(1000);

      
                int x = 2;
                

                while (true)
                {
                    try
                    {
                        driver.FindElement(By.XPath("//*[@id=\"BienDongGiadivNumberRecordOnPage\"]/option[5]")).Click();
                        Thread.Sleep(500);

                        IList<IWebElement> listtr = driver.FindElements(By.XPath("//*[@id=\"BienDongGia_tableDatas\"]/tbody/tr"));
                        Thread.Sleep(500);
                        for (int j = 1; j <= listtr.Count; j++)
                        {
                            IList<IWebElement> listCol = driver.FindElements(By.XPath($"//*[@id=\"BienDongGia_tableDatas\"]/tbody/tr[{j}]/td"));

                            DateTime NgayGiaoDich = DateTime.ParseExact(listCol[0].Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                            if (CountGD(query, MaCk, NgayGiaoDich.ToString()) == false)
                            {
                                #region double.tryparst
                                //double.TryParse(listCol[1].Text.Replace(",", "."), out double GiaThamChieu);
                                //double.TryParse(listCol[2].Text.Replace(",", "."), out double GiaTran);
                                //double.TryParse(listCol[3].Text.Replace(",", "."), out double GiaSan);
                                //double.TryParse(listCol[4].Text.Replace(",", "."), out double GiaMo);
                                //double.TryParse(listCol[5].Text.Replace(",", "."), out double GiaDong);
                                //double.TryParse(listCol[6].Text.Replace(",", "."), out double GiaCao);
                                //double.TryParse(listCol[7].Text.Replace(",", "."), out double GiaThap);
                                //double.TryParse(listCol[8].Text.Replace(",", "."), out double Diem);
                                //double.TryParse(listCol[9].Text.Replace(",", "."), out double PhanTram);


                                //dt.Rows.Add(NgayGiaoDich, MaCk, GiaThamChieu, GiaTran, GiaSan, GiaMo,
                                //                                GiaDong, GiaCao, GiaThap, Diem,
                                //                                PhanTram);
                                #endregion
                                List<double> doubles = tryparst(listCol);

                                dt.Rows.Add(NgayGiaoDich, MaCk, doubles[0], doubles[1], doubles[2], doubles[3],
                                                                doubles[4], doubles[5], doubles[6], doubles[7],
                                                                doubles[8]);
                            }

                        }
                        Thread.Sleep(1000);

                        driver.FindElement(By.XPath($"//*[@id=\"{x}\"]")).Click();
                        x++;
                    }
                    catch (Exception ex)
                    {
                        break;
                    }
                }
                driver.Navigate().Back();
            }
            DataProvider.Instance.insertDB(dt);
            driver.Close();
        }
         public bool CountGD(string query, string mack, string ngayGd)
        {
            var i = DataProvider.Instance.Executequery(query, new object[] { mack, ngayGd });
            if (i.Rows.Count > 0) { return true; }
            return false;
        }

         public List<double> tryparst (IList<IWebElement> list)
        {
            List<double> result = new List<double>();

            for (int i = 1; i < list.Count; i++)
            {
                double.TryParse(list[i].Text.Replace(",", "."), out double number);

                result.Add(number);
            }

            return result;
        }
    }
}
