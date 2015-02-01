using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;

namespace WM_Project.control
{
    class CheckLogin
    {
        /// <summary>
        /// 用户的密码是否与数据库中存取的hash密码一致
        /// </summary>
        /// <param name="password">用户登陆的密码</param>
        /// <param name="hash">数据库中存取的hash密码</param>
        /// <returns>密码是否正确</returns>
        public static bool CheckPassword(string password, string hash)
        {
            int count = 8192;

            string salt = hash.Substring(4, 8); //生成salt值
            string saltAndPass = salt + password;

            ASCIIEncoding UE = new ASCIIEncoding();
            MD5 md5 = new MD5CryptoServiceProvider();

            Byte[] hashValue = md5.ComputeHash(UE.GetBytes(saltAndPass));
            Byte[] passByte = UE.GetBytes(password);

            do
            {
                Byte[] hashSalt = new byte[hashValue.Length + passByte.Length];

                Array.Copy(hashValue, 0, hashSalt, 0, hashValue.Length);
                Array.Copy(passByte, 0, hashSalt, hashValue.Length, passByte.Length);

                hashValue = md5.ComputeHash(hashSalt);
            } while (--count > 0);

            string output = hash.Substring(0, 12);
            output += encode64(hashValue, 16);

            return hash.Equals(output);
        }

        /// <summary>
        /// encode64编码
        /// </summary>
        /// <param name="input"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static string encode64(byte[] input, int count)
        {
            string itoa64 = "./0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            string encoder = "";

            int i = 0;

            do
            {
                int value = (int)input[i++];
                encoder = encoder + itoa64[value & 0x3f];
                if (i < count)
                    value |= ((int)input[i]) << 8;
                encoder = encoder + itoa64[(value >> 6) & 0x3f];
                if (i++ >= count)
                    break;
                if (i < count)
                    value |= ((int)input[i]) << 16;
                encoder = encoder + itoa64[(value >> 12) & 0x3f];
                if (i++ >= count)
                    break;
                encoder = encoder + itoa64[(value >> 18) & 0x3f];
            } while (i < count);

            return encoder;
        }
    }
}