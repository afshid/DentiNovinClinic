using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DentiNovin.Common
{
    public class VisitNode : BaseClass
    {
        public int PatientID { get; set; }

        public string PatientFullName { get; set; }

        public Int64 AppointmentID { get; set; }

        // public int GroupID { get; set; }
        public int Status { get; set; }

        public int DayNumber { get; set; }

        public int TimeIndex { get; set; }

        public string VisitDate { get; set; }

        public TimeSpan StartTime { get; set; }

        public VisitNode(int patientID, string patientFullName, Int64 appointmentID, int dayNumber, int timeIndex, string visitDate, TimeSpan startTime, int status)
        {
            this.PatientID = patientID;
            this.PatientFullName = patientFullName;
            this.AppointmentID = appointmentID;
            this.DayNumber = dayNumber;
            this.TimeIndex = timeIndex;
            this.VisitDate = visitDate;
            this.StartTime = startTime;
            this.Status = status;
        }
       
        public override string ToString()
        {
            return  this.PatientFullName ;
        }

    }
}
