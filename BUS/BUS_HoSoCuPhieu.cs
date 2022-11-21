using System;
using System.Collections.Generic;
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

    }
}
