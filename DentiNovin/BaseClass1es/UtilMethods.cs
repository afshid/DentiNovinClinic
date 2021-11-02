using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DentiNovin.Common;
using System.IO;
using System.Reflection;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.ComponentModel;
using DentiNovin.Common.DateConvert;

namespace DentiNovin.BaseClasses
{
    public class UtilMethods
    {


        public static string GetToothDirectionString(Byte toothCode, Int16 treatmentArea)
        {
            string ToothProp = string.Empty;
            if ((int)TreatmentArea.Mandibular == treatmentArea)
            {
                ToothProp = "پایین";
                return ToothProp;
            }
            if ((int)TreatmentArea.Maxillary == treatmentArea)
            {
                ToothProp = "بالا";
                return ToothProp;
            }
            if ((int)TreatmentArea.Mouth == treatmentArea)
            {
                ToothProp = "";
                return ToothProp;
            }

            if (toothCode < 9)
                ToothProp = "بالا - چپ";
            else
                if (toothCode < 17)
                    ToothProp = "بالا - راست";
                else
                    if (toothCode < 25)
                        ToothProp = "پایین - راست";
                    else
                        ToothProp = "پایین - چپ";

            return ToothProp;
        }

        public static Int16 GetToothDirectionInt(Byte toothCode)
        {
            Int16 ToothProp = 0;
            if (toothCode < 9)
                ToothProp = 2;
            else
                if (toothCode < 17)
                    ToothProp = 1;
                else
                    if (toothCode < 25)
                        ToothProp = 4;
                    else
                        ToothProp = 3;

            return ToothProp;
        }

        public static string GetToothNumberString(byte toothCode, Int16 treatmentArea, string normalNumberString)
        {
            switch (treatmentArea)
            {
                case (int)TreatmentArea.Maxillary:
                    return "UP";
                    break;
                case (int)TreatmentArea.Mandibular:
                    return "Low";
                    break;
                case (int)TreatmentArea.Quadrant:
                    switch ((Int16)GetToothDirectionInt((byte)toothCode))
                    {
                        case 1:
                            return "UR";
                            break;
                        case 2:
                            return "UL";
                            break;
                        case 3:
                            return "LL";
                            break;
                        case 4:
                            return "LR";
                            break;
                        default:
                            return "";
                            break;
                    }
                    break;
                case (int)TreatmentArea.Mouth:
                    return "";
                    break;
                default:
                    return normalNumberString;
                    break;
            }

        }

        //public static string GetToothNumber(Int16 number)
        // {
        //     string ToothProp = string.Empty;

        //     switch (number)
        //     {
        //         case 9:
        //             ToothProp = "A";
        //             break;
        //         case 10:
        //             ToothProp = "B";
        //             break;
        //         case 11:
        //             ToothProp = "C";
        //             break;
        //         case 12:
        //             ToothProp = "D";
        //             break;
        //         case 13:
        //             ToothProp = "E";
        //             break;
        //         default:
        //             ToothProp = number.ToString();
        //             break;
        //     }
        //     return ToothProp;
        // }

        public static Dictionary<int, TreatmentDrawType> DrawTypeList()
        {
            int i = 0;
            Dictionary<int, TreatmentDrawType> _drawTypeList = new Dictionary<int, TreatmentDrawType>();
            foreach (TreatmentDrawType tdt in Enum.GetValues(typeof(TreatmentDrawType)))
            {
                _drawTypeList.Add(i, tdt);
                i = i + 1;
            }
            return _drawTypeList;
        }

        public static Stream GetResource(string resourceName)
        {
            Stream stream = null;
            try
            {
                Assembly asm = Assembly.GetExecutingAssembly();
                stream = asm.GetManifestResourceStream("ToolBoxTest.Resources." + resourceName);
            }
            catch (Exception)
            {
                stream = null;
            }
            return stream;
        }

        public static Image GetImage(string resouceName)
        {
            Image image = null;
            Stream stream = null;
            try
            {
                stream = GetResource("Images." + resouceName);
                image = Image.FromStream(stream);
            }
            catch (Exception)
            {
                image = null;
            }
            return image;
        }

