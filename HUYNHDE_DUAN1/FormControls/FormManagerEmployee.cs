using System;
using System.Windows.Forms;

namespace HUYNHDE_DUAN1
{
    public partial class FormManagerEmployee : Form
    {
        public FormManagerEmployee()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FormMain main = new FormMain();
            formChildManagerEmployee mf = new formChildManagerEmployee();
            main.Opacity = 70;
            mf.ShowDialog();
        }

        private void panel3_Click(object sender, EventArgs e)
        {
            this.ActiveControl = null;
        }

        private void panel2_Click(object sender, EventArgs e)
        {
            this.ActiveControl = null;
        }
    }
}