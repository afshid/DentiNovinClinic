using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DentiNovin.Common.DateConvert
{
    public class InvalidPersianDateException : Exception
    {
        public InvalidPersianDateException()
            : base()
        {
        }

        public InvalidPersianDateException(string message)
            : base(message)
        {
        }
    }
}
