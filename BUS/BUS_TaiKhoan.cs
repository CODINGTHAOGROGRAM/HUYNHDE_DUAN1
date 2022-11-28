﻿using DAL;

namespace BUS
{
    public class BUS_TaiKhoan
    {
        private static BUS_TaiKhoan instance;

        public static BUS_TaiKhoan Instance
        {
            get { if (instance == null) instance = new BUS_TaiKhoan(); return BUS_TaiKhoan.instance; }

            private set { BUS_TaiKhoan.instance = value; }
        }

        public bool Login(string username, string password)
        {
            return DAL_TaiKhoan.Instance.Login(username, password);
        }
    }
}