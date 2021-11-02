using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DentiNovin.DataAccess;
using System.Data;

namespace DentiNovin.BusinessLogic
{
   public class AssuranceBLL
    {
       private AssuranceDAL _bAssuranceDAL;
       public AssuranceDAL BAssuranceDAL
        {
            get
            {
                if (_bAssuranceDAL == null)
                    _bAssuranceDAL = new AssuranceDAL();
                return _bAssuranceDAL;
            }
            set
            {
                _bAssuranceDAL = value;
            }
        }

       public DataSet GetAssuranceList(bool showForPrescription)
       {
         return  BAssuranceDAL.GetAssuranceList(showForPrescription);
       }
   }
}
