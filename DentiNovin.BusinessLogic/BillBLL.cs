using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DentiNovin.Common;
using DentiNovin.DataAccess;
using System.Data;

namespace DentiNovin.BusinessLogic
{
  public  class BillBLL:BaseBLL
    {

      private Bill _BiLLb;
      public Bill BiLLB
        {
            get { return _BiLLb; }
            set { _BiLLb = value; }
        }

      private BillDetails _oBillDetails;
      public BillDetails OBillDetails
      {
          get { return _oBillDetails; }
          set { _oBillDetails = value; }
      }
      private Patient _oPatient;
      public Patient oPatient
      {
          get { return _oPatient; }
          set { _oPatient = value; }
      }
     
      private BillDAL _bBillDal;
      public BillDAL BBillDal
      {
          get
          {
              if (_bBillDal == null)
                  _bBillDal = new BillDAL();
              return _bBillDal;
          }
          set
          {
              _bBillDal = value;
          }
      }

      public DataSet FilldgvBiLL()
      {
          BBillDal.oPatient = this.oPatient;
          return BBillDal.FilldgvBill();
      }

      public DataSet GetBillDetailsList(Int64 billID)
      {
          return BBillDal.GetBillDetailsList(billID);
      }

      public DataSet GetPatientTreatmentList(int PatientID, Int64 billID, int showListMode, bool showPersian)
      {
          return BBillDal.GetPatientTreatmentList(PatientID, billID, showListMode, showPersian);
      }
      
      public void SelectPatient()
      {
          BBillDal.oPatient = oPatient;
          BBillDal.SelectPatient();
      }

      public void SaveBillInfo()
      {
          BBillDal.BiLLD = this.BiLLB;
          BBillDal.InsertBillInfo( );
      }

      public void EditBillInfo()
      {
          BBillDal.BiLLD = BiLLB;
          BBillDal.UpdateBillInfo();
      
      }

      public DataSet GetBillTreatmentList(int patientID, Int64 billID, bool showPersian)
      {
          return BBillDal.GetBillTreatmentList(patientID, billID, showPersian);
      }


      public override void SaveObject()
      {
          throw new NotImplementedException();
      }

      public override void EditObject()
      {
          throw new NotImplementedException();
      }

      public override void DeleteObject()
      {
          throw new NotImplementedException();
      }

      public override void DeleteObject<T>(T recID)
      {
          BBillDal.Delete<T>(recID);
      }

      public override void SelectObject()
      {
          throw new NotImplementedException();
      }

      public DataSet GetBillsReportList(int patientID, int doctorID, string startRangeDate, string endRangeDate, bool isForPatient, bool withBillID)
      {
          return BBillDal.GetBillsReportList( patientID,  doctorID,  startRangeDate,  endRangeDate, isForPatient,  withBillID);
      }
    }
}
