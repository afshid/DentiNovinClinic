using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Security.Cryptography;

namespace DentiNovin.Common
{
    class FileReadWrite
    {
        // Key for TripleDES encryption
        public static byte[] key = { 97, 250, 1, 5, 96, 21, 7, 63,
            4, 54, 87, 56, 123, 10, 3, 62,
            7, 9, 37, 58, 37, 21, 101, 57};
                    
        private static byte[] iv = { 0, 0, 0, 0, 0, 0, 0, 0 };

        public static string ReadFile(string FilePath)
        {
            FileInfo fi = new FileInfo(FilePath);
            if (fi.Exists == false)
                return string.Empty;

            FileStream fin = new FileStream(FilePath, FileMode.Open, FileAccess.Read);
            TripleDES tdes = new TripleDESCryptoServiceProvider();
            CryptoStream cs = new CryptoStream(fin, tdes.CreateDecryptor(key, iv), CryptoStreamMode.Read);

            StringBuilder SB = new StringBuilder();
            int ch;
            for (int i = 0; i < fin.Length; i++)
            {
                ch = cs.ReadByte();
                if (ch == 0)
                    break;
                SB.Append(Convert.ToChar(ch));
            }

            cs.Close();
            fin.Close();
            return SB.ToString();
        }

        public static void WriteFile(string FilePath, string Data)
        {
            FileStream fout = new FileStream(FilePath, FileMode.OpenOrCreate, FileAccess.Write);
            TripleDES tdes = new TripleDESCryptoServiceProvider();
            CryptoStream cs = new CryptoStream(fout, tdes.CreateEncryptor(key, iv), CryptoStreamMode.Write);
            
            byte[] d = Encoding.ASCII.GetBytes(Data);
            cs.Write(d, 0, d.Length);
            cs.WriteByte(0);

            cs.Close();
            fout.Close();
        }
    }
}
