using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace DentiNovin.Common
{
    
    public class Tooth :IEquatable<Tooth>

    {
        public Int16 Code { get; set; }

        public int PermanentNumber { get; set; }

        public string   PrimaryNumber { get; set; }

        public int Direction { get; set; }

        public ToothRootType RootType { get; set; }

        public ToothType Type { get; set; }

        public Tooth(Int16 ToothCode,int ToothDirection, ToothRootType ToothRootType)
        {
            this.Code = ToothCode;this.Direction = ToothDirection; this.RootType = ToothRootType;
        }
       
        public Tooth()
        {
        }

        public override bool Equals(object obj)
        {
            Tooth other = (Tooth)obj;
            //return (other != null && other.Number == this.Number && other.Direction == this.Direction && other.Code == this.Code && other.Type == this.Type);
            return (other != null && other.Code == this.Code && other.Type == this.Type);

        }


        #region IEquatable<Tooth> Members

        public bool Equals(Tooth other)
        {
            //return (other != null && other.Number == this.Number && other.Direction == this.Direction && other.Code == this.Code && other.Type == this.Type);
            return (other != null && other.Code == this.Code && other.Type == this.Type);

        }

        #endregion
    }
}
