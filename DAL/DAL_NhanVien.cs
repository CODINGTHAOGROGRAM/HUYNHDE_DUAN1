using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DAL
{
    public class DAL_NhanVien
    {
        private static DAL_NhanVien instance;

        public static DAL_NhanVien Instance
        {
            get { if (instance == null) instance = new DAL_NhanVien(); return DAL_NhanVien.instance; }

            private set { DAL_NhanVien.instance = value; }
        }

        public DataTable loadData()
        {
            DataTable data = new DataTable();
            string query = "ShowData_NV";

            return data = DataProvider.Instance.Executequery(query);
        }

        public bool editData(string MaNV, string Ten, string Email, string GioiTinh, string SoDienThoai, string CMND, DateTime NgaySinh, string DiaChi,
            string ChucVu, string GhiChu, string Anh)
        {
            string query = "Update_NV @MaNV , @Ten , @Email , @GioiTinh , @SoDienThoai , @CMND , @NgaySinh , @DiaChi , @ChucVu , @GhiChu , @Anh";

            int result = DataProvider.Instance.ExecuteNonquery(query, new object[] { MaNV , Ten , Email, GioiTinh, SoDienThoai, CMND , NgaySinh.ToString("MM/dd/yyyy"), DiaChi,
            ChucVu, GhiChu, Anh});

            return result > 0;
        }

        public bool deleteData(string ID)
        {
            string query = "Delete_NV @ID";
            int result = DataProvider.Instance.ExecuteNonquery(query, new object[] { ID });
            return result > 0;

        }
    }
}