        public static ImageList CreateImageListFromImage(Image image, Size size, Color transparentColor)
        {
            ImageList imgList = null;
            Rectangle rImage = Rectangle.Empty;
            Rectangle rBmp = Rectangle.Empty;
            Graphics gmp = null;
            Bitmap bmp = null;
            int count = 0;
            int index = 0;

            try
            {
                imgList = new ImageList();

                rImage.Size = size;
                rBmp.Size = size;
                count = image.Width / size.Width;

                imgList.ImageSize = size;

                for (index = 0; index < count; index++)
                {
                    bmp = new Bitmap(size.Width, size.Height);
                    gmp = Graphics.FromImage(bmp);

                    gmp.DrawImage(image, rBmp, rImage, GraphicsUnit.Pixel);
                    gmp.Dispose();

                    imgList.Images.Add(bmp);
                    rImage.Offset(size.Width, 0);
                }

                imgList.TransparentColor = transparentColor;
            }
            catch
            {
                imgList = null;
            }
            return imgList;
        }

        public static bool CheckPermission(int id, User sUser)
        {
            bool isPermit = false;
            if (sUser == null || sUser.LForms == null)
                return false;
            foreach (Forms frm in sUser.LForms)
            {
                if (frm.FormID == id)
                    isPermit = true;
            }
            if (!isPermit)
                MessageBox.Show("!محدودیت در دسترسی به این صفحه", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            return isPermit;
        }

        public static string GetMessage(int mCode)
        {
            switch (mCode)
            {
                case 0: return string.Empty;
                case 1: return "تصاویر انتخاب شده حذف خواهند شد آیا مطمئن هستید؟";
                case 2: return "بارگزاری مجدد";
                case 3: return "حذف";
                case 4: return "جدید";
                case 5: return "نام کاربری را وارد کنید";
                case 6: return "کلمه عبور را وارد کنید";
                case 7: return "ثبت";
                case 8: return "تمامی دسته بندی ها";
                case 9: return "ویرایش";
                case 10: return "کد درمان راوارد کنید";
                case 11: return "نام فارسی درمان راوارد کنید";
                case 12: return "نام لاتین درمان راوارد کنید";
                case 13: return " تاریخ اعمال درمان راوارد کنید";
            }

            return "";
        }


        public static BindingList<T> CloneList<T>(BindingList<T> oldList)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            MemoryStream stream = new MemoryStream();
            formatter.Serialize(stream, oldList);
            stream.Position = 0;
            return (BindingList<T>)formatter.Deserialize(stream);
        }

        public static string GetSHandBookName(int code, bool multiSelect)
        {
            switch (code)
            {
                case 1:
                    return "کارمندی";

                case 2:
                    if (multiSelect)
                        return "خویش فرما و ایرانیان";
                    return "خویش فرما";

                case 3:
                    return "سایر اقشار";

                case 4:
                    return "روستایی";

                case 5:
                    return "ایرانیان";
            }
            return "";
        }

        public static string GetEnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(
                typeof(DescriptionAttribute),
                false);

            if (attributes != null &&
                attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }

        public static bool LogError(Exception ex, string errorNumber)
        {
            FileStream stream = null;
            try
            {
                string path = Application.StartupPath + @"\Log.txt";
                stream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                try
                {
                    stream.Close();
                }
                catch
                {
                }
                string str2 = string.Empty;
                str2 = PersianDateConverter.ToPersianDate(DateTime.Now).ToString();
                StreamWriter writer = new StreamWriter(path, true);
                writer.WriteLine("Time:");
                writer.WriteLine(str2);
                writer.WriteLine("Error  " + errorNumber + ":");
                writer.WriteLine(ex.Message);
                writer.WriteLine();
                try
                {
                    writer.Close();
                }
                catch
                {
                }
                return true;
            }
            catch (Exception exc)
            {
                LogError(exc, "ErrorDll.Upload1");
                try
                {
                    stream.Close();
                }
                catch
                {
                }
                return false;
            }
        }

        public static void ClearErrorProvider(TextBox senderControl, ErrorProvider errorProvider, bool setZero)
        {
            if (setZero)
            {
                if (senderControl.Text.Trim() == "")
                    senderControl.Text = "0";
                errorProvider.Clear();
            }
            else
                if (senderControl.Text.Trim() != "")
                    errorProvider.Clear();

        }
   //

    }
}
