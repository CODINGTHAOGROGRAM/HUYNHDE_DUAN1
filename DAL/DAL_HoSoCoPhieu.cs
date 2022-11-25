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
        public DAL_HoSoCoPhieu() { }
        public List<DTO_HoSoCoPhieu> getListHoSo()
        {
            List<DTO_HoSoCoPhieu> newList = new List<DTO_HoSoCoPhieu>();
            string queryPerform = "select * from HoSoCoPhieu";
            DataTable data = DataProvider.Instance.Executequery(queryPerform);
            foreach (DataRow rowItem in data.Rows)
            {
                DTO_HoSoCoPhieu dtHoSo = new DTO_HoSoCoPhieu(rowItem);
                newList.Add(dtHoSo);
            }
            return newList;
        }
    }
}
