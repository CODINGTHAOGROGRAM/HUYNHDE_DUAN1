using System.Data;

namespace DAL
{
    public class DAL_TaiKhoan
    {
        private static DAL_TaiKhoan instance;

        public static DAL_TaiKhoan Instance
        {
            get { if (instance == null) instance = new DAL_TaiKhoan(); return DAL_TaiKhoan.instance; }

            private set { DAL_TaiKhoan.instance = value; }
        }

        public bool Login(string userName, string passWord)
        {
            string query = "GetAccountToLogin @usernam , @password";
            DataTable result = DataProvider.Instance.Executequery(query, new object[] { userName, passWord });

            return result.Rows.Count > 0;
        }
    }
}