using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DentiNovin.Common
{
   public class PatientToothType
    {
        public int PatientToothTypeID { get; set; }

        public int PatientID { get; set; }

        public int ToothCode { get; set; }

        public ToothType ToothType { get; set; }
    }
}
