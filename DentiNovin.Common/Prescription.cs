using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DentiNovin.Common
{
    public class Prescription:BaseClass
    {
        public Int64 PrescriptionID { get; set; }

        public Int32 DoctorID { get; set; }

        public Int32 PatientID { get; set; }

        public string AssuranceCode { get; set; }

        public int AssuranceID { get; set; }

        //public string PrescriptionDate { get; set; }

        public string ActionDate { get; set; }

        public string ValidityDate { get; set; }

        public bool IsReferenced { get; set; }

        public string ReferencedDate { get; set; }
        
        public decimal PatientPayment { get; set; }

        public decimal KCoeff { get; set; }

        public Decimal VisitPrice { get; set; }

        public int PageNumber { get; set; }

        public string Year { get; set; }

        public Int16 Month { get; set; }

        private BindingList<AssuranceService> _assuranceServiceList;
        public BindingList<AssuranceService> AssuranceServiceList
        {
            get
            {
                if (_assuranceServiceList == null)
                    _assuranceServiceList = new BindingList<AssuranceService>();
                return _assuranceServiceList;
            }
            set { _assuranceServiceList = value; }
        }

    }

    public class AssuranceReportHeader : BaseClass
    {
        public AssuranceReportHeader(string handBookType, string doctorFullName, string monthName, string year)
        {
            this.HandBookType = handBookType;
            this.DoctorFullName = doctorFullName;
            this.MonthName = monthName;
            this.Year = year;
        }
        public string  HandBookType { get; set; }
        public string  DoctorFullName { get; set; }
        public string  MonthName { get; set; }
        public string Year { get; set; }
    }
}
