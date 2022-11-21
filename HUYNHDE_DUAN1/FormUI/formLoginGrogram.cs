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
using static HUYNHDE_DUAN1.formMessageLogin;

namespace HUYNHDE_DUAN1
{
    public partial class formLoginGrogram : Form
    {
        #region Border Forms
        [DllImport("Gdi32.dll",EntryPoint = "CreateRoundRectRgn")]
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

        public formLoginGrogram()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            // CallBack BorderForms
            this.Region = Region.FromHrgn(CreateRoundRectRgn(0,0,Width,Height,30,30));
        }


        private void ExitForms_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void formLoginGrogram_Load(object sender, EventArgs e)
        {
            imgLogin.Image = Image.FromFile("../../img/login_bg.png");
            logoLogin.Image = Image.FromFile("../../img/user_login.png");
            
        }


        #region MouseDown Form
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        private void imgLogin_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);

            }
        }
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);

            }
        }

        #endregion

        private void btnSignin_Click(object sender, EventArgs e)
        {
           
            formMessageLogin msLogin = new formMessageLogin();
            if(txtUsername.Text == "" || txtPassword.Text == "")
            {
                msLogin.showMessage("Thông báo","Không được để trống thông tin trên!", "icon_info.png");
            }
            else if(txtUsername.Text != "xinchao" || txtPassword.Text != "hello")
            {
                msLogin.showMessage("Lỗi", "Sai tài khoản hoặc mật khẩu", "icon_error.png");
            }

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            formForgetPass fg = new formForgetPass();
            fg.Show();
            this.Hide();
        }

        private void txtUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals(Convert.ToChar(13)))
            {
                btnSignin_Click(sender, e);
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals(Convert.ToChar(13)))
            {
                btnSignin_Click(sender, e);
            }
        }

        private void imgLogin_Click(object sender, EventArgs e)
        {
            this.ActiveControl = null;
        }

        private void panelLinearGradient2_Click(object sender, EventArgs e)
        {
            this.ActiveControl = null;
        }
    }
}
