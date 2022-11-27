using BUS;
using HUYNHDE_DUAN1.formShowClickGrid;
using System;
using System.Drawing;
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
        private void LoadGrid()
        {
            GridViewHoSo.DataSource = BUS_HoSoCuPhieu.Instance.getListHoSo();
            //show.tt.DataBindings.Add(new Binding("Text", GridViewHoSo.DataSource, "MaCK"));
        }

        //

        private void btnAdd_Click(object sender, EventArgs e)
        {
            formChildStock ct = new formChildStock();
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
            for (int i = 0; i < GridViewHoSo.Columns.Count; i++)
            {
                if (GridViewHoSo.Rows[e.RowIndex].Cells[i].Selected == true || GridViewHoSo.CurrentRow.Selected == true)
                {
                    formShowStock show = new formShowStock();
                    show.bindindDataGrid(GridViewHoSo.DataSource);
                    show.ShowDialog();
                }
            }
        }
    }
}