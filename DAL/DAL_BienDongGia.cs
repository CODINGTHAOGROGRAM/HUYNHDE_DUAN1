using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_BienDongGia
    {
        private static DAL_BienDongGia instance;

        public static DAL_BienDongGia Instance
        {
            get { if (instance == null) instance = new DAL_BienDongGia(); return DAL_BienDongGia.instance; }

            private set { DAL_BienDongGia.instance = value; }
        }
        public DataTable getListBDG()
        {
            DataTable dt = new DataTable();

            string query = "exec ShowData_BDG";

            dt = DataProvider.Instance.Executequery(query);

            return dt;
        }
        
       
        public bool update(string maCk , DateTime ngayGiaoDich , DTO_BienDongGia BDG)
        {
            string query = "update BienDongGia set GiaThamChieu = @giaThamChieu , GiaTran = @giaTran , GiaSan = @giaSan , GiaMo = @giaMo ," +
                            " GiaDong = @giaDong , GiaCao = @giaCao , GiaThap = @giaThap , Diem = @diem , PhanTram = @phanTram where MaCk = @maCk and NgayGiaoDich = @ngayGiaoDich ";

            object[] para = new object[] { BDG.GiaThamChieu, BDG.GiaTran, BDG.GiaSan, BDG.GiaMo, BDG.GiaDong, BDG.GiaCao, BDG.GiaThap, BDG.Diem, BDG.PhanTram , maCk, ngayGiaoDich };

            if(DataProvider.Instance.ExecuteNonquery(query,para) > 0) { return true; }
            return false;
        }
    }
}
