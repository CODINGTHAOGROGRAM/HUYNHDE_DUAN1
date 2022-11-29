using BUS;
using HUYNHDE_DUAN1.formShowClickGrid;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace HUYNHDE_DUAN1
{
    public partial class formDataTP : Form
    {
        formMessage f = new formMessage();
        public formDataTP()
        {
            InitializeComponent();
            fromdate.Value = DateTime.Today;
            todate.Value = DateTime.Today;
           

        }

        private void panel1_Click(object sender, System.EventArgs e)
        {
            this.ActiveControl = null;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            formChildDataTP tp = new formChildDataTP(this);
            tp.ShowDialog();
        }

        private void btnUpGrade_Click_1(object sender, EventArgs e)
        {
            Thread mess = new Thread(new ThreadStart(() =>
            {
                f.showMessage("Thông báo", "Đang cập nhật dữ liệu...", "icon_info.png", "Đóng");
            }));
            try
            {
                mess.Start();
                BUS_GiaoDichTraiPhieu.Instance.Update(fromdate.Text, todate.Text);
                mess.Abort();
                f.showMessage("Thông báo", "Cập nhật dữ liệu thành công.", "icon_success.png", "Đóng");
            }
            catch (Exception)
            {
                mess.Abort();
                f.showMessage("Thông báo", "Đã lỗi trong quá trình cập nhật,\nvui lòng kiểm tra và thử lại!", "icon_error.png", "Đóng");
            }
            finally
            {
                loadform();
            }
        }

        private void formDataTP_Load(object sender, EventArgs e)
        {
            dataGridGDTP.ForeColor = System.Drawing.Color.Black;
            dataGridGDTP.DataSource = BUS_GiaoDichTraiPhieu.Instance.loadData();
        }

        public void loadform()
        {
            formShowGDTP fr = new formShowGDTP(this);
            dataGridGDTP.DataSource = null;
            dataGridGDTP.ForeColor = System.Drawing.Color.Black;
            dataGridGDTP.DataSource = BUS_GiaoDichTraiPhieu.Instance.loadData();
            
        }

        private void dataGridGDTP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            List<string> binding = new List<string>();
            for (int i = 0; i < dataGridGDTP.Columns.Count; i++)
            {
                if (i == 2)
                {
                    string[] date = dataGridGDTP.CurrentRow.Cells[i].Value.ToString().Split('-');
                    string new_format = date[2] + "/" + date[1] + "/" + date[0];
                    binding.Add(new_format);
                    continue;
                }
                binding.Add(dataGridGDTP.CurrentRow.Cells[i].Value.ToString());
            }
            formShowGDTP show = new formShowGDTP(this);
            show.showData(binding);
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
        }

        private void dataGridGDTP_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
        }
    }
}