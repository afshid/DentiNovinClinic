using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
using Microsoft.Win32;
using System.Security.Cryptography;

namespace DentiNovin.Common
{
    public class Utilises
    {
        public static string GetLocalizedString(ProgramMessageID id)
        {
            switch (id)
            {
                case ProgramMessageID.PM_actinsuccess: return "اطلاعات با موفیت ثبت شد.";
            }
            return "";
        }
        public static Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

        public static byte[] ConvertImageToByteArray(Image imageToConvert, ImageFormat formatOfImage)
        {
            byte[] Ret;
            try
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    imageToConvert.Save(ms, formatOfImage);
                    Ret = ms.ToArray();
                }
            }
            catch (Exception) { throw; }
            return Ret;
        }
    }

}
