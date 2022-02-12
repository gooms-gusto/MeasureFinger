using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace EncrytionHash
{
    public class Kunci
    {

        protected static  byte[] _keyBytes = { 0x11, 0x12, 0x13, 0x14, 0x15, 0x16, 0x17, 0x18 };

        // Must be at least 8 characters
        protected static  string _keyString = "ABC12345";

        // Name for checksum value (unlikely to be used as arguments by user)
        protected static string _checksumKey = "__$$";
        public static  string Decrypt(string text)
        {
            try
            {
                byte[] keyData = Encoding.UTF8.GetBytes(_keyString.Substring(0, 8));
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                byte[] textData = GetBytes(text);
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms,
                  des.CreateDecryptor(keyData, _keyBytes), CryptoStreamMode.Write);
                cs.Write(textData, 0, textData.Length);
                cs.FlushFinalBlock();
                return Encoding.UTF8.GetString(ms.ToArray());
            }
            catch (Exception)
            {
                return String.Empty;
            }
        }
        protected static byte[] GetBytes(string data)
        {
            // GetString() encodes the hex-numbers with two digits
            byte[] results = new byte[data.Length / 2];

            for (int i = 0; i < data.Length; i += 2)
                results[i / 2] = Convert.ToByte(data.Substring(i, 2), 16);

            return results;
        }
        public static  string Encrypt(string text)
        {
            try
            {
                byte[] keyData = Encoding.UTF8.GetBytes(_keyString.Substring(0, 8));
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                byte[] textData = Encoding.UTF8.GetBytes(text);
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms,
                  des.CreateEncryptor(keyData, _keyBytes), CryptoStreamMode.Write);
                cs.Write(textData, 0, textData.Length);
                cs.FlushFinalBlock();
                return GetString(ms.ToArray());
            }
            catch (Exception)
            {
                return String.Empty;
            }
        }
        protected static string GetString(byte[] data)
        {
            StringBuilder results = new StringBuilder();

            foreach (byte b in data)
                results.Append(b.ToString("X2"));

            return results.ToString();
        }
    }
}
