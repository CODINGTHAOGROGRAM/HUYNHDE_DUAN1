using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            GiaoDichTraiPhieu.Rows.Remove(GiaoDichTraiPhieu.Rows[GiaoDichTraiPhieu.Rows.Count - 1]);

            DataProvider.Instance.insertDB(GiaoDichTraiPhieu);
        }
    }
}
