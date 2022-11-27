using BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HUYNHDE_DUAN1.formShowClickGrid
{
    public partial class formShowBDG : Form
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
        private void panelControlForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        #endregion MouseDown Form
        public formShowBDG()
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
        private void btnSave_Click(object sender, EventArgs e)
        {
            string mack = txtMaCk.Text;
            DateTime ngayGiaoDich = Convert.ToDateTime(txtNgayGiaoDich.Text);
            double giaThamChieu = Convert.ToDouble(txtThamChieu.Text);
            double giaTran = Convert.ToDouble(txtGiaTran.Text);
            double giaSan = Convert.ToDouble(txtGiaSan.Text);
            double giaMo = Convert.ToDouble(txtGiaMo.Text);
            double giaDong = Convert.ToDouble(txtGiaDong.Text);
            double giaCao = Convert.ToDouble(txtGiaCao.Text);
            double giaThap = Convert.ToDouble(txtGiaThap.Text);
            double diem = Convert.ToDouble(txtGia.Text);
            double phanTram = Convert.ToDouble(txtPhanTram.Text);

            if (BUS_BienDongGia.Instance.UpdateBDG(ngayGiaoDich, mack, giaThamChieu, giaTran, giaSan, giaMo, giaDong, giaCao, giaThap, diem, phanTram))
            {
               formMessage f = new formMessage();
                f.tt.Text = "Luu Thanh Cong";
                f.info.Text = "Da luu";
                f.ShowDialog();
            }
        }
    }
}
