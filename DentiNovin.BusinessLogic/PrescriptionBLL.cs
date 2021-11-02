using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DentiNovin.Common;
using DentiNovin.DataAccess;
using System.Data;

namespace DentiNovin.BusinessLogic
{
    public class PrescriptionBLL : BaseBLL
    {
        private Patient _oPatient;
        public Patient oPatient
        {
            get { return _oPatient; }
            set { _oPatient = value; }
        }

        private Prescription _oPrescription;
        public Prescription OPrescription
        {
            get
            {
                return _oPrescription;
            }
            set { _oPrescription = value; }
        }

        private PrescriptionDAL _bPrescriptionDAL;
        public PrescriptionDAL BPrescriptionDAL
        {
            get
            {
                if (_bPrescriptionDAL == null)
                    _bPrescriptionDAL = new PrescriptionDAL();
                return _bPrescriptionDAL;
            }
            set
            {
                _bPrescriptionDAL = value;
            }
        }

        public void SelectPatient(string assuranceCode)
        {
            BPrescriptionDAL.oPatient = oPatient;
            BPrescriptionDAL.SelectPatient(assuranceCode);

        }
       
        public override void SaveObject()
        {
            BPrescriptionDAL.OPrescription = this.OPrescription;
            BPrescriptionDAL.Insert();
        }

        public override void EditObject()
        {
            BPrescriptionDAL.OPrescription = this.OPrescription;
            BPrescriptionDAL.Update();
        }

        public override void DeleteObject()
        {
            throw new NotImplementedException();
        }

        public override void SelectObject()
        {
            throw new NotImplementedException();
        }

        public DataSet GetPrescriptionList(int year, int month, int assuranceID, int doctorID)
        {
            return BPrescriptionDAL.GetPrescriptionList(year,month,assuranceID, doctorID);
        }

        public DataSet GetPrescritionGroupList()
        {
            return BPrescriptionDAL.GetPrescritionGroupList();
        }

        public override void DeleteObject<T>(T recID)
        {
            BPrescriptionDAL.Delete<T>(recID);
        }

        public DataSet GetKhPrescriptionVisitServiceMixedList(Doctor doctor, int year, int month, int assuranceID, int visitOrganPercent)
        {
            return BPrescriptionDAL.GetKhPrescriptionVisitServiceMixedList(doctor, year, month, assuranceID, visitOrganPercent);
        }

        public DataSet GetKhPrescriptionServiceMixedList(Doctor doctor, int year, int month, int assuranceID, int organPercent)
        {
            return BPrescriptionDAL.GetKhPrescriptionServiceMixedList(doctor, year, month, assuranceID, organPercent);
        }

        public DataSet GetMoPrescriptionVisitServiceMixedList(Doctor doctor, int year, int month, int assuranceID, int visitOrganPercent)
        {
            return BPrescriptionDAL.GetMoPrescriptionVisitServiceMixedList(doctor, year, month, assuranceID, visitOrganPercent);
        }

        public DataSet GetMoPrescriptionServiceMixedList(Doctor doctor, int year, int month, int assuranceID, int organPercent)
        {
            return BPrescriptionDAL.GetMoPrescriptionServiceMixedList(doctor, year, month, assuranceID, organPercent);
        }

        public Int64 GetVisitServiceID(int headID, int assuranceID)
        {
            return BPrescriptionDAL.GetVisitServiceID(headID, assuranceID);
        }
    }
}
