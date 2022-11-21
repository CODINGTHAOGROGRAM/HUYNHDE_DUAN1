using DAL;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl("https://www.hnx.vn/cophieu-etfs/chi-tiet-chung-khoan-ny-AAV.html?_des_tab=2");
        }
    }
}
