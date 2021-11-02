using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DentiNovin.Common
{
   public class Tariff:BaseClass
    {
       public int TariffID { get; set; }

       public int TreatmentID { get; set; }

       public Decimal TarrifWithoutAssurance { get; set; }

       public Decimal TarrifWithAssurance { get; set; }

       public string StartActiveDate { get; set; }

    }
}
