using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DentiNovin.Common.DateConvert
{
    public class InvalidPersianDateFormatException : Exception
    {
        public InvalidPersianDateFormatException(string message)
            : base(message)
        {
        }

        public InvalidPersianDateFormatException()
            : base()
        {
        }
    }
}
