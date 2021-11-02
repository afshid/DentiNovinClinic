using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DentiNovin.Common
{
    public class Doctor : BaseClass
    {
        private Int32 _DoctorID;
        public Int32 DoctorID
        {
            get { return _DoctorID; }
            set { _DoctorID = value; }
        }


        private String _docName;
        public String Docname
        {
            get { return _docName; }

            set { _docName = value; }

        }
        
        private String _lastName;
        public String LastName
        {
            get { return _lastName; }
            set
            { _lastName = value; }
        }

        public Int16 DoctorKind { get; set; }

        private String _code;
        public String Code
        {
            get { return _code; }
            set
            { _code = value; }
        }

        public string CellPhoneNumber { get; set; }

        public string PhoneNumber { get; set; }

        private string _address;
        public string Address
        {
            get

            { return _address; }
            set { _address = value; }
        }

        public Boolean Active { get; set; }

        public Decimal VisitPrice { get; set; }

        public string IdentificationCodeKhadamat { get; set; }

        public string IdentificationCodeMosallah { get; set; }

        public bool HaveContractWithMosallah { get; set; }

        public bool HaveContractWithKhadamat { get; set; }

        private List<DoctorShift> _lDoctorShift;
        public List<DoctorShift> LDoctorShift
        {

            get
            {
                if (_lDoctorShift == null)
                    _lDoctorShift = new List<DoctorShift>();
                return _lDoctorShift;
            }
            set { _lDoctorShift = value; }

        }
    }
}
