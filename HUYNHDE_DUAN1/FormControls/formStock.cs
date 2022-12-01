using BUS;
using HUYNHDE_DUAN1.formShowClickGrid;
using HUYNHDE_DUAN1.FormUI;
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
        //Methods
        public void LoadGrid()
        {
           
            GridViewHoSo.DataSource = BUS_HoSoCuPhieu.Instance.LoadGriHoSo();
            

        }
       


        private void btnAdd_Click(object sender, EventArgs e)
        {
            formChildStock ct = new formChildStock(this);
            ct.ShowDialog();
        }

        private void panel4_Click(object sender, EventArgs e)
        {
            this.ActiveControl = null;
        }




        private void formStock_Load(object sender, EventArgs e)
        {
            LoadGrid();
            // textBox1.DataBindings.Add(new Binding("Text", GridViewHoSo.DataSource, "MaCK"));
            GridViewHoSo.ForeColor = Color.Black;


        }

        private void GridViewHoSo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            List<string> binding = new List<string>();
            for (int i = 0; i < GridViewHoSo.Columns.Count; i++)
            {
                binding.Add(GridViewHoSo.CurrentRow.Cells[i].Value.ToString());
            }
            formShowStock show = new formShowStock();
            show.bindindDataGrid(binding);
            show.ShowDialog();
        }


        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnUpGrade_Click(object sender, EventArgs e)
        {
            BUS_HoSoCuPhieu.Instance.upGradeHoSo();
            LoadGrid();
        }

        private void btnExports_Click(object sender, EventArgs e)
        {
            formExFileStock show = new formExFileStock();
            show.ShowDialog();
        }

       
    }
}
