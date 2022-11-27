﻿using DTO;
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
        
       
        public bool update( DTO_BienDongGia BDG)
        {
            string query = "Update_BDG @ngayGiaoDich , @maCk , @giaThamChieu , @giaTran , @giaSan , @giaMo , @giaDong , @giaCao , @giaThap , @diem , @phanTram ";

            object[] para = new object[] {BDG.NgayGiaoDich,BDG.MaCk, BDG.GiaThamChieu, BDG.GiaTran, BDG.GiaSan, BDG.GiaMo, BDG.GiaDong, BDG.GiaCao, BDG.GiaThap, BDG.Diem, BDG.PhanTram  };

            if(DataProvider.Instance.ExecuteNonquery(query,para) > 0) { return true; }
            return false;
        }
    }
}
