using Aspose.Cells;
using BUS;
using HUYNHDE_DUAN1.formShowClickGrid;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Shapes;
using System.Drawing;
using System.Xml.Linq;
using HUYNHDE_DUAN1.FormUI;
using System.Windows.Controls;

namespace HUYNHDE_DUAN1
{
    public partial class formDataTP : Form
    {

        private formMessage f = new formMessage();

        public formDataTP()
        {
            InitializeComponent();
            fromdate.Value = DateTime.Today;
            todate.Value = DateTime.Today;
            dataGridGDTP.ForeColor = System.Drawing.Color.Black;
            loadcb();
        }

       public DataTable export()
        {
            DataTable _datatable = dataGridGDTP.DataSource as DataTable;

            return _datatable;
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
            dataGridGDTP.DataSource = BUS_GiaoDichTraiPhieu.Instance.loadData();
        }

        public void loadform()
        {
            formShowGDTP fr = new formShowGDTP(this);
            dataGridGDTP.DataSource = null;
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
            DateTime temp;
            if (fromdate.Value > todate.Value)
            {
                temp = fromdate.Value;
                fromdate.Value = todate.Value;
                todate.Value = temp;
            }
            dataGridGDTP.DataSource = BUS_GiaoDichTraiPhieu.Instance.findData(cb_mack.SelectedValue.ToString(), fromdate.Value, todate.Value);
        }

        public void loadcb()
        {
            cb_mack.DataSource = BUS_GiaoDichTraiPhieu.Instance.showcb();
            cb_mack.DisplayMember = "Ma_CK";
            cb_mack.ValueMember = "Ma_CK";
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            fromdate.Value = DateTime.Today;
            todate.Value = DateTime.Today;
            loadform(); 
        }

        private void btnExports_Click(object sender, EventArgs e)
        {
            formMesageExFile showFormMessageEx = new formMesageExFile(this);
            showFormMessageEx.ShowDialog();
        }
    }
    
}