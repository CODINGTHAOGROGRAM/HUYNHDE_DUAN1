using DAL;
using DTO;
using System.Collections.Generic;

namespace BUS
{
    public class BUS_HoSoCuPhieu
    {
        private DAL_HoSoCoPhieu hoso = new DAL_HoSoCoPhieu();

        private static BUS_HoSoCuPhieu instance;

        public static BUS_HoSoCuPhieu Instance
        {
            get { if (instance == null) instance = new BUS_HoSoCuPhieu(); return BUS_HoSoCuPhieu.instance; }

            private set { BUS_HoSoCuPhieu.instance = value; }
        }

        private BUS_HoSoCuPhieu()
        { }

        public List<DTO_HoSoCoPhieu> getListHoSo()
        {
            return hoso.getListHoSo();
        }
    }
}