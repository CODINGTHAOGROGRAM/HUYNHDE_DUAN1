using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_NhanVien
    {
        private static DTO_NhanVien instance;

        public static DTO_NhanVien Instance
        {
            get { if (instance == null) instance = new DTO_NhanVien(); return DTO_NhanVien.instance; }

            private set { DTO_NhanVien.instance = value; }
        }

        private string maNV;

        public string MaNV { get => maNV; set => maNV = value; }

        private string ten;

        public string Ten { get => ten; set => ten = value; }

        private string email;

        public string Email { get => email; set => email = value; }

        private string matKhau;
        public string MatKhau { get => matKhau; set => matKhau = value; }

        private int gioiTinh;
        public int GioiTinh { get => gioiTinh; set => gioiTinh = value; }

        private string soDienThoai;
        public string SoDienThoai { get => soDienThoai; set => soDienThoai = value; }

        private DateTime ngaySinh;

        public DateTime NgaySinh { get => ngaySinh; set => ngaySinh = value; }

        private string diaChi;
        public string DiaChi { get => diaChi; set => diaChi = value; }

        private int vaiTro;
        public int VaiTro { get => vaiTro; set => vaiTro = value; }

        private string anh;
        public string Anh { get => anh; set => anh = value; }

        public DTO_NhanVien(string manv, string ten, string email, string matkhau, int gioitinh, string sodienthoai, DateTime ngaysinh, string diachi, int vaitro, string anh)
        {
            this.maNV = manv;
            this.ten = ten;
            this.email = email;
            this.matKhau = matkhau;
            this.gioiTinh = gioitinh;
            this.soDienThoai = sodienthoai;
            this.ngaySinh = ngaysinh;
            this.diaChi = diachi;
            this.vaiTro = vaitro;
            this.anh = anh;
        }
        public DTO_NhanVien() { }
    }
}
