using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DentiClinic.DataAccess;
using System.Data;

namespace DentiClinic.BusinessLogic
{
   public class PatientDossierBLL
    {
       private PatientDossierDAL _bPatientDossierDAL;
       public PatientDossierDAL BPatientDossierDAL
        {
            get
            {
                if (_bPatientDossierDAL == null)
                    _bPatientDossierDAL = new PatientDossierDAL();
                return _bPatientDossierDAL;
            }
            set
            {
                _bPatientDossierDAL = value;
            }
        }


       public DataSet GetAccomplishedTreatmentList(int PatientID)
       {
         return GetAccomplishedTreatmentList(PatientID, 0,0);
       }

       public DataSet GetAccomplishedTreatmentList(int PatientID, int ToothNumber,int ToothDirection)
       {
           return BPatientDossierDAL.GetAccomplishedTreatmentList(PatientID, ToothNumber,ToothDirection);
       }
   }
}
