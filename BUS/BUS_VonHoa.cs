using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BUS_VonHoa
    {
        private static BUS_VonHoa instance;

        public static BUS_VonHoa Instance
        {
            get { if (instance == null) instance = new BUS_VonHoa(); return BUS_VonHoa.instance; }

            private set { BUS_VonHoa.instance = value; }
        }
    }
}
