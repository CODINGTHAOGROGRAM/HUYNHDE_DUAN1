using BUS;
using HUYNHDE_DUAN1.formShowClickGrid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HUYNHDE_DUAN1
{
    public partial class formStock : Form
    {
        public formStock()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            formChildStock ct = new formChildStock();   
            ct.ShowDialog();
        }

        private void panel4_Click(object sender, EventArgs e)
        {
            this.ActiveControl = null;
        }

        void LoadGrid()
        {
            GridViewHoSo.DataSource = BUS_HoSoCuPhieu.Instance.getListHoSo();
        }

        
        private void formStock_Load(object sender, EventArgs e)
        {
            LoadGrid();
        }
    }
}
