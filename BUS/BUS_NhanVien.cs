using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DAL;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using System.Web.Security;
using static BUS.BUS_TaiKhoan;

namespace BUS
{
    public class BUS_NhanVien
    {
        BUS_TaiKhoan md5 = new BUS_TaiKhoan();
        private static BUS_NhanVien instance;

        public static BUS_NhanVien Instance
        {
            get { if (instance == null) instance = new BUS_NhanVien(); return BUS_NhanVien.instance; }

            private set { BUS_NhanVien.instance = value; }
        }

        public DataTable LoadData()
        {
           return DAL_NhanVien.Instance.loadData();
        }

        public string getIDNV()
        {
            DataTable data = new DataTable();
            data=DAL_NhanVien.Instance.getIDNV();
            DataRow lastRow = data.Rows[data.Rows.Count - 1];
            var value = lastRow["ID"] as string;
            int idNum = Convert.ToInt32(value);
            idNum++;
            string id = $"HD{idNum}";
            if (id.Count() == 3)
            {
                id = id.Replace(idNum.ToString(), $"00{idNum}");
            }
            else if (id.Count() == 4)
            {
                id = id.Replace(idNum.ToString(), $"0{idNum}");
            }
            return id;
        }

        public bool editData(string MaNV, string Ten, string Email, string GioiTinh, string SoDienThoai, string CMND, DateTime NgaySinh, string DiaChi,
           string ChucVu, string GhiChu, string Anh)
        {

            return DAL_NhanVien.Instance.editData(MaNV, Ten, Email,GioiTinh, SoDienThoai, CMND, NgaySinh, DiaChi,
            ChucVu, GhiChu, Anh);
        }

        public bool deleteData(string ID)
        {
            return DAL_NhanVien.Instance.deleteData(ID);
        }
        void SendMail(string maillAd,string pass, string name)
        {
            var fromAddress = new MailAddress("huynh.de.vip.pro.2002.2003@gmail.com", "HUYNH DE");
            var toAddress = new MailAddress($"{maillAd}");
            const string fromPassword = "huynhde123";
              

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, "xomhsfugkdddcdgb")
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = $"Xin chào {name}.",
                Body = $"Chào mừng bạn đến với công ty HuynhDe Cào Cào !!!\n" +
                $"Mật khẩu đăng nhập của bạn là: {pass}"

        })
            {
                smtp.Send(message);
            }
        }
        public bool addData(string MaNV, string Ten, string Email, string GioiTinh, string SoDienThoai, string CMND, DateTime NgaySinh, string DiaChi,
           string ChucVu, string Anh, string MatKhau, string GhiChu)
        {
            MatKhau = Membership.GeneratePassword(12, 3);
            SendMail(Email, MatKhau, Ten);
            MatKhau = md5.enCodeOneWay(MatKhau);
            return DAL_NhanVien.Instance.addData(MaNV , Ten , Email, GioiTinh, SoDienThoai, CMND , NgaySinh, DiaChi,
            ChucVu, Anh, MatKhau, GhiChu);

        }
    }
}
