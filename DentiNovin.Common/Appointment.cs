using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DentiNovin.Common
{
    public class Appointment : BaseClass
    {
        public Int64 AppointmentID { get; set; }

       public int PatientID { get; set; }

       public int GroupID { get; set; }

       public int DoctorID { get; set; }

       public string VisitDate { get; set; }

       public int YearNumber { get; set; }

       public int MonthNumber { get; set; }

       public int DayNumber { get; set; }

       public TimeSpan StartTime { get; set; }

       public int Index { get; set; }

       public int Status { get; set; }

    }
}
