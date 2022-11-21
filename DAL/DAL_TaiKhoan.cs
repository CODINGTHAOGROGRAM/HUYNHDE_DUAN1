using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_TaiKhoan
    {
        private static DAL_TaiKhoan instance;

        public static DAL_TaiKhoan Instance
        {
            get { if (instance == null) instance = new DAL_TaiKhoan(); return DAL_TaiKhoan.instance; }

            private set { DAL_TaiKhoan.instance = value; }
        }
    }
}
