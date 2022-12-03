using BUS;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;

namespace HUYNHDE_DUAN1
{
    public partial class FormManagerEmployee : Form
    {
        private formMessage f = new formMessage();

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

        private void LoadData()
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

        private string filePathImg;

        private void btnLoadImg_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                //pic.Image = new Bitmap(ofd.FileName);
                filePathImg = ofd.FileName;
                using (var bmpTemp = new Bitmap(ofd.FileName))
                {
                    pic.Image = new Bitmap(bmpTemp);
                }
                
                string workingDirectory = Environment.CurrentDirectory;
                string sourcePath = Directory.GetParent(filePathImg).Parent.FullName;
                string targetPath = Directory.GetParent(workingDirectory).Parent.Parent.FullName+ @"\img\Avatar_user";

                // Use Path class to manipulate file and directory paths.
                string sourceFile = System.IO.Path.Combine(sourcePath, filePathImg);
                string destFile = System.IO.Path.Combine(targetPath, filePathImg);

                // To copy a file to another location and
                // overwrite the destination file if it already exists.
                System.IO.File.Copy(sourceFile, destFile, true);

                // To copy all the files in one directory to another directory.
                // Get the files in the source folder. (To recursively iterate through
                // all subfolders under the current directory, see
                // "How to: Iterate Through a Directory Tree.")
                // Note: Check for target path was performed previously
                //       in this code example.
                if (System.IO.Directory.Exists(sourcePath))
                {
                    string[] files = System.IO.Directory.GetFiles(sourcePath);

                    // Copy the files and overwrite destination files if they already exist.
                    foreach (string s in files)
                    {
                        // Use static Path methods to extract only the file name from the path.
                        filePathImg = System.IO.Path.GetFileName(s);
                        destFile = System.IO.Path.Combine(targetPath, filePathImg);
                        System.IO.File.Copy(s, destFile, true);
                    }
                }
                else
                {
                    f.showMessage("Thông báo", "Có lỗi khi cập nhật dữ liệu, hãy kiểm tra lại!", "icon_error.png", "Đóng");
                }



            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string maNV = tb_maNV.Text;
                string hoTen = tb_hoTen.Text;
                string Email = tb_Email.Text;
                string GioiTinh;
                if (Nam.Checked)
                {
                    GioiTinh = "Nam";
                }
                else
                {
                    GioiTinh = "Nữ";
                }
                string SoDienThoai = tb_sDth.Text;
                string CMND = tb_CCCD.Text;
                DateTime ngaySinh = DateTime.ParseExact(ngay.Text, "dd/MM/yyyy", null);
                string DiaChi = tb_diaChi.Text;
                string ChucVu;
                if (qTri.Checked)
                {
                    ChucVu = "Quản Trị";
                }
                else
                {
                    ChucVu = "Nhân Viên";
                }
                string Anh = "";
                string GhiChu = tb_note.Text;

                if (BUS_NhanVien.Instance.editData(maNV, hoTen, Email, GioiTinh, SoDienThoai, CMND,
                    ngaySinh, DiaChi, ChucVu, Anh, GhiChu))
                {
                    LoadData();
                    formMessage f = new formMessage();
                    f.showMessage("Thông báo", "Cập nhật thông tin thành công.", "icon_success.png", "Đóng");
                }
            }
            catch (Exception)
            {
                formMessage f = new formMessage();
                f.showMessage("Thông báo", "Có lỗi khi cập nhật dữ liệu, hãy kiểm tra lại!", "icon_error.png", "Đóng");
            }
        }
    }
}