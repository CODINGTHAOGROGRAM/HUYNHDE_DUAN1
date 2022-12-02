﻿using BUS;
using HUYNHDE_DUAN1.formShowClickGrid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HUYNHDE_DUAN1.FormExportFile
{
    public partial class formExShowTP : Form
    {
        #region Border Forms

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nleftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWitdthEllipse,
            int nHeightEllipse
        );

        #endregion

        #region MoveDownForm
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        private void panelLinearGradient1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        #endregion
        formMessage f = new formMessage();
        private formShowGDTP Showgdtp;
        public formExShowTP(formShowGDTP _Showgdtp)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            // CallBack BorderForms
            this.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 50, 50));
            Showgdtp = _Showgdtp;
        }

        

        private void btnEx_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void excel_Click(object sender, EventArgs e)
        {
            DataTable data = new DataTable();
            data = Showgdtp.getdata();
            if (data.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "XLSX (*.xlsx)|*.xlsx";
                sfd.FileName = "DuLieuGDTP.xlsx";
                bool fileError = false;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(sfd.FileName))
                    {
                        try
                        {
                            File.Delete(sfd.FileName);
                        }
                        catch (IOException ex)
                        {
                            fileError = true;
                            f.showMessage("ex.Message", $"Không thể lưu dữ liệu vào ổ đĩa!", "icon_error", "Đóng");
                        }
                    }
                    if (!fileError)
                    {
                        try
                        {
                            BUS_ExportFile.Instance.ExportFileXLSX_GDTP(sfd.FileName, data);
                            f.showMessage("Thông báo", "Xuất dữ liệu thành công!", "icon_success.png", "Đóng");
                        }
                        catch (Exception ex)
                        {
                            f.showMessage("Thông báo", $"{ex.Message}", "icon_error", "Đóng");
                        }
                    }
                }
            }
            else
            {
                f.showMessage("Thông báo", "Không có dữ liệu để xuất!", "icon_error.png", "Đóng");
            }
        }

        private void pdf_Click(object sender, EventArgs e)
        {
            DataTable data = new DataTable();
            data = Showgdtp.getdata();
            string title = "THÔNG TIN GIAO DỊCH CỦA CHỨNG KHOÁN CÁC CHỨNG KHOÁN";
            if (data.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "PDF (*.pdf)|*.pdf";
                sfd.FileName = "DuLieuGDTP.pdf";
                bool fileError = false;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(sfd.FileName))
                    {
                        try
                        {
                            File.Delete(sfd.FileName);
                        }
                        catch (IOException ex)
                        {
                            fileError = true;
                            f.showMessage($"{ex.Message}", $"Không thể lưu dữ liệu vào ổ đĩa!", "icon_error", "Đóng");
                        }
                    }
                    if (!fileError)
                    {
                        try
                        {
                            BUS_ExportFile.Instance.ExportFilePDF(sfd.FileName, data, title);
                            f.showMessage("Thông báo", "Xuất dữ liệu thành công!", "icon_success.png", "Đóng");
                        }
                        catch (IOException ex)
                        {
                            MessageBox.Show("Error :" + ex.Message);
                        }
                    }
                }
            }
            else
            {
                f.showMessage("Thông báo", "Không có dữ liệu để xuất!", "icon_error.png", "Đóng");
            }
        }
    }
}
