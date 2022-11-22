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

        private void btnAdd_Click_1(object sender, System.EventArgs e)
        {
            formChildDataTP tp = new formChildDataTP();
            tp.ShowDialog();
        }

        private void panel1_Click(object sender, System.EventArgs e)
        {
            this.ActiveControl = null;
        }

        private void panel2_Click(object sender, System.EventArgs e)
        {
            this.ActiveControl = null;
        }

        private void btnUpGrade_Click(object sender, System.EventArgs e)
        {
            BUS_GiaoDichTraiPhieu.Instance.Update(fromdate.ToString(), todate.ToString());

            formMessage form = new formMessage();
            form.showMessage("Thông báo", "Cập nhật thành công", "icon_success.png");

        }
    }
}