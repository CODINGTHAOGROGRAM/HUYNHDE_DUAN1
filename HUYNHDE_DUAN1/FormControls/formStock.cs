using HUYNHDE_DUAN1.formShowClickGrid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HUYNHDE_DUAN1
{
    public partial class formStock : Form
    {
        public formStock()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            formChildStock ct = new formChildStock();   
            ct.ShowDialog();
        }

        private void panel4_Click(object sender, EventArgs e)
        {
            this.ActiveControl = null;
        }



        // demo fill and click show form child
        private void formStock_Load(object sender, EventArgs e)
        {
            /*
            string connectionString = "Data Source=PARAONG-YODANH\\SQLEXPRESS;Initial Catalog=DuLieuChungKhoan;Integrated Security=True";
            string sql = "select * from HoSoCoPhieu";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlDataAdapter dataadapter = new SqlDataAdapter(sql, connection);
            DataSet ds = new DataSet();
            connection.Open();
            dataadapter.Fill(ds, "HoSoCoPhieu");
            connection.Close();
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "HoSoCoPhieu";
            */
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
