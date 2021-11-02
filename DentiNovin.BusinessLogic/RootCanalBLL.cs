using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DentiNovin.Common;
using DentiNovin.DataAccess;

namespace DentiNovin.BusinessLogic
{
    public class RootCanalBLL : BaseBLL
    {
        private List<Roots> _lRoots;
        public List<Roots> LRoots
        {
            get
            {
                if (_lRoots == null)
                    _lRoots = new List<Roots>();
                return _lRoots;
            }
            set { _lRoots = value; }
        }

        private RootCanalDAL _bRootCanalDAL;
        public RootCanalDAL BRootCanalDAL
        {
            get
            {
                if (_bRootCanalDAL == null)
                    _bRootCanalDAL = new RootCanalDAL();
                return _bRootCanalDAL;
            }
            set
            {
                _bRootCanalDAL = value;
            }
        }

        public override void SaveObject()
        {
            BRootCanalDAL.LRoots = this.LRoots;
            BRootCanalDAL.Insert();
        }

        public override void EditObject()
        {
            BRootCanalDAL.Update();
        }

        public override void DeleteObject()
        {
            throw new NotImplementedException();
        }

        public void SelectObject(Int64 patientTreatmentID)
        {
            BRootCanalDAL.LRoots = this.LRoots;
           BRootCanalDAL.SelectRoots(patientTreatmentID);
        }

        public override void SelectObject()
        {
            throw new NotImplementedException();
        }

        public override void DeleteObject<T>(T recID)
        {
            throw new NotImplementedException();
        }
    }
}
