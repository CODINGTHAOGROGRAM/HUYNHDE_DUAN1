using BUS;
using HUYNHDE_DUAN1.FormChildCotrols;
using System.Windows.Forms;
using static HUYNHDE_DUAN1.formMessage;

namespace HUYNHDE_DUAN1
{
    public partial class formGDBDG : Form
    {
        public formGDBDG()
        {
            InitializeComponent();
            Load();
        }
        private void panel1_Click(object sender, System.EventArgs e)
        {
            this.ActiveControl = null;
        }

        private void panel2_Click(object sender, System.EventArgs e)
        {
            this.ActiveControl = null;
        }



        #region Controls btn BDG
        private void btnAddBDG_Click(object sender, System.EventArgs e)
        {
            formChildGDBDG dg = new formChildGDBDG();
            dg.ShowDialog();
        }
        private void btnExportsBDG_Click(object sender, System.EventArgs e)
        {

        }

        private void btnUpGradeBDG_Click(object sender, System.EventArgs e)
        {
            BUS_BienDongGia.Instance.DongBoBDG();
        }
        #endregion   

        #region Controls btn TKCC
        private void btnUpGradeTKCC_Click(object sender, System.EventArgs e)
        {
            BUS_CungCau.Instance.DongBoCungCau();
        }

        private void btnAddTKCC_Click(object sender, System.EventArgs e)
        {
            formChildTKCC tk = new formChildTKCC();
            tk.ShowDialog();
        }

        private void btnExportTKCC_Click(object sender, System.EventArgs e)
        {

        }
        #endregion

        #region Controls btn VH
        private void btnUpgradeVH_Click(object sender, System.EventArgs e)
        {

        }

        private void btnAddVH_Click(object sender, System.EventArgs e)
        {
            formChildVH vh = new formChildVH();
            vh.ShowDialog();
        }

        private void btnExportVH_Click(object sender, System.EventArgs e)
        {

        }
        #endregion
        void Load()
        {
            BUS_BienDongGia.Instance.LoadBGD(GridBDG);
            BUS_CungCau.Instance.loadCungCau(GridCungCau);
            BUS_VonHoa.Instance.loadCVonHoa(GridVonHoa);
        }

        private void GridBDG_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            formChildGDBDG f = new formChildGDBDG();

            f.txtNgayGiaoDich.Text = GridBDG.CurrentRow.Cells[1].Value.ToString();
            f.txtMaCk.Text = GridBDG.CurrentRow.Cells[2].Value.ToString();
            f.txtThamChieu.Text = GridBDG.CurrentRow.Cells[3].Value.ToString();
            f.txtGiaTran.Text = GridBDG.CurrentRow.Cells[4].Value.ToString();
            f.txtGiaSan.Text = GridBDG.CurrentRow.Cells[5].Value.ToString();
            f.txtGiaMo.Text = GridBDG.CurrentRow.Cells[6].Value.ToString();
            f.txtGiaDong.Text = GridBDG.CurrentRow.Cells[7].Value.ToString();
            f.txtGiaCao.Text = GridBDG.CurrentRow.Cells[8].Value.ToString();
            f.txtGiaThap.Text = GridBDG.CurrentRow.Cells[9].Value.ToString();
            f.txtGia.Text = GridBDG.CurrentRow.Cells[10].Value.ToString();
            f.PhanTram.Text = GridBDG.CurrentRow.Cells[11].Value.ToString();

            f.ShowDialog();
            
        }

        private void GridCungCau_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            formChildTKCC f = new formChildTKCC();

            f.txtNgayGiaoDich.Text = GridCungCau.CurrentRow.Cells[1].Value.ToString();
            f.txtMaCK.Text = GridCungCau.CurrentRow.Cells[2].Value.ToString();
            f.txtGiaDong.Text = GridCungCau.CurrentRow.Cells[3].Value.ToString();
            f.txtLenhMua.Text = GridCungCau.CurrentRow.Cells[4].Value.ToString();
            f.txtLuongMua.Text = GridCungCau.CurrentRow.Cells[5].Value.ToString();
            f.txtLenhBan.Text = GridCungCau.CurrentRow.Cells[6].Value.ToString();
            f.txtLuongban.Text = GridCungCau.CurrentRow.Cells[7].Value.ToString();
            f.txtDuMua.Text = GridCungCau.CurrentRow.Cells[8].Value.ToString();
            f.txtDuBan.Text = GridCungCau.CurrentRow.Cells[9].Value.ToString();
            f.txtKLGD.Text = GridCungCau.CurrentRow.Cells[10].Value.ToString();
            f.txtGTGD.Text = GridCungCau.CurrentRow.Cells[11].Value.ToString();

            f.ShowDialog();
        }

        private void GridVonHoa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            formChildVH f = new formChildVH();

            f.txtNgayGiaoDich.Text = GridVonHoa.CurrentRow.Cells[1].Value.ToString();
            f.txtMaCK.Text = GridVonHoa.CurrentRow.Cells[2].Value.ToString();
            f.txtGiaDong.Text = GridVonHoa.CurrentRow.Cells[3].Value.ToString();
            f.txtVonHoa.Text = GridVonHoa.CurrentRow.Cells[4].Value.ToString();
            f.txtThiTruong.Text = GridVonHoa.CurrentRow.Cells[5].Value.ToString();

            f.ShowDialog();
        }
    }
}