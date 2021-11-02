using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DentiNovin.Common;
using DentiNovin.DataAccess;
using System.Data;

namespace DentiNovin.BusinessLogic
{
    public class AppointmentBLL
    {

        private int _doctorID;
        public int DoctorID
        {
            get { return _doctorID; }
            set { _doctorID = value; }
        }

        private Group _oGroup;
        public Group oGroup
        {
            get { return _oGroup; }
            set { _oGroup = value; }
        }

        private Patient _oPatient;
        public Patient OPatient
        {
            get { return _oPatient; }
            set { _oPatient = value; }
        }

        private Appointment _appointment;
        public Appointment Appointment
        {
            get { return _appointment; }
            set { _appointment = value; }
        }

        private AppointmentDAL _bAppointmentFormDAL;
        public AppointmentDAL BAppointmentFormDAL
        {
            get
            {
                if (_bAppointmentFormDAL == null)
                    _bAppointmentFormDAL = new AppointmentDAL();
                return _bAppointmentFormDAL;
            }
            set
            {
                _bAppointmentFormDAL = value;
            }
        }


        public void GetGroup(string SelectedDate)
        {
            BAppointmentFormDAL.oGroup = this.oGroup;
            BAppointmentFormDAL.GetGroup(SelectedDate);
        }

        public DataSet GetDoctorGroup(int DoctorID)
        {
            return BAppointmentFormDAL.GetDoctorGroup(DoctorID);
        }

        public DataSet GetAppointment(string SelectedDate)
        {
            //DataSet oDataSet=new DataSet();
            BAppointmentFormDAL.oGroup = this.oGroup;
            return BAppointmentFormDAL.GetAppointment(SelectedDate);
        }

        public DataSet GetPatientAppointment(int PatientID)
        {
            return BAppointmentFormDAL.GetPatientAppointment(PatientID);
        }

        public void GetPatient()
        {
            BAppointmentFormDAL.OPatient = this.OPatient;
            BAppointmentFormDAL.GetPatient();
        }

        public void InsertNewAppointment()
        {
           BAppointmentFormDAL.Appointment = this.Appointment;
            BAppointmentFormDAL.InsertNewAppointment();
        }

        public void DeleteAppointment(Int64 RecordID, int deleteType)
        {
            BAppointmentFormDAL.DeleteAppointment(RecordID, deleteType);
        }

        public DataSet GetVisitsReportList(int patientID, int doctorID, string startRangeDate, string endRangeDate)
        {
          return  BAppointmentFormDAL.GetVisitsReportList(patientID, doctorID, startRangeDate, endRangeDate);
        }

        public void SetAppointmentStatus(Int64 RecordID, int statusType)
        {
            BAppointmentFormDAL.SetAppointmentStatus(RecordID, statusType);
        }
    }
}
