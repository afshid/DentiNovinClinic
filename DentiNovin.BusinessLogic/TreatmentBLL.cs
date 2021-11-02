using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DentiNovin.DataAccess;
using DentiNovin.Common;
using System.Data;

namespace DentiNovin.BusinessLogic
{
    public class TreatmentBLL : BaseBLL
    {
        private TreatmentDAL _bTreatmentDAL;
        public TreatmentDAL BTreatmentDAL
        {
            get
            {
                if (_bTreatmentDAL == null)
                    _bTreatmentDAL = new TreatmentDAL();
                return _bTreatmentDAL;
            }
            set
            {
                _bTreatmentDAL = value;
            }
        }

        private Treatment _oTreatment;
        public Treatment oTreatment
        {
            get { return _oTreatment; }
            set { _oTreatment = value; }
        }

        private AssuranceService _oAssuranceService;
        public AssuranceService OAssuranceService
        {
            get
            {
                return _oAssuranceService;
            }
            set { _oAssuranceService = value; }
        }

        public DataSet GetTreatmentClassList()
        {
            return BTreatmentDAL.GetTreatmentClassList();
        }

        public DataSet GetTreatmentServiceList(ServiceFilterType sft, string currentDate, int treatmentClassID, string treatmentCode, string treatmentName, bool showPersian)
        {
            return BTreatmentDAL.GetTreatmentServiceList(sft, currentDate, treatmentClassID, treatmentCode, treatmentName, showPersian);
        }

        public DataSet GetTreatmentServiceListForTreatmentBox()
        {
            return BTreatmentDAL.GetTreatmentServiceListForTreatmentBox();
        }


        public DataSet GetRelatedTreatmentServiceList(int serviceID)
        {
            return BTreatmentDAL.GetRelatedTreatmentServiceList(serviceID);
        }

        public void TreatmentServiceInsert()
        {
            BTreatmentDAL.oTreatment = this.oTreatment;
            BTreatmentDAL.TreatmentServiceInsert();
        }

        public void TreatmentServiceEdit()
        {
            BTreatmentDAL.oTreatment = this.oTreatment;
            BTreatmentDAL.TreatmentServiceEdit();
        }

        public void TreatmentUsedCountIncrease()
        {
            BTreatmentDAL.oTreatment = this.oTreatment;
            BTreatmentDAL.TreatmentUsedCountIncrease();
        }

        public void AssuranceServiceDetailsUsedCountIncrease(Int64 serviceID)
        {
            BTreatmentDAL.AssuranceServiceDetailsUsedCountIncrease(serviceID);
        }

        public void AssuranceServiceHeaderUsedCountIncrease(int serviceHeaderID)
        {
            BTreatmentDAL.AssuranceServiceHeaderUsedCountIncrease(serviceHeaderID);
        }

        public void TreatmentServiceShowingStatusChange(int treatmentServiceID, bool showingStatus)
        {
            BTreatmentDAL.TreatmentServiceShowingStatusChange(treatmentServiceID, showingStatus);
        }

        public void TreatmentServiceCountReset(int treatmentServiceID)
        {
            BTreatmentDAL.TreatmentServiceCountReset(treatmentServiceID);
        }

        public DataSet GetAssuranceServiceList(string serviceCode, string serviceName, int assuranceID, int serviceHeaderID, decimal selectedOrganKCoeff, bool showAll)
        {
            return BTreatmentDAL.GetAssuranceServiceList(serviceCode, serviceName, assuranceID, serviceHeaderID, selectedOrganKCoeff, showAll);
        }

        public DataSet GetServiceHeaderList(int assuranceID, bool isVisible)
        {
            return BTreatmentDAL.GetServiceHeaderList(assuranceID, isVisible);
        }

        public void DeleteAssuranceService(Int64 serviceID)
        {
            BTreatmentDAL.DeleteAssuranceService(serviceID);
        }

        public void SaveAssuranceService()
        {
            BTreatmentDAL.OAssuranceService = this.OAssuranceService;
            BTreatmentDAL.InsertAssuranceService();
        }
        public void EditAssuranceService()
        {
            BTreatmentDAL.OAssuranceService = this.OAssuranceService;
            BTreatmentDAL.UpdateAssuranceService();
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
            BTreatmentDAL.Delete(recID);
        }

        public override void SelectObject()
        {
            throw new NotImplementedException();
        }
    }
}
