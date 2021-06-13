using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyAPI.Services
{
    public static class CommonMethods
    {
        public static string Key = "maha@Edrees@";

        public static string ConvertToEncrypt(string Password)
        {
            if (string.IsNullOrEmpty(Password)) return "";
            Password += Key;
            var passwordBytes = Encoding.UTF8.GetBytes(Password);
            return Convert.ToBase64String(passwordBytes);
        }

        public static string ConvertToDecrypt(string Base64EncodeData)
        {
            if (string.IsNullOrEmpty(Base64EncodeData)) return "";
            var Base64EncodeBytes = Convert.FromBase64String(Base64EncodeData);
            var result = Encoding.UTF8.GetString(Base64EncodeBytes);
            result = result.Substring(0, result.Length - Key.Length);
            return result; 
        }
    }
}
