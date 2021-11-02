using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace DentiNovin.Common
{
    [Serializable] 
    public class BillDetails //: ICloneable
    {
        private Int64 _billDetailsID;
        public Int64 BillDetailsID
        {
            get { return _billDetailsID; }
            set { _billDetailsID = value; }
        }

        private Int64 _billID;
        public Int64 BillID
        {
            get { return _billID; }
            set { _billID = value; }
        }

        private decimal _feesReceived;
        public decimal FeesReceived
        {
            get { return _feesReceived; }
            set { _feesReceived = value; }
        }

        private string _dateOfRegister;
        public string DateOfRegister
        {
            get { return _dateOfRegister; }
            set { _dateOfRegister = value; }
        }

        private Int16 _payType;
        public Int16 PayType
        {
            get { return _payType; }
            set { _payType = value; }
        }

        public string PayTypeName { get; set; }


        //public object Clone()
        //{
        //    return this.MemberwiseClone();
        //}
    }
}
