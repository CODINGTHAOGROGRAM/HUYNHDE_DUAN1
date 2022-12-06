using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BUS_TaiKhoan
    {
        private static BUS_TaiKhoan instance;

        public static BUS_TaiKhoan Instance
        {
            get { if (instance == null) instance = new BUS_TaiKhoan(); return BUS_TaiKhoan.instance; }

            private set { BUS_TaiKhoan.instance = value; }
        }

        public bool Login(string username, string password)
        {
            return DAL_TaiKhoan.Instance.Login(username, password);
        }
        public static string enCodeOneWay(string _input)
        {

        }
        public static string enCodeTwoWay(string _input)
        {
            char[] inPut_PassEn = _input.ToCharArray();
            var input_WithPass = inPut_PassEn.Select((val, ind) => new {val, ind }).ToArray();
            var char_input_Encode = input_WithPass.Select( c => c.val + c.ind + (input_WithPass.Length > c.ind + 1 ? input_WithPass[c.ind + 1].val % 2 : 0)).Select(c =>(char)c).ToArray(); 
            string res = new string(char_input_Encode);
            return res;
        }
    }
}
