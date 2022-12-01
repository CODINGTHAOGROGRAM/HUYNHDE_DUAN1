using HUYNHDE_DUAN1.FormExportFile;
using HUYNHDE_DUAN1.FormUI;
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

namespace HUYNHDE_DUAN1.formShowClickGrid
{
    public partial class formShowStock : Form
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

        #endregion Border Forms

        #region MouseDown Form

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        private void panelLinearGradient1_MouseDown_1(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        #endregion MouseDown Form


        public formShowStock()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            // CallBack BorderForms
            this.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 30, 30));



        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();

        }
        private int iD;

        public void bindindDataGrid(List<string> data)
        {
            iD = Convert.ToInt32(data[0]);
            title.Text = data[1];
            txtMaCK.Text = data[1];
            txtTen.Text = data[2];
            txtTruSo.Text = data[3];
            txtSdt.Text = data[4];
            txtGPTL.Text = data[5];
            txtNganh.Text = data[6];
            txtNguoiDD.Text = data[7];
            txtNguoiCB.Text = data[8];
            txtBangCao.Text = data[9];
            txtKiemSoat.Text = data[10];
            txtGiaoDich.Text = data[11];
            txtNgay.Text = data[12].Replace("/", "-");
            txtVon.Text = data[13];
            txtKLLH.Text = data[14];
            txtKLNY.Text = data[15];
            txtLink.Text = data[16];

        }

        private void btnExports_Click(object sender, EventArgs e)
        {
            formExShowStock show = new formExShowStock();
            show.ShowDialog();  
        }

       

    }
}