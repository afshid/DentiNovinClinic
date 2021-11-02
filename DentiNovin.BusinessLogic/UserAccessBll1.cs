using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DentiClinic.Common;
using System.Data;
using DentiClinic.DataAccess;

namespace DentiClinic.BusinessLogic
{
    public class UserAccessBll1
    {

        private User _oUserb;
        public User OUserB
        {
            get { return _oUserb; }
            set { _oUserb = value; }
        }
        public void SaveInfo()
        {
            UserAccessDal1 aUserAccessDal = new UserAccessDal1();
            aUserAccessDal.OUserD = OUserB;
            aUserAccessDal.SaveInfo();
        }

        public DataSet FillTreeview()
        {
            System.Data.DataSet ds = new DataSet();
            UserAccessDal1 aUserAccessDal = new UserAccessDal1();
            ds = aUserAccessDal.FillTreeview();
            return ds;
        }

        public System.Data.DataSet FillgridUser()
        {
            System.Data.DataSet ds = new System.Data.DataSet();

            UserAccessDal1 aUserAccessDal = new UserAccessDal1();
            ds = aUserAccessDal.FillgridUser();
            return ds;

        }

        public void DeleteUser(int ORowSelectID)
        {
            UserAccessDal1 aUserAccessDal = new UserAccessDal1();
            aUserAccessDal.OUserD = OUserB;
            aUserAccessDal.DeleteUser(ORowSelectID);
        }
        public List<Forms> GetListFormsSelectForUser(int ORowSelectID)
        {
            List<Forms> Lforms = new List<Forms>();
            UserAccessDal1 aUserAccessDal = new UserAccessDal1();
            Lforms = aUserAccessDal.GetListFormsSelectForUser(ORowSelectID);
           return Lforms;
        }
        public void EditUser()
        {

            UserAccessDal1 aUserAccessDal = new UserAccessDal1();
            aUserAccessDal.OUserD = OUserB;
             aUserAccessDal.EditUser();

        }

        public List<Forms>  DeleteListForms(int ORowSelectIDD)
        {
            List<Forms> Lforms = new List<Forms>();
            UserAccessDal1 aUserAccessDal = new UserAccessDal1();
           aUserAccessDal.OUserD = OUserB;
           Lforms= aUserAccessDal.DeleteListForms(ORowSelectIDD);
           return Lforms;
        }
       
    }

}
