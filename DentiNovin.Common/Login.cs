using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DentiNovin.Common
{
  public class Login
    {
        private Int32 _loginID;
        public Int32 LoginID
        {
            get { return _loginID; }
            set { _loginID = value; }
        }

        private String _userName;
        public String UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }

        private String _password;
        public String Password
        {
            get { return _password; }
            set { _password = value; }
        }

        private DateTime _registerDate;
        public DateTime RegisterDate
        {
            get { return _registerDate; }
            set { _registerDate = value; }
        }


    }
}
