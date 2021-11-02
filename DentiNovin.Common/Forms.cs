using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DentiNovin.Common
{
    public class Forms : BaseClass
    {


       private Int32 _formID;
       public Int32 FormID
        {
            get { return _formID; }
            set { _formID = value; }
        }

       private String _name;
        public String   Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private String _code;
        public String Code
        {
            get { return _code; }
            set { _code = value; }
        }
       
          

    }
}
