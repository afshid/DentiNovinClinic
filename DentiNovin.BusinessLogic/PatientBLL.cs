using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DentiNovin.Common;
using DentiNovin.DataAccess;
using System.Data;
using DentiNovin.Common.SerialMaker;

namespace DentiNovin.BusinessLogic
{
    public class PatientBLL : BaseBLL
    {
        
        private PatientDAL _bPatientDAL;
        public PatientDAL BPatientDAL
        {
            get
            {
                if (_bPatientDAL == null)
                    _bPatientDAL = new PatientDAL();
                return _bPatientDAL;
            }
            set
            {
                _bPatientDAL = value;
            }
        }

        private Patient _oPatient;
        public Patient oPatient
        {
            get { return _oPatient; }
            set { _oPatient = value; }
        }

        public SerialMaker.RunTypes RunType { get; set; }

        public void PatientFastInsert()
        {
            BPatientDAL.RunType = this.RunType;
            BPatientDAL.oPatient = this.oPatient;
            BPatientDAL.PatientFastInsert();
        }

        public DataSet SelectPatientListByField(int fileNumber, string patientLastname, bool showAllField)
        {
            return BPatientDAL.SelectPatientListByField(fileNumber, patientLastname,showAllField);
        }

        public int GetLastFileNumber()
        {
            return BPatientDAL.GetLastFileNumber();
        }

        public override void SaveObject()
        {
            BPatientDAL.oPatient = this.oPatient;
            BPatientDAL.RunType = this.RunType;
            BPatientDAL.PatientInsert();
        }

        public override void EditObject()
        {
            BPatientDAL.oPatient = this.oPatient;
            BPatientDAL.PatientEdit();
        }

        public override void SelectObject()
        {

        }

        public void GetPatientByID()
        {
            BPatientDAL.oPatient = this.oPatient;
            BPatientDAL.GetPatientByID();
        }

        public void GetPatientAssuranceList()
        {
            BPatientDAL.oPatient = this.oPatient;
            BPatientDAL.GetPatientAssuranceList();
        }

        public override void DeleteObject<T>(T recID)
        {
            BPatientDAL.Delete<T>(recID);
        }

        public override void DeleteObject()
        {
            throw new NotImplementedException();
        }

        public void DisableAlertForm(int patientID)
        {
            BPatientDAL.DisableAlertForm(patientID);
        }
    }
}
