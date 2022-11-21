using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_CungCau
    {
        private static DAL_CungCau instance;

        public static DAL_CungCau Instance
        {
            get { if (instance == null) instance = new DAL_CungCau(); return DAL_CungCau.instance; }

            private set { DAL_CungCau.instance = value; }
        }
    }
}
