using BUS;
using DTO;
using System;
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
    }
}