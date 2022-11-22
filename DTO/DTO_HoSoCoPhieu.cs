using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_HoSoCoPhieu
    {
        private static DTO_HoSoCoPhieu instance;

        public static DTO_HoSoCoPhieu Instance
        {
            get { if (instance == null) instance = new DTO_HoSoCoPhieu(); return DTO_HoSoCoPhieu.instance; }

            private set { DTO_HoSoCoPhieu.instance = value; }
        }

        private string maCk;

        public string MaCk { get => maCk; set => maCk = value; }

        private string tenTCPH;
        public string TenTCPH { get => tenTCPH; set => tenTCPH = value; }


        private string truSoChinh;
        public string TruSoChinh { get => truSoChinh; set => truSoChinh = value; }

        private string diaChiLienlac;
        public string DiaChiLienlac { get => diaChiLienlac; set => diaChiLienlac = value; }

        private string gPTL;
        public string GPTL { get => gPTL; set => gPTL = value; }

        private string tenNganh;
        public string TenNganh { get => tenNganh; set => tenNganh = value; }

        private string nguoiDaiDien;
        public string NguoiDaiDien { get => nguoiDaiDien; set => nguoiDaiDien = value; }

        private string nguoiCongBo;
        public string NguoiCongBo { get => nguoiCongBo; set => nguoiCongBo = value; }

        private string banCaoBach;
        public string BanCaoBach { get => banCaoBach; set => banCaoBach = value; }

        private string trangThaiKiemSoat;

        public string TrangThaiKiemSoat { get => trangThaiKiemSoat; set => trangThaiKiemSoat = value; }

        private string trangThaiGiaoDich;

        public string TrangThaiGiaoDicj { get => trangThaiGiaoDich; set => trangThaiGiaoDich = value; }
        public DateTime NgayGDDauTien { get => ngayGDDauTien; set => ngayGDDauTien = value; }

        private DateTime ngayGDDauTien;

        private double vonDieuLe;

        public double VonDieuLe { get => vonDieuLe; set => vonDieuLe = value; }

        private double kLLH;

        public double KLLH { get => kLLH; set => kLLH = value; }

        private double kLNY;
        public double KLNY { get => kLNY; set => kLNY = value; }


        public DTO_HoSoCoPhieu() { }
        public DTO_HoSoCoPhieu(string mack, string tenTCPH, string truSoChinh, string diaChiLienLac, string gPTL, string tenNganh, string nguoiDaiDien,
            string nguoiCongBo, string banCaoBach, string trangThaiKiemSoat, string trangThaiGiaoDich, DateTime ngayGDDauTien, double vonDieuLe, double kLLH, double kLNY)
        {
            this.maCk = mack;
            this.tenTCPH = tenTCPH;
            this.truSoChinh = truSoChinh;
            this.diaChiLienlac = diaChiLienLac;
            this.gPTL = gPTL;
            this.tenNganh = tenNganh;
            this.nguoiDaiDien = nguoiDaiDien;
            this.nguoiCongBo = nguoiCongBo;
            this.banCaoBach = banCaoBach;
            this.trangThaiKiemSoat = trangThaiKiemSoat;
            this.trangThaiGiaoDich = trangThaiGiaoDich;
            this.ngayGDDauTien = ngayGDDauTien;
            this.vonDieuLe = vonDieuLe;
            this.kLLH = kLLH;
            this.KLNY = kLNY;
        }

    }
}
