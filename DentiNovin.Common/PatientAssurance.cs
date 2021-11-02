using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DentiNovin.Common
{[Serializable]
   public class PatientAssurance: ICloneable
    {
        public Int64 PatientAssuranceID { get; set; }

        public int PatientID { get; set; }

        public int AssuranceID { get; set; }

        public string AssuranceName { get; set; }

        public string AssuranceCode { get; set; }
    
        public Int16 HandBookID { get; set; }

        public string ValidityDate { get; set; }

        public int CountUsed { get; set; }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
