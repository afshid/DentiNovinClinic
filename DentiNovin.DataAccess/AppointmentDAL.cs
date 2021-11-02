using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DentiNovin.Common;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DentiNovin.DataAccess
{
    public class AppointmentDAL:BaseDAL
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

        public void GetGroup(string SelectedDate)
        {
            SqlCommand oComand = new SqlCommand();
            oComand.CommandText = "sp_GroupSearchByField";
            oComand.CommandType = System.Data.CommandType.StoredProcedure;
            oComand.Connection = oCon;

            oComand.Parameters.AddWithValue("@GroupCode", oGroup.GroupCode);
            oComand.Parameters.AddWithValue("@StartActiveDate", SelectedDate);
            try
            {

                oCon.Open();
                SqlDataReader oReader = oComand.ExecuteReader();
                if (oReader.Read())
                {
                    oGroup.GroupID = System.Convert.ToInt32(oReader[0]);
                    oGroup.Name = oReader[1].ToString();
                    oGroup.StartTime = new DateTime().Add(TimeSpan.FromTicks((Int64)oReader[2])).TimeOfDay;// System.Convert.ToDateTime(oReader[2]).TimeOfDay;
                    oGroup.EndTime = new DateTime().Add(TimeSpan.FromTicks((Int64)oReader[3])).TimeOfDay;// System.Convert.ToDateTime(oReader[3]).TimeOfDay;
                    if (!(oReader[4] is System.DBNull))
                        oGroup.StartActiveDate = oReader[4].ToString();
                    oGroup.PeriodLength = System.Convert.ToInt32(oReader[5]);
                }

            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {
                if (oCon.State == ConnectionState.Open)
                    oCon.Close();
            }

        }

        public DataSet GetDoctorGroup(int DoctorID)
        {
            try
            {
                DataSet aDataSet = new DataSet();
                SqlCommand oComand = new SqlCommand();
                oComand.CommandText = "sp_GroupDoctorSelectByDoctorID";
                oComand.CommandType = System.Data.CommandType.StoredProcedure;
                oComand.Connection = oCon;

                oComand.Parameters.AddWithValue("@DoctorID", DoctorID);
                SqlDataAdapter oAdapter = new SqlDataAdapter(oComand);
                oAdapter.Fill(aDataSet);
                return aDataSet;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public DataSet GetAppointment(string SelectedDate)
        {
            try
            {
                DataSet aDataSet = new DataSet();
                SqlCommand oComand = new SqlCommand();
                oComand.CommandText = "sp_AppointmentSelectByField";
                oComand.CommandType = System.Data.CommandType.StoredProcedure;
                oComand.Connection = oCon;

                // SelectedDate = SelectedDate.Remove(8) + "01";
                oComand.Parameters.AddWithValue("@DoctorID", oGroup.DoctorID);
                oComand.Parameters.AddWithValue("@GroupID", oGroup.GroupID);
                oComand.Parameters.AddWithValue("@VisitDate", SelectedDate);

                SqlDataAdapter oAdapter = new SqlDataAdapter(oComand);
                oAdapter.Fill(aDataSet);
                return aDataSet;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public void GetPatient()
        {
            SqlCommand oComand = new SqlCommand();
            oComand.CommandText = "sp_PatientSelectByFileNumber";
            oComand.CommandType = System.Data.CommandType.StoredProcedure;
            oComand.Connection = oCon;

            oComand.Parameters.AddWithValue("@FileNumber", OPatient.FileNumber);
            try
            {
                oCon.Open();

                SqlDataReader oReader = oComand.ExecuteReader();

                if (oReader.Read())
                {
                    OPatient.DoctorID = System.Convert.ToInt32(oReader["DoctorID"]);
                    OPatient.PatientID = System.Convert.ToInt32(oReader["PatientID"]);
                    OPatient.FirstName = oReader["FirstName"].ToString();
                    OPatient.LastName = oReader["LastName"].ToString();
                    OPatient.IdentityNumber = oReader["IdentityNumber"].ToString();
                    OPatient.Age = System.Convert.ToInt32(oReader["Age"]);
                    OPatient.Sex = System.Convert.ToBoolean(oReader["Sex"]); ;
                    OPatient.Profession = oReader["Profession"].ToString();
                    OPatient.Telephone = oReader["Telephone"].ToString();
                    OPatient.Address = oReader["Address"].ToString();
                    OPatient.Description = oReader["Description"].ToString();
                    OPatient.Image = null;
                    if (oReader["Image"] != System.DBNull.Value)
                        OPatient.Image = (Byte[])oReader["Image"];
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {
                if (oCon.State == ConnectionState.Open)
                    oCon.Close();
            }
        }

        public DataSet GetPatientAppointment(int PatientID)
        {
            DataSet aDataSet = new DataSet();
            SqlCommand oComand = new SqlCommand();
            oComand.CommandText = "sp_AppointmentSelectByPatientID";
            oComand.CommandType = System.Data.CommandType.StoredProcedure;
            oComand.Connection = oCon;

            oComand.Parameters.AddWithValue("@PatientID", PatientID);
            try
            {
                SqlDataAdapter oAdapter = new SqlDataAdapter(oComand);
                oAdapter.Fill(aDataSet);
                return aDataSet;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public void InsertNewAppointment()
        {
            System.Data.DataSet ds = new System.Data.DataSet();
            SqlCommand oComand = new SqlCommand();
            oComand.CommandText = "sp_AppointmentInsert";
            oComand.CommandType = System.Data.CommandType.StoredProcedure;
            oComand.Connection = oCon;

            try
            {
                oCon.Open();
                oComand.Parameters.Clear();

                oComand.Parameters.AddWithValue("@PatientID", Appointment.PatientID);
                oComand.Parameters.AddWithValue("@GroupID", Appointment.GroupID);
                oComand.Parameters.AddWithValue("@DoctorID", Appointment.DoctorID);
                oComand.Parameters.AddWithValue("@VisitDate", Appointment.VisitDate);

                oComand.Parameters.AddWithValue("@YearNumber", Appointment.YearNumber);
                oComand.Parameters.AddWithValue("@MonthNumber", Appointment.MonthNumber);
                oComand.Parameters.AddWithValue("@DayNumber", Appointment.DayNumber);
                oComand.Parameters.AddWithValue("@StartTime", Appointment.StartTime.Ticks);
                oComand.Parameters.AddWithValue("@Index", Appointment.Index);
                oComand.Parameters.AddWithValue("@Status", Appointment.Status);
                oComand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                if (oCon.State == ConnectionState.Open)
                    oCon.Close();
            }
        }

        public void DeleteAppointment(Int64 RecordID, int deleteType)
        {
            System.Data.DataSet ds = new System.Data.DataSet();
            SqlCommand oComand = new SqlCommand();
            oComand.CommandText = "sp_AppointmentDelete";
            oComand.CommandType = System.Data.CommandType.StoredProcedure;
            oComand.Connection = oCon;
            try
            {
                oCon.Open();
                oComand.Parameters.AddWithValue("@AppointmentID", RecordID);
                oComand.Parameters.AddWithValue("@DeleteType", deleteType);
                oComand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {
                if (oCon.State == ConnectionState.Open)
                    oCon.Close();
            }
        }

        public DataSet GetVisitsReportList(int patientID, int doctorID, string startRangeDate, string endRangeDate)
        {
            DataSet aDataSet = new DataSet();
            SqlCommand oComand = new SqlCommand();
            oComand.CommandText = "sp_VisitsReport";
            oComand.CommandType = System.Data.CommandType.StoredProcedure;
            oComand.Connection = oCon;
            try
            {
                oComand.Parameters.AddWithValue("@PatientID", patientID);
                oComand.Parameters.AddWithValue("@DoctorID", doctorID);
                oComand.Parameters.AddWithValue("@StartRangeDate", startRangeDate);
                oComand.Parameters.AddWithValue("@EndRangeDate", endRangeDate);
                SqlDataAdapter oAdapter = new SqlDataAdapter(oComand);
                oAdapter.Fill(aDataSet);
                return aDataSet;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public void SetAppointmentStatus(Int64 RecordID, int statusType)
        {
            System.Data.DataSet ds = new System.Data.DataSet();
            SqlCommand oComand = new SqlCommand();
            oComand.CommandText = "sp_AppointmentStatusUpdate";
            oComand.CommandType = System.Data.CommandType.StoredProcedure;
            oComand.Connection = oCon;
            try
            {
                oCon.Open();
                oComand.Parameters.AddWithValue("@AppointmentID", RecordID);
                oComand.Parameters.AddWithValue("@StatusType", statusType);
                oComand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {
                if (oCon.State == ConnectionState.Open)
                    oCon.Close();
            }
        }

        public override void Insert()
        {
            throw new NotImplementedException();
        }

        public override void Update()
        {
            throw new NotImplementedException();
        }

        public override void Delete()
        {
            throw new NotImplementedException();
        }

        public override void Delete<T>(T recID)
        {
            throw new NotImplementedException();
        }

        public override DataSet Select()
        {
            throw new NotImplementedException();
        }

        public override DataSet FillGrid()
        {
            throw new NotImplementedException();
        }
    }
}
