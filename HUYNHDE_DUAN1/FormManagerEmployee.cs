using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            formChildManagerEmployee ctrolEmploy = new formChildManagerEmployee();
            FormMain fm = new FormMain();
            ctrolEmploy.ShowDialog();
            ctrolEmploy.MdiParent = fm;

        }
    }
}
