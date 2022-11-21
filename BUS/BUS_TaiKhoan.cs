using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
