using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DentiNovin.Common;
using DentiNovin.DataAccess;

namespace DentiNovin.BusinessLogic
{
   public class LoginBLL
    {
        private Login _oLoginB;
        public Login OLoginB
        {
            get { return _oLoginB; }
            set { _oLoginB = value; }
        }
        private User _oUserb;
        public User OUserB
        {
            get { return _oUserb; }
            set { _oUserb = value; }
        }

        private LoginDal _bLoginDal;
        public LoginDal BLoginDal
        {
            get
            {
                if (_bLoginDal == null)
                    _bLoginDal = new LoginDal();
                return _bLoginDal;
            }
            set
            {
                _bLoginDal = value;
            }
        }
        public void  SearchtUser()
        {

            BLoginDal.OUserD = this.OUserB;
            BLoginDal.SearchtUser();


        }
    }
}
