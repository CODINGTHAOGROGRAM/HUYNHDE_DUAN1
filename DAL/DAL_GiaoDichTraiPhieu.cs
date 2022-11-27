using System;
using System.Data;
using System.Data.OleDb;
using System.IO;

namespace DAL
{
    public class DAL_GiaoDichTraiPhieu
    {
        private static DAL_GiaoDichTraiPhieu instance;

        public static DAL_GiaoDichTraiPhieu Instance
        {
            get { if (instance == null) instance = new DAL_GiaoDichTraiPhieu(); return DAL_GiaoDichTraiPhieu.instance; }

            private set { DAL_GiaoDichTraiPhieu.instance = value; }
        }

        /*public List<DTO_GiaoDichTraiPhieu> loadData()
        {
            List<DTO_GiaoDichTraiPhieu> list = new List<DTO_GiaoDichTraiPhieu>();
            string query = "ShowData_GDTP";

            DataTable data = DataProvider.Instance.Executequery(query);

            foreach (DataRow item in data.Rows)
            {
                DTO_GiaoDichTraiPhieu gdtp = new DTO_GiaoDichTraiPhieu(item);
                list.Add(gdtp);
            }
            return list;
        }*/

        public DataTable loadData()
        {
            DataTable dtb = new DataTable();
            string query = "ShowData_GDTP";

            return dtb = DataProvider.Instance.Executequery(query);
        }

        public bool editData(int ID, int STT, DateTime Ngay_GD, string Ma_CK, float Gia_DC, float TKL_GDKL_LoChan, float TGT_GDKL_LoChan, float TKL_GDKL_LoLe,
            float TGT_GDKL_LoLe, float Tong_KLGD_TT_LoChan, float Tong_GTGD_TT_LoChan, float Tong_KLGD_TT_LoLe, float Tong_GTGD_TT_LoLe)
        {
            string query = "Update_GDTP @ID , @STT , @Ngay_GD , @Ma_CK , @Gia_DC , @TKL_GDKL_LoChan , @TGT_GDKL_LoChan , @TKL_GDKL_LoLe , @TGT_GDKL_LoLe , @Tong_KLGD_TT_LoChan , @Tong_GTGD_TT_LoChan , @Tong_KLGD_TT_LoLe , @Tong_GTGD_TT_LoLe";

            int result = DataProvider.Instance.ExecuteNonquery(query, new object[] { ID , STT , Ngay_GD.ToString("MM/dd/yyyy"), Ma_CK, Gia_DC , TKL_GDKL_LoChan, TGT_GDKL_LoChan,
            TKL_GDKL_LoLe, TGT_GDKL_LoLe, Tong_KLGD_TT_LoChan, Tong_GTGD_TT_LoChan,Tong_KLGD_TT_LoLe,Tong_GTGD_TT_LoLe});

            return result > 0;
        }

        public void ImportExcelInDB(string filename)
        {
            var CurrentDirectory = Directory.GetCurrentDirectory();
            var path = $"{CurrentDirectory}" + @"\DATA_TPDN\" + $"{filename}";

            // import data
            string constr = string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0; Data Source= {0}; Extended Properties=""Excel 12.0 Xml; HDR= YES;""", path);
            OleDbConnection xlsCon = new OleDbConnection(constr);

            string query = string.Format("Select * from [{0}]", "Báo cáo$");
            OleDbCommand xlsCom = new OleDbCommand(query, xlsCon);

            xlsCon.Open();

            DataSet ds = new DataSet();
            OleDbDataAdapter oda = new OleDbDataAdapter(query, xlsCon);

            xlsCon.Close();

            oda.Fill(ds);

            DataTable GiaoDichTraiPhieu = ds.Tables[0];
            GiaoDichTraiPhieu.TableName = "GiaoDichTraiPhieu";
            GiaoDichTraiPhieu.Rows.Remove(GiaoDichTraiPhieu.Rows[GiaoDichTraiPhieu.Rows.Count - 1]);

            DataProvider.Instance.insertDB(GiaoDichTraiPhieu);
        }
    }
}