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
    public partial class formPersonnalCurrent : Form
    {
        public formPersonnalCurrent()
        {
            InitializeComponent();
        }

        private void formPersonnalCurrent_Load(object sender, EventArgs e)
        {
            circularPictureBox1.Image = Image.FromFile("../../img/LogoTeamHome.jpg");
            circularPictureBox2.Image = Image.FromFile("../../img/Group 2.png");
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
