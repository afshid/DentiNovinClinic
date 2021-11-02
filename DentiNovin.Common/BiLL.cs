using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace DentiNovin.Common
{
    public class Bill
    {
        private Int64 _billID;
        public Int64 BillID
        {
            get { return _billID; }
            set { _billID = value; }
        }

        private int _patientID;
        public int PatientID
        {
            get { return _patientID; }
            set { _patientID = value; }
        }


        private decimal _totalFees;
        public decimal TotalFees
        {
            get { return _totalFees; }
            set { _totalFees = value; }
        }

        private decimal _feesReceived;
        public decimal FeesReceived
        {
            get { return _feesReceived; }
            set { _feesReceived = value; }
        }

        private decimal _feesPayable;
        public decimal FeesPayable
        {
            get { return _feesPayable; }
            set { _feesPayable = value; }
        }
       
        private string _dateOfRegister;
        public string DateOfRegister
        {
            get { return _dateOfRegister; }
            set { _dateOfRegister = value; }
        }

        private ArrayList _billTreatmentList;
        public ArrayList BillTreatmentList
        {
            get
            {
                if (_billTreatmentList == null)
                    _billTreatmentList = new ArrayList();
                return _billTreatmentList; }
            set { _billTreatmentList = value; }
        }

        private BindingList<BillDetails> _billDetailsList;
        public BindingList<BillDetails> BillDetailsList
        {
            get
            {
                if (_billDetailsList == null)
                    _billDetailsList = new BindingList<BillDetails>();
                return _billDetailsList;
            }
            set { _billDetailsList = value; }
        }
    }

}
