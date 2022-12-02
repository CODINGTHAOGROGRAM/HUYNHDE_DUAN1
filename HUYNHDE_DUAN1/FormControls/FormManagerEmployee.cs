using BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Forms;

namespace HUYNHDE_DUAN1
{
    public partial class FormManagerEmployee : Form
    {
        public FormManagerEmployee()
        {
            InitializeComponent();
            LoadData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FormMain main = new FormMain();
            formChildManagerEmployee mf = new formChildManagerEmployee();
            main.Opacity = 70;
            mf.ShowDialog();
        }

        private void panel3_Click(object sender, EventArgs e)
        {
            this.ActiveControl = null;
        }

        private void panel2_Click(object sender, EventArgs e)
        {
            this.ActiveControl = null;
        }

        void LoadData()
        {
            dataGridNV.ForeColor = System.Drawing.Color.Black;
            dataGridNV.DataSource = BUS_NhanVien.Instance.LoadData();
        }

        private void dataGridNV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow r in dataGridNV.SelectedRows)
            {
                tb_maNV.Text = r.Cells[0].Value.ToString();
                tb_hoTen.Text = r.Cells[1].Value.ToString();
                tb_Email.Text = r.Cells[2].Value.ToString();
                if (r.Cells[3].Value.ToString() == "Nam")
                {
                    Nam.Checked = true;
                }
                else
                {
                    Nu.Checked = true;
                }
                tb_sDth.Text = r.Cells[4].Value.ToString();
                tb_CCCD.Text = r.Cells[5].Value.ToString();
                string[] date = dataGridNV.CurrentRow.Cells[6].Value.ToString().Split('-');
                string new_format = date[2] + "/" + date[1] + "/" + date[0];
                ngay.Text = new_format.ToString();
                tb_diaChi.Text = r.Cells[7].Value.ToString();
                if (r.Cells[8].Value.ToString() == "Quản Trị")
                {
                    qTri.Checked = true;
                }
                else
                {
                    nVien.Checked = true;
                }
                pic.SizeMode = PictureBoxSizeMode.StretchImage;
                //pic.Image = Image.FromFile($"../../img/Avatar_user/{r.Cells[9].Value.ToString()}");
                tb_note.Text = r.Cells[10].Value.ToString();
            }
        }

        private void btnLoadImg_Click(object sender, EventArgs e)
        {

        }
    }
}
