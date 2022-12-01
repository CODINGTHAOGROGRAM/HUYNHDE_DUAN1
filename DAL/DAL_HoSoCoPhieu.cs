using System;
using System.Data;

namespace DAL
{
    public class DAL_HoSoCoPhieu
    {
        private static DAL_HoSoCoPhieu instance;

        public static DAL_HoSoCoPhieu Instance
        {
            get { if (instance == null) instance = new DAL_HoSoCoPhieu(); return DAL_HoSoCoPhieu.instance; }

            private set { DAL_HoSoCoPhieu.instance = value; }
        }
        public DAL_HoSoCoPhieu() { }
        public DataTable LoadGriHoSo()
        {
            //  DataTable tableGrip = new DataTable();
            string queryExcute = "ShowData_HSCP";
            return DataProvider.Instance.Executequery(queryExcute);
        }

        //    string SyncDataQuery = "Update_HSCP MaCk, TenTCPH, TruSoChinh, DiaChiLienlac, GPTL, TenNganh, NguoiDaiDien, @NguoiCongBo, BanCaoBach, TrangThaiKiemSoat, TrangThaiGiaoDich, NgayGDDauTien, VonDieuLe, KLLH, KLNY, Link_BanCaoBach"
        //                                        @MaCk, @TenTCPH, @TruSoChinh, @DiaChiLienlac, @GPTL, @TenNganh, @NguoiDaiDien, @NguoiCongBo, @BanCaoBach, @TrangThaiKiemSoat, @TrangThaiGiaoDich, @NgayGDDauTien, @VonDieuLe, @KLLH, @KLNY, @Link_BanCaoBach
        public bool addDataHoSo(string MaCk, string TenTCPH, string TruSoChinh, string DiaChiLienlac, string GPTL, string TenNganh, string NguoiDaiDien, string NguoiCongBo, string BanCaoBach, string TrangThaiKiemSoat, string TrangThaiGiaoDich, DateTime NgayGDDauTien, float VonDieuLe, float KLLH, float KLNY, string Link_BanCaoBach)
        {
            string queryProc = "Add_HSCP  @MaCk , @TenTCPH , @TruSoChinh , @DiaChiLienlac , @GPTL , @TenNganh , @NguoiDaiDien , @NguoiCongBo , @BanCaoBach , @TrangThaiKiemSoat , @TrangThaiGiaoDich , @NgayGDDauTien , @VonDieuLe , @KLLH , @KLNY , @Link_BanCaoBach ";
            int rs = DataProvider.Instance.ExecuteNonquery(queryProc, new object[] { MaCk, TenTCPH, TruSoChinh, DiaChiLienlac, GPTL, TenNganh, NguoiDaiDien, NguoiCongBo, BanCaoBach, TrangThaiKiemSoat, TrangThaiGiaoDich, NgayGDDauTien.ToString("MM/dd/yyyy"), VonDieuLe, KLLH, KLNY, Link_BanCaoBach });
            return rs > 0;
        }
    }
}
