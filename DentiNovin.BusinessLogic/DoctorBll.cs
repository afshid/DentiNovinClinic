using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DentiNovin.Common;
using DentiNovin.DataAccess;
using System.Data;

namespace DentiNovin.BusinessLogic
{
    public class DoctorBll : BaseBLL
    {
        private Doctor _doctorB;
        public Doctor DoctorB
        {
            get { return _doctorB; }
            set { _doctorB = value; }
        }

        private DoctorDal _bDoctorDALL;
        public DoctorDal BDoctorDALL
        {
            get
            {
                if (_bDoctorDALL == null)
                    _bDoctorDALL = new DoctorDal();
                return _bDoctorDALL;
            }
            set
            {
                _bDoctorDALL = value;
            }
        }

        public System.Data.DataSet FillGroupCheckBoxList()
        {
            return BDoctorDALL.FillGroupCheckBoxList();
        }

        public System.Data.DataSet GetDoctorList(bool showOnlyActive)
        {
            return BDoctorDALL.GetDoctorList(showOnlyActive);
        }

        public List<DoctorShift> GetListGroupSelectForDoc(int ORowSelectID)
        {
            BDoctorDALL.DoctorD = this.DoctorB;
            return BDoctorDALL.GetListGroupSelectForDoc(ORowSelectID);
        }

        public override void SaveObject()
        {
            BDoctorDALL.DoctorD = this.DoctorB;
            BDoctorDALL.Insert();
        }

        public override void EditObject()
        {
            BDoctorDALL.DoctorD = this.DoctorB;
            BDoctorDALL.Update();
        }

        public override void DeleteObject()
        {
        }

        public override void SelectObject()
        {
            throw new NotImplementedException();
        }

        public override void DeleteObject<T>(T recID)
        {
            BDoctorDALL.Delete(recID);

        }
    }
}
