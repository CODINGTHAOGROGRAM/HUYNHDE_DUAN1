using BUS;
using DTO;
using HUYNHDE_DUAN1.formShowClickGrid;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static HUYNHDE_DUAN1.formMessage;
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
            BUS_GiaoDichTraiPhieu.Instance.loadData(dataGridGDTP);
        }

        private void dataGridGDTP_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            //var binding;
            foreach (DataGridViewRow r in dataGridGDTP.SelectedRows)
            {
                textBox3.Text = r.Cells[2].Value.ToString();
                /*binding.Add(r.Cells[2].Value.ToString());
                binding.Add(r.Cells[3].Value.ToString());
                binding.Add(r.Cells[4].Value.ToString());
                binding.Add(r.Cells[5].Value.ToString());
                binding.Add(r.Cells[6].Value.ToString());
                binding.Add(r.Cells[7].Value.ToString());
                binding.Add(r.Cells[8].Value.ToString());
                binding.Add(r.Cells[9].Value.ToString());
                binding.Add(r.Cells[10].Value.ToString());
                binding.Add(r.Cells[11].Value.ToString());
                binding.Add(r.Cells[12].Value.ToString());*/
            }

            /*textBox3.Text = binding.Count.ToString();*/
            //formShowGDTP show = new formShowGDTP();
            //show.showData(binding);
        }
    }
}