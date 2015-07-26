/*****************************************************************************
 * Copyright (c) 2015 川渝同乡联合会 All Rights Reserved.
 * CLR版本： 4.0.30319.34014
 * 机器名称：CG
 * 命名空间：Sys.Common
 * 文件名：  StringUtil
 * 版本号：  V1.0.0.0
 * 唯一标识：f0465b7b-05ad-4461-b2d9-d5a3340d36a2
 * 创建人：  成刚
 * 创建时间：2015/7/26 19:46:22
 * 描述：
 *
 *=====================================================================
 * 修改标记
 * 修改时间：
 * 修改人： 
 * 版本号： 
 * 描述：
 *
/*******************************************************************************/
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Sys.Common
{
    public class StringUtil
    {
        // Fields
        private static readonly byte[] IvByte;
        private static readonly byte[] KeyByte;

        public StringUtil()
        {

        }
        static StringUtil()
        {
            KeyByte = new byte[] { 0xf3, 0x91, 0xd6, 0xff, 50, 0x1f, 0x4a, 2 };
            IvByte = new byte[] { 0x15, 0x33, 0x21, 0x9f, 0xb6, 220, 0xaf, 0xd8 };
        }

        public static string Decrypt(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return string.Empty;
            }
            input = input.Replace(' ', '+');
            ICryptoTransform transform = new DESCryptoServiceProvider().CreateDecryptor(KeyByte, IvByte);
            MemoryStream stream = new MemoryStream();
            CryptoStream stream2 = new CryptoStream(stream, transform, CryptoStreamMode.Write);
            byte[] buffer = Convert.FromBase64String(input);
            stream2.Write(buffer, 0, buffer.Length);
            stream2.FlushFinalBlock();
            stream2.Close();
            return Encoding.UTF8.GetString(stream.ToArray());
        }

        public static string Encrypt(string input)
        {
            ICryptoTransform transform = new DESCryptoServiceProvider().CreateEncryptor(KeyByte, IvByte);
            MemoryStream stream = new MemoryStream();
            CryptoStream stream2 = new CryptoStream(stream, transform, CryptoStreamMode.Write);
            byte[] bytes = Encoding.UTF8.GetBytes(input);
            stream2.Write(bytes, 0, bytes.Length);
            stream2.FlushFinalBlock();
            stream2.Close();
            return Convert.ToBase64String(stream.ToArray());
        }

        public static string ToHashString(string input)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(input);
            byte[] buffer2 = new MD5CryptoServiceProvider().ComputeHash(bytes);
            StringBuilder builder = new StringBuilder();
            foreach (byte num in buffer2)
            {
                builder.Append(num.ToString("X2"));
            }
            return builder.ToString();
        }

        /// <summary>
        /// list 属性转string
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="propertyName"></param>
        /// <param name="spacer"></param>
        /// <param name="removeRepeat"></param>
        /// <returns></returns>
        public static string ListOneProperty2String<T>(List<T> list, string propertyName, string spacer, bool removeRepeat = false) where T : new()
        {
            if (list == null || list.Count <= 0)
                return null;

            StringBuilder sbStr = new StringBuilder();

            foreach (T t in list)
            {
                PropertyInfo[] propertys = t.GetType().GetProperties();
                foreach (PropertyInfo p in propertys)
                {
                    if (p.Name == propertyName)
                    {
                        var v = p.GetValue(t, null).ToString();
                        if (removeRepeat && sbStr.ToString().Contains(v + spacer)) continue;
                        sbStr.Append(v + spacer);
                    }
                }
            }
            return sbStr.ToString().TrimEnd(spacer.ToCharArray());
        }
    }
}
