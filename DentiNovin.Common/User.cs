using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DentiNovin.Common
{
    public class User
    {
        private Int32 _userID;
        public Int32 UserID
        {
            get { return _userID; }
            set { _userID = value; }
        }

        private String _fullName;
        public String FullName
        {
            get { return _fullName; }
            set { _fullName = value; }
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
        
        private List<Forms> _lForms;
        public List<Forms> LForms
        {
            get
            {
                return _lForms;
            }
            set { _lForms = value; }
        }

        public Boolean Active { get; set; }

        public string  DateOfRegister { get; set; }

    }
}
