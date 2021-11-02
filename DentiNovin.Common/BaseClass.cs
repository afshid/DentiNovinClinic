using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace DentiNovin.Common
{
   public class BaseClass
    {
        private Boolean _rowEffected;
        public Boolean RowEffected
        {
            get { return _rowEffected; }
            set { _rowEffected = value; }
        }

        private String _actionMessage;
        public String ActionMessage
        {
            get { return _actionMessage; }
            set { _actionMessage = value; }
        }

    }

   [Serializable]
   public class TrialException:Exception
   {
       public TrialException()
        : base() { }
    
    public TrialException(string message)
        : base(message) { }
    
    public TrialException(string format, params object[] args)
        : base(string.Format(format, args)) { }
    
    public TrialException(string message, Exception innerException)
        : base(message, innerException) { }
    
    public TrialException(string format, Exception innerException, params object[] args)
        : base(string.Format(format, args), innerException) { }

    protected TrialException(SerializationInfo info, StreamingContext context)
        : base(info, context) { }
   }
}
