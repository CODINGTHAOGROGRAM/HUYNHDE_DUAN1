using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HUYNHDE_DUAN1.FormUI
{
    public partial class formChangesPass : Form
    {
        #region Border Forms
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nleftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWitdthEllipse,
            int nHeightEllipse
        );
        #endregion

        #region MouseDown Form
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);

            }
        }

        #endregion

        public formChangesPass()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            // CallBack BorderForms
            this.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 30, 30));
            this.ActiveControl = null;
        }

        private void formChangesPass_Load(object sender, EventArgs e)
        {
            logoTeams.Image = Image.FromFile("../../img/huynhde_small.png");
          
        }

        #region 1
        private void btnShowPass_Click(object sender, EventArgs e)
        {
            if (txtPassOld.UseSystemPasswordChar == true)
            {
                btnHidePass.BringToFront();
                txtPassOld.UseSystemPasswordChar = false;
            }
        }

        private void btnHidePass_Click(object sender, EventArgs e)
        {
            if (txtPassOld.UseSystemPasswordChar == false)
            {
                btnShowPass.BringToFront();
                txtPassOld.UseSystemPasswordChar = true;
            }
        }




        #endregion

        #region 2
        private void iconPictureBox1_Click(object sender, EventArgs e)
        {
            if (txtPassNew.UseSystemPasswordChar == true)
            {
                iconPictureBox2.BringToFront();
                txtPassNew.UseSystemPasswordChar = false;
            }
        }

        private void iconPictureBox2_Click(object sender, EventArgs e)
        {
            if (txtPassNew.UseSystemPasswordChar == false)
            {
                iconPictureBox1.BringToFront();
                txtPassNew.UseSystemPasswordChar = true;
            }
        }

        #endregion

        #region 3
        private void iconPictureBox3_Click(object sender, EventArgs e)
        {
            if (txtReversePass.UseSystemPasswordChar == true)
            {
                iconPictureBox4.BringToFront();
                txtReversePass.UseSystemPasswordChar = false;
            }
        }

        private void iconPictureBox4_Click(object sender, EventArgs e)
        {
            if (txtReversePass.UseSystemPasswordChar == false)
            {
                iconPictureBox3.BringToFront();
                txtReversePass.UseSystemPasswordChar = true;
            }
        }


        #endregion

        private void btnCancel_Click(object sender, EventArgs e)
        {
            formMessageLogin form = new formMessageLogin();
            form.showMessage("Thông báo", "Bạn chắc chắn muốn hủy ?", "icon_info_login.png", "Thoát");
        }

        private void ExitForms_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}
