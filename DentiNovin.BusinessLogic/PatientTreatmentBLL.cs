using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DentiNovin.DataAccess;
using DentiNovin.Common;
using DentiNovin.Common.SerialMaker;

namespace DentiNovin.BusinessLogic
{
   public class PatientTreatmentBLL
    {
       private PatientTreatmentDAL _bPatientTreatmentDAL;
       public PatientTreatmentDAL BPatientTreatmentDAL
       {
           get
           {
               if (_bPatientTreatmentDAL == null)
                   _bPatientTreatmentDAL = new PatientTreatmentDAL();
               return _bPatientTreatmentDAL;
           }
           set
           {
               _bPatientTreatmentDAL = value;
           }
       }

       public SerialMaker.RunTypes RunType { get; set; }

       private PatientTreatment _oPatientTreatment;
       public PatientTreatment oPatientTreatment
       {
           get { return _oPatientTreatment; }
           set { _oPatientTreatment = value; }
       }

       private XRayImage _oXRayImage;
       public XRayImage oXRayImage
       {
           get { return _oXRayImage; }
           set { _oXRayImage = value; }
       }

       private PatientToothType _oPatientToothType;
       public PatientToothType oPatientToothType
       {
           get
           {
               return _oPatientToothType;
           }
           set
           {
               _oPatientToothType = value;
           }

       }

       private Treatment _oTreatment;
       public Treatment oTreatment
       {
           get
           {
               return _oTreatment;
           }
           set { _oTreatment = value; }
       }

       public void InsertNewPatientTreatment()
       {
           BPatientTreatmentDAL.RunType = this.RunType;
           BPatientTreatmentDAL.oPatientTreatment = oPatientTreatment;
           BPatientTreatmentDAL.InsertNewPatientTreatment();
       }

       public void UpdatePatientTreatment()
       {
           BPatientTreatmentDAL.oPatientTreatment = oPatientTreatment;
           BPatientTreatmentDAL.UpdatePatientTreatment();
       }

       public void UpdatePatientTreatmentDetails()
       {
           BPatientTreatmentDAL.oPatientTreatment = oPatientTreatment;
           BPatientTreatmentDAL.UpdatePatientTreatmentDetails();
       }
       public DataSet GetPatientTreatmentList(Int64 AppointmentID, int PatientID, int[] status, bool showPersian, Int16 toothCode)
       {
           return BPatientTreatmentDAL.GetPatientTreatmentList(AppointmentID, PatientID, status, showPersian, toothCode);
       }
      
       public void DeletePatientTreatment()
       {
           BPatientTreatmentDAL.oPatientTreatment = oPatientTreatment;
           BPatientTreatmentDAL.DeletePatientTreatment();
       }

       public void ChangePatientTreatmentStatus(Int64 patientTreatmentID, int newStatus)
       {
           BPatientTreatmentDAL.ChangePatientTreatmentStatus(patientTreatmentID, newStatus);
       }

       public void UpdatePatientToothType()
       {
           BPatientTreatmentDAL.oPatientToothType =this.oPatientToothType;
           BPatientTreatmentDAL.UpdatePatientToothType();
       }

       public DataSet GetPatientToothTypeList(int PatientID)
       {
           return BPatientTreatmentDAL.GetPatientToothTypeList(PatientID);
       }
       public DataSet GetXRayList(int patientID)
       {
           return BPatientTreatmentDAL.GetXRayList(patientID);
       }//InsertXRayImage()

       public void InsertXRayImage()
       {
           BPatientTreatmentDAL.oXRayImage = this.oXRayImage;
           BPatientTreatmentDAL.InsertXRayImage();
       }

       public void DeleteXRayImages(string rIDList)
       {
           BPatientTreatmentDAL.DeleteXRayImages(rIDList);
       }

       public DataSet GetTreatmentsReportList(int patientID, int doctorID, string startRangeDate, string endRangeDate, bool showPersian)
       {
           return BPatientTreatmentDAL.GetTreatmentsReportList(patientID, doctorID, startRangeDate, endRangeDate, showPersian);
       }
   }
}
