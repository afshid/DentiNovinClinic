using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DentiNovin.Common;
using System.Data;
using DentiNovin.DataAccess;

namespace DentiNovin.BusinessLogic
{
    public class UserAccessBll:BaseBLL
    {

        private User _oUserb;
        public User OUserB
        {
            get { return _oUserb; }
            set { _oUserb = value; }
        }
        private UserAccessDal _bUserAccessDal;
        public UserAccessDal BUserAccessDal
        {
            get
            {
                if (_bUserAccessDal == null)
                    _bUserAccessDal = new UserAccessDal();
                return _bUserAccessDal;
            }
            set
            {
                _bUserAccessDal = value;
            }
        }

        //public void SaveInfo()
        //{
        //    UserAccessDal BUserAccessDal = new UserAccessDal();
        //    BUserAccessDal.OUserD = OUserB;
        //    BUserAccessDal.SaveInfo();
        //}

        public DataSet FillTreeview()
        {
            System.Data.DataSet ds = new DataSet();
            UserAccessDal BUserAccessDal = new UserAccessDal();
            return ds= BUserAccessDal.FillTreeview();
            
        }

        public System.Data.DataSet FillgridUser()
        {
            System.Data.DataSet ds = new System.Data.DataSet();

            UserAccessDal BUserAccessDal = new UserAccessDal();
           return  ds = BUserAccessDal.FillGrid();
            

        }

        //public void DeleteUser(int ORowSelectID)
        //{
        //    UserAccessDal BUserAccessDal = new UserAccessDal();
        //    BUserAccessDal.OUserD = OUserB;
        //    BUserAccessDal.DeleteUser(ORowSelectID);
        //}
        public List<Forms> GetListFormsSelectForUser(int ORowSelectID)
        {
            List<Forms> Lforms = new List<Forms>();
            UserAccessDal BUserAccessDal = new UserAccessDal();
            return Lforms = BUserAccessDal.GetListFormsSelectForUser(ORowSelectID);

          
        }
        //public void EditUser()
        //{

        //    UserAccessDal BUserAccessDal = new UserAccessDal();
        //    BUserAccessDal.OUserD = OUserB;
        //     BUserAccessDal.EditUser();

        //}

        public override void SaveObject()
        {
         
            BUserAccessDal.OUserD = OUserB;
            BUserAccessDal.Insert();
        }

        public override void EditObject()
        {
         
            BUserAccessDal.OUserD = OUserB;
            BUserAccessDal.Update();
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
            BUserAccessDal.Delete(recID);
        }
    }

}
