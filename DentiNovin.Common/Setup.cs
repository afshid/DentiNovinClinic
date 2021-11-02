using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DentiNovin.Common
{
   public class Setup
    {
        public float KCoeff { get; set; }
        public string DateOfActOfCoeff { get; set; }
        public NumberingSystem NumberingSystem { get; set; }
        public bool TreatmentLatinName { get; set; }
        public bool SendSMS { get; set; }
    }
}
