using BUS;
using HUYNHDE_DUAN1.FormChildCotrols;
using System.Windows.Forms;

namespace HUYNHDE_DUAN1
{
    public partial class formGDBDG : Form
    {
        public formGDBDG()
        {
            InitializeComponent();
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

        #endregion Controls btn BDG



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

        #endregion Controls btn TKCC

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

        #endregion Controls btn VH
    }
}