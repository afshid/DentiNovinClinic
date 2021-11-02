using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DentiNovin.Common.DateConvert
{
   public class Utilities
    {
        /// <summary>
        /// Adds a preceding zero to single day or months
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public static string toDouble(int i)
        {
            if (i > 9)
            {
                return i.ToString();
            }
            else
            {
                return "0" + i.ToString();
            }
        }

    }
}
