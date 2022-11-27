namespace DAL
{
    public class DAL_VonHoa
    {
        private static DAL_VonHoa instance;

        public static DAL_VonHoa Instance
        {
            get { if (instance == null) instance = new DAL_VonHoa(); return DAL_VonHoa.instance; }

            private set { DAL_VonHoa.instance = value; }
        }
    }
}