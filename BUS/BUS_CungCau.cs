using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BUS_CungCau
    {
        private static BUS_CungCau instance;

        public static BUS_CungCau Instance
        {
            get { if (instance == null) instance = new BUS_CungCau(); return BUS_CungCau.instance; }

            private set { BUS_CungCau.instance = value; }
        }
    }
}
