using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DentiNovin.Common.SerialMaker;

namespace DentiNovin.BusinessLogic
{
   public abstract class BaseBLL
    {
       public  abstract void SaveObject();
       
       public abstract void EditObject();
      
       public abstract  void DeleteObject();

       public abstract void DeleteObject<T>(T recID);

       public abstract void SelectObject();
    }
}
