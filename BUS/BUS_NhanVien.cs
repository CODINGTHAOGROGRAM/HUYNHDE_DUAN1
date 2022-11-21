using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BUS_NhanVien
    {

        private static BUS_NhanVien instance;

        public static BUS_NhanVien Instance
        {
            get { if (instance == null) instance = new BUS_NhanVien(); return BUS_NhanVien.instance; }

            private set { BUS_NhanVien.instance = value; }
        }

    }
}
