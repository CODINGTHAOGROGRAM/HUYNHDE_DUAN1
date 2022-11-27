using System;
using System.Drawing;
using System.Runtime.InteropServices;
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

        public void bindindDataGrid(object dataSource)
        {
            title.DataBindings.Add(new Binding("Text", dataSource, "MaCK"));
            txtMaCK.DataBindings.Add(new Binding("Text", dataSource, "MaCK"));
            txtTen.DataBindings.Add(new Binding("Text", dataSource, "TenTCPH"));
            txtTruSo.DataBindings.Add(new Binding("Text", dataSource, "TruSoChinh"));
            txtSdt.DataBindings.Add(new Binding("Text", dataSource, "DiaChiLienlac"));
            txtGPTL.DataBindings.Add(new Binding("Text", dataSource, "GPTL"));
            txtNganh.DataBindings.Add(new Binding("Text", dataSource, "TenNganh"));
            txtNguoiDD.DataBindings.Add(new Binding("Text", dataSource, "NguoiDaiDien"));
            txtNguoiCB.DataBindings.Add(new Binding("Text", dataSource, "NguoiCongBo"));
            txtBangCao.DataBindings.Add(new Binding("Text", dataSource, "BanCaoBach"));
            txtKiemSoat.DataBindings.Add(new Binding("Text", dataSource, "TrangThaiKiemSoat"));
            txtGiaoDich.DataBindings.Add(new Binding("Text", dataSource, "TrangThaiGiaoDich"));
            txtNgay.DataBindings.Add(new Binding("Text", dataSource, "NgayGDDauTien"));
            txtVon.DataBindings.Add(new Binding("Text", dataSource, "VonDieuLe"));
            txtKLLH.DataBindings.Add(new Binding("Text", dataSource, "KLLH"));
            txtKLNY.DataBindings.Add(new Binding("Text", dataSource, "KLNY"));
        }
    }
}