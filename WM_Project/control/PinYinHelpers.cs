using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using Microsoft.International.Converters.PinYinConverter;

namespace WM_Project.control
{
    public static class PinYinHelpers
    {
        public static string ToPinYin(string txt)
        {
            txt = ToDBC(txt);
            txt = txt.Trim();
            byte[] arr = new byte[2]; //每个汉字为2字节  
            StringBuilder result = new StringBuilder();//使用StringBuilder优化字符串连接              
            char[] arrChar = txt.ToCharArray();
            foreach (char c in arrChar)
            {
                arr = System.Text.Encoding.GetEncoding("GBK").GetBytes(c.ToString());//根据系统默认编码得到字节码  
                if (arr.Length == 1)//如果只有1字节说明该字符不是汉字              
                {
                    result.Append(c.ToString());
                    continue;
                }
                ChineseChar chineseChar = new ChineseChar(c);
                result.Append(chineseChar.Pinyins[0].Substring(0, chineseChar.Pinyins[0].Length - 1).ToLower());
                result.Append(" ");
            }
            return result.ToString();
        }
        public static string ToDBC(string input)
        {
            char[] c = input.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == 12288)
                {
                    c[i] = (char)32; continue;
                }
                if (c[i] > 65280 && c[i] < 65375)
                    c[i] = (char)(c[i] - 65248);
            }
            return new string(c);
        }
    }
}