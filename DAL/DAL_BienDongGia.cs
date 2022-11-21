using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_BienDongGia
    {
        private static DAL_BienDongGia instance;

        public static DAL_BienDongGia Instance
        {
            get { if (instance == null) instance = new DAL_BienDongGia(); return DAL_BienDongGia.instance; }

            private set { DAL_BienDongGia.instance = value; }
        }
    }
}
