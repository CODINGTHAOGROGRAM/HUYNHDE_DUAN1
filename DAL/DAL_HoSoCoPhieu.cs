using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_HoSoCoPhieu
    {
        private static DAL_HoSoCoPhieu instance;

        public static DAL_HoSoCoPhieu Instance
        {
            get { if (instance == null) instance = new DAL_HoSoCoPhieu(); return DAL_HoSoCoPhieu.instance; }

            private set { DAL_HoSoCoPhieu.instance = value; }
        }
       
    }
}
