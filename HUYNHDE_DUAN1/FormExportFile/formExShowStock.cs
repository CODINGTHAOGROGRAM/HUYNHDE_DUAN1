﻿using BUS;
using HUYNHDE_DUAN1.formShowClickGrid;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace HUYNHDE_DUAN1.FormExportFile
{
    public partial class formExShowStock : Form
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
        private formShowStock exShowStock;
        public formExShowStock(formShowStock _exShowStock)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            // CallBack BorderForms
            this.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 50, 50));
            exShowStock = _exShowStock;
        }


        private void excel_Click(object sender, EventArgs e)
        {
            DataTable data = new DataTable();
            data = exShowStock.getdata();
            if (data.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "XLSX (*.xlsx)|*.xlsx";
                sfd.FileName = "HoSoChungKhoan.xlsx";
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
                            BUS_exStock.Instance.ExportFileExStock(sfd.FileName, data);
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
            data = exShowStock.getdata();
            string title = "HỒ SƠ CÁC CHỨNG KHOÁN";
            if (data.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "PDF (*.pdf)|*.pdf";
                sfd.FileName = "HoSoChungKhoan.pdf";
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
                            BUS_exStock.Instance.ExportFilePDF(sfd.FileName, data, title);
                            f.showMessage("Thông báo", "Xuất dữ liệu thành công!", "icon_success.png", "Đóng");
                        }
                        catch (IOException ex)
                        {
                            throw;
                            //MessageBox.Show("Error :" + ex.Message);
                        }
                    }
                }
            }
            else
            {
                f.showMessage("Thông báo", "Không có dữ liệu để xuất!", "icon_error.png", "Đóng");
            }
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

