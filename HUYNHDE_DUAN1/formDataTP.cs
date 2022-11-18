using System.Windows.Forms;

namespace HUYNHDE_DUAN1
{
    public partial class formDataTP : Form
    {
        public formDataTP()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, System.EventArgs e)
        {
            formChildDataTP tp = new formChildDataTP();
            tp.ShowDialog();
        }

        
    }
}