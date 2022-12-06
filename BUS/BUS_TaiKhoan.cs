using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
        public  string enCodeOneWay(string _input)
        {
            using(MD5 md5Hash = MD5.Create())
            {
                string hash = GetmD5Hash(md5Hash, _input);
                return enCodeTwoWay(hash);
            }
        }
        public  string enCodeTwoWay(string _input)
        {
            char[] inPut_PassEn = _input.ToCharArray();
            var input_WithPass = inPut_PassEn.Select((val, ind) => new {val, ind }).ToArray();
            var char_input_Encode = input_WithPass.Select( c => c.val + c.ind + (input_WithPass.Length > c.ind + 1 ? input_WithPass[c.ind + 1].val % 2 : 0)).Select(c =>(char)c).ToArray(); 
            string res = new string(char_input_Encode);
            return res;
        }
        // MD5
        public static string GetmD5Hash(MD5 hash ,string text)
        {
            MD5 md5 = new MD5CryptoServiceProvider();

            //compute hash from the bytes of text  
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));

            //get hash result after compute it  
            byte[] result = md5.Hash;

            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                //change it into 2 hexadecimal digits  
                //for each byte  
                strBuilder.Append(result[i].ToString("x2"));
            }

            return strBuilder.ToString();
        }
    }
}
