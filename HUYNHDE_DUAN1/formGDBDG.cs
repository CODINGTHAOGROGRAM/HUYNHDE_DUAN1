using System.Windows.Forms;

namespace HUYNHDE_DUAN1
{
    public partial class formGDBDG : Form
    {
        public formGDBDG()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, System.EventArgs e)
        {
            formChildGDBDG dg = new formChildGDBDG();
            dg.ShowDialog();
        }

        private void panel1_Click(object sender, System.EventArgs e)
        {
            this.ActiveControl = null;
        }

        private void panel2_Click(object sender, System.EventArgs e)
        {
            this.ActiveControl = null;
        }
    }
}