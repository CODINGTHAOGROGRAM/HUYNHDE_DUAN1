using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_GiaoDichTraiPhieu
    {
        private static DAL_GiaoDichTraiPhieu instance;

        public static DAL_GiaoDichTraiPhieu Instance
        {
            get { if (instance == null) instance = new DAL_GiaoDichTraiPhieu(); return DAL_GiaoDichTraiPhieu.instance; }

            private set { DAL_GiaoDichTraiPhieu.instance = value; }
        }
    }
}
