using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace DentiNovin.Common
{
    [Serializable]
    public class AssuranceService : ICloneable, IEquatable<AssuranceService>
    {
        public Int64 ServiceID { get; set; }

        public int ServiceHeaderID { get; set; }

        public int AssuranceID { get; set; }

        public string ServiceCode { get; set; }

        public string ServiceName { get; set; }

        public int KPrice { get; set; }

        public decimal ServicePrice { get; set; }

        public bool BaseOnK { get; set; }

        public bool IsVisible { get; set; }

        public decimal PatientShare { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public bool Equals(AssuranceService other)
        {
            return (other != null && other.ServiceID == this.ServiceID);
        }
    }
}
