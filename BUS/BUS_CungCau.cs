using DAL;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
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
    public class BUS_CungCau
    {
        private static BUS_CungCau instance;

        public static BUS_CungCau Instance
        {
            get { if (instance == null) instance = new BUS_CungCau(); return BUS_CungCau.instance; }

            private set { BUS_CungCau.instance = value; }
        }

        public void DongBoCungCau()
        {
            ChromeDriverService service = ChromeDriverService.CreateDefaultService();
            service.HideCommandPromptWindow = true;

            var options = new ChromeOptions();
            options.AddArgument("window-position=-32000,-32000");
            IWebDriver driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://www.hnx.vn/cophieu-etfs/chi-tiet-chung-khoan-ny-AAV.html?_des_tab=2");

            DataTable dt = new DataTable("BienDongGia");

            dt.Columns.Add("NgayGiaoDich", typeof(DateTime));
            dt.Columns.Add("MaCk");
            dt.Columns.Add("GiaDong");
            dt.Columns.Add("SoLenhMua");
            dt.Columns.Add("KhoiLuongMua");
            dt.Columns.Add("SoLenhBan");
            dt.Columns.Add("KhoiLuongBan");
            dt.Columns.Add("DuMu");
            dt.Columns.Add("DuBan");
            dt.Columns.Add("KhoiLuongGD");
            dt.Columns.Add("GiaTriGD");

            
        Thread.Sleep(2000);

            IList<IWebElement> links = driver.FindElements(By.XPath("//*[@id=\"divSearchContentArticle\"]/ul/li[2]/div/div/div[2]/ul/li/label/input"));
            string query = "exec dbo.CungCauProc_getByMaCk @mack , @ngayGiaoDich";

            for (int i = 0; i < 2; i++)
            {
                string MaCk = links[i].GetAttribute("value");
                var url = "https://www.hnx.vn/cophieu-etfs/chi-tiet-chung-khoan-ny-" + links[i].GetAttribute("value").ToLower() + ".html?_ces_tab=3";
                driver.Navigate().GoToUrl(url);
                Thread.Sleep(1000);


                int x = 2;


                while (true)
                {
                    try
                    {
                        driver.FindElement(By.XPath("//*[@id=\"BienDongGiadivNumberRecordOnPage\"]/option[5]")).Click();
                        Thread.Sleep(500);

                        IList<IWebElement> listtr = driver.FindElements(By.XPath("//*[@id=\"TK_CungCau_tableDatas\"]/tbody/tr"));
                        Thread.Sleep(500);
                        for (int j = 1; j <= listtr.Count; j++)
                        {
                            IList<IWebElement> listCol = driver.FindElements(By.XPath($"//*[@id=\"TK_CungCau_tableDatas\"]/tbody/tr[{i}]/td"));

                            DateTime NgayGiaoDich = DateTime.ParseExact(listCol[0].Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                            if (BUS_BienDongGia.Instance.CountGD(query, MaCk, NgayGiaoDich.ToString()) == false)
                            {
                                
                                List<double> doubles = BUS_BienDongGia.Instance.tryparst(listCol);

                                dt.Rows.Add(NgayGiaoDich, MaCk, doubles[0], doubles[1], doubles[2], doubles[3],
                                                                doubles[4], doubles[5], doubles[6], doubles[7],
                                                                doubles[8], doubles[9]);
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
    }
}
