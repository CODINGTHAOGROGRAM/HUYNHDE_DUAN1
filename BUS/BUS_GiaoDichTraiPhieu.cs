using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BUS_GiaoDichTraiPhieu
    {
        private static BUS_GiaoDichTraiPhieu instance;

        public static BUS_GiaoDichTraiPhieu Instance
        {
            get { if (instance == null) instance = new BUS_GiaoDichTraiPhieu(); return BUS_GiaoDichTraiPhieu.instance; }

            private set { BUS_GiaoDichTraiPhieu.instance = value; }
        }
    }
}
