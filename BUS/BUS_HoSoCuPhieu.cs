using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BUS_HoSoCuPhieu
    {

        private static BUS_HoSoCuPhieu instance;

        public static BUS_HoSoCuPhieu Instance
        {
            get { if (instance == null) instance = new BUS_HoSoCuPhieu(); return BUS_HoSoCuPhieu.instance; }

            private set { BUS_HoSoCuPhieu.instance = value; }
        }
        private BUS_HoSoCuPhieu() { }
        public List<DTO_HoSoCoPhieu> getListHoSo()
        {
            List<DTO_HoSoCoPhieu> newList = new List<DTO_HoSoCoPhieu>();
            string queryPerform = "select * from HoSoCoPhieu";
            DataTable data = DataProvider.Instance.Executequery(queryPerform);
            foreach (DataRow rowItem in data.Rows)
            {
                DTO_HoSoCoPhieu dtHoSo = new DTO_HoSoCoPhieu();
                newList.Add(dtHoSo);
            }
            return newList;
        }
    }
}
