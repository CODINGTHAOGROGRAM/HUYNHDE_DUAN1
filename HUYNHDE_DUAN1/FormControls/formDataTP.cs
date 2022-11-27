using BUS;
using HUYNHDE_DUAN1.formShowClickGrid;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace HUYNHDE_DUAN1
{
    public partial class formDataTP : Form
    {
        public formDataTP()
        {
            InitializeComponent();
        }

        private void panel1_Click(object sender, System.EventArgs e)
        {
            this.ActiveControl = null;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            formChildDataTP tp = new formChildDataTP();
            tp.ShowDialog();
        }

        private void btnUpGrade_Click_1(object sender, EventArgs e)
        {
            BUS_GiaoDichTraiPhieu.Instance.Update(fromdate.ToString(), todate.ToString());
        }

        private void formDataTP_Load(object sender, EventArgs e)
        {
            dataGridGDTP.ForeColor = System.Drawing.Color.Black;
            dataGridGDTP.DataSource = BUS_GiaoDichTraiPhieu.Instance.loadData();
        }

        public void loadform()
        {
            formShowGDTP fr = new formShowGDTP(this);
            dataGridGDTP.DataSource = null;
            dataGridGDTP.ForeColor = System.Drawing.Color.Black;
            dataGridGDTP.DataSource = BUS_GiaoDichTraiPhieu.Instance.loadData();
        }

        private void dataGridGDTP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           List<string> binding = new List<string>();
            for (int i = 0; i < dataGridGDTP.Columns.Count; i++)
            {
                binding.Add(dataGridGDTP.CurrentRow.Cells[i].Value.ToString());
            }
            formShowGDTP show = new formShowGDTP(this);
            show.showData(binding);
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
        }
    }
}