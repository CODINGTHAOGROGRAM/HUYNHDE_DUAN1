using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_NhanVien
    {
        private static DAL_NhanVien instance;

        public static DAL_NhanVien Instance
        {
            get { if (instance == null) instance = new DAL_NhanVien(); return DAL_NhanVien.instance; }

            private set { DAL_NhanVien.instance = value; }
        }
    }
}
