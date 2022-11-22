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

        private void btnAdd_Click_1(object sender, System.EventArgs e)
        {
            formChildGDBDG dg = new formChildGDBDG();
            dg.ShowDialog();
        }

        private void btnAdd1_Click(object sender, System.EventArgs e)
        {
            formChildTKCC tk = new formChildTKCC();
            tk.ShowDialog();
        }

        private void btnAdd2_Click(object sender, System.EventArgs e)
        {
            formChildVH vh = new formChildVH(); 
            vh.ShowDialog();
        }

        private void btnUpGrade_Click(object sender, System.EventArgs e)
        {

            BUS_BienDongGia.Instance.DongBoBDG();
        }

        private void btnUpGrate1_Click(object sender, System.EventArgs e)
        {
            BUS_CungCau.Instance.DongBoCungCau();
        }
    }
}