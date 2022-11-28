using DTO;
using System.Data;

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

        public DataTable getListVonHoa()
        {
            DataTable dt = new DataTable();

            string query = "exec ShowData_VH";

            dt = DataProvider.Instance.Executequery(query);

            return dt;
        }

        public bool update(DTO_VonHoa VH)
        {
            string query = "Update_VH @NgayGiaoDich , @MaCk , @GiaDong , @VonHoa , @ThiTruong ";

            object[] para = new object[] { VH.NgayGiaoDich, VH.MaCk, VH.GiaDOng, VH.GiaTriVonHoa, VH.PhanTramThiTruong };

            if (DataProvider.Instance.ExecuteNonquery(query, para) > 0) { return true; }
            return false;
        }
    }
}