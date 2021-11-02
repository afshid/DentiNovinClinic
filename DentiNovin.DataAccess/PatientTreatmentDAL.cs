using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DentiNovin.Common;
using System.Data.SqlClient;
using System.Configuration;
using DentiNovin.Common.SerialMaker;

namespace DentiNovin.DataAccess
{
    public class PatientTreatmentDAL : BaseDAL
    {
        //private Patient _oPatient;
        //public Patient OPatient
        //{
        //    get { return _oPatient; }
        //    set { _oPatient = value; }
        //}

        private PatientTreatment _oPatientTreatment;
        public PatientTreatment oPatientTreatment
        {
            get { return _oPatientTreatment; }
            set { _oPatientTreatment = value; }
        }

        private XRayImage _oXRayImage;
        public XRayImage oXRayImage
        {
            get { return _oXRayImage; }
            set { _oXRayImage = value; }
        }

        public SerialMaker.RunTypes RunType { get; set; }

        private PatientToothType _oPatientToothType;
        public PatientToothType oPatientToothType
        {
            get
            {
                return _oPatientToothType;
            }
            set
            {
                _oPatientToothType = value;
            }

        }

        public void InsertNewPatientTreatment()
        {
            System.Data.DataSet ds = new System.Data.DataSet();
            SqlTransaction oTran = null;
            SqlCommand oComand = new SqlCommand();
            try
            {
                oComand.Connection = oCon;
                oCon.Open();
                //for trial start
                oComand.CommandText = "SELECT Count(*) AS RecCount FROM [tbl_Patient-Treatment]";
                oComand.CommandType = System.Data.CommandType.Text;
                int treatmentCount = System.Convert.ToInt32(oComand.ExecuteScalar());
                if (treatmentCount > 100 && this.RunType != SerialMaker.RunTypes.Full)
                {
                    string errorMessage = "اتمام تعداد مجاز ثبت درمان بیمار در نسخه رایگان";
                    throw new TrialException(errorMessage);
                }
                //end
                oComand.CommandText = "sp_PatientTreatmentInsert";
                oComand.CommandType = System.Data.CommandType.StoredProcedure;

                oComand.Parameters.AddWithValue("@AppointmentID", oPatientTreatment.AppointmentID);
                oComand.Parameters.AddWithValue("@PatientID", oPatientTreatment.PatientID);
                oComand.Parameters.AddWithValue("@TreatmentServiceID", oPatientTreatment.Treatment.TreatmentServiceID);
                oComand.Parameters.AddWithValue("@Status", oPatientTreatment.Status);
                oComand.Parameters.AddWithValue("@ToothDirection", oPatientTreatment.Tooth.Direction);
                oComand.Parameters.AddWithValue("@ToothCode", oPatientTreatment.Tooth.Code);
                oComand.Parameters.AddWithValue("@SurfaceCode", oPatientTreatment.SurfaceCode);
                oComand.Parameters.AddWithValue("@Description", oPatientTreatment.Description);
                oComand.Parameters.AddWithValue("@SurfaceCount", oPatientTreatment.SurfaceCount);
                oComand.Parameters.AddWithValue("@DoctorID", oPatientTreatment.DoctorID);
                oComand.Parameters.AddWithValue("@ToothType", oPatientTreatment.Tooth.Type);
                oComand.Parameters.AddWithValue("@RegisterDate", oPatientTreatment.RegisterDate);

                oTran = oCon.BeginTransaction();
                oComand.Transaction = oTran;
                oPatientTreatment.PatientTreatmentID = System.Convert.ToInt32(oComand.ExecuteScalar());
                if (oPatientTreatment.Treatment.TreatmentArea != 3)
                {
                    oTran.Commit();
                    return;
                }
                oComand.CommandText = "sp_RootTreatmentInsert";
                foreach (Roots rts in oPatientTreatment.RootsTreatment)
                {
                    oComand.Parameters.Clear();
                    oComand.Parameters.AddWithValue("@PatientTreatmentID", oPatientTreatment.PatientTreatmentID);
                    oComand.Parameters.AddWithValue("@RootName", rts.RootName);
                    oComand.Parameters.AddWithValue("@RootLenght", rts.RootLenght);
                    oComand.ExecuteNonQuery();
                }
                oTran.Commit();
            }
            catch (TrialException tex)
            {
               throw;
            }
            catch (Exception ex)
            {
                oTran.Rollback();
                throw;
            }

            finally
            {
                if (oCon.State == ConnectionState.Open)
                    oCon.Close();
            }

        }

        public void UpdatePatientTreatment()
        {
            SqlCommand oComand = new SqlCommand();
            SqlTransaction oTran = null;
            oComand.CommandText = "sp_PatientTreatmentUpdate";

            oComand.CommandType = System.Data.CommandType.StoredProcedure;
            oComand.Connection = oCon;
            oComand.Parameters.Clear();
            try
            {
                oComand.Parameters.AddWithValue("@TreatmentServiceID", oPatientTreatment.Treatment.TreatmentServiceID);
                oComand.Parameters.AddWithValue("@AppointmentID", oPatientTreatment.AppointmentID);
                oComand.Parameters.AddWithValue("@Status", oPatientTreatment.Status);
                oComand.Parameters.AddWithValue("@ToothDirection", oPatientTreatment.Tooth.Direction);
                oComand.Parameters.AddWithValue("@ToothCode", oPatientTreatment.Tooth.Code);
                oComand.Parameters.AddWithValue("@SurfaceCode", oPatientTreatment.SurfaceCode);
                oComand.Parameters.AddWithValue("@Description", oPatientTreatment.Description);
                oComand.Parameters.AddWithValue("@SurfaceCount", oPatientTreatment.SurfaceCount);
                oComand.Parameters.AddWithValue("@DoctorID", oPatientTreatment.DoctorID);
                oComand.Parameters.AddWithValue("@ToothType", oPatientTreatment.Tooth.Type);
                oComand.Parameters.AddWithValue("@RegisterDate", oPatientTreatment.RegisterDate);
                oComand.Parameters.AddWithValue("@PatientTreatmentID", oPatientTreatment.PatientTreatmentID);
                oCon.Open();
                oTran = oCon.BeginTransaction();
                oComand.Transaction = oTran;
                oComand.ExecuteNonQuery();
                oTran.Commit();
            }
            catch (Exception ex)
            {
                oTran.Rollback();
                throw;
            }
            finally
            {
                if (oCon.State == ConnectionState.Open)
                    oCon.Close();
            }
        }

        public void UpdatePatientTreatmentDetails()
        {
            SqlCommand oComand = new SqlCommand();
            SqlTransaction oTran = null;
            oComand.CommandText = "sp_PatientTreatmentDetailsUpdate";

            oComand.CommandType = System.Data.CommandType.StoredProcedure;
            oComand.Connection = oCon;
            try
            {
                oComand.Parameters.AddWithValue("@PatientTreatmentID", oPatientTreatment.PatientTreatmentID);
                if (oPatientTreatment.Treatment.TreatmentArea == 3)
                    oComand.Parameters.AddWithValue("@IsRootTreatment", true);
                oComand.Parameters.AddWithValue("@Description", oPatientTreatment.Description);
                oCon.Open();
                oTran = oCon.BeginTransaction();
                oComand.Transaction = oTran;
                oComand.ExecuteNonQuery();
                if (oPatientTreatment.Treatment.TreatmentArea != 3)
                    return;
                oComand.CommandText = "sp_RootTreatmentInsert";
                foreach (Roots rts in oPatientTreatment.RootsTreatment)
                {
                    oComand.Parameters.Clear();
                    oComand.Parameters.AddWithValue("@PatientTreatmentID", oPatientTreatment.PatientTreatmentID);
                    oComand.Parameters.AddWithValue("@RootName", rts.RootName);
                    oComand.Parameters.AddWithValue("@RootLenght", rts.RootLenght);
                    oComand.ExecuteNonQuery();
                }
                oTran.Commit();
            }
            catch (Exception ex)
            {
                oTran.Rollback();
                throw;
            }
            finally
            {
                if (oCon.State == ConnectionState.Open)
                    oCon.Close();
            }
        }

        public DataSet GetPatientTreatmentList(Int64 appointmentID, int PatientID, int[] status, bool showPersian, Int16 toothCode)
        {
            System.Data.DataSet aDataSet = new System.Data.DataSet();
            SqlCommand oComand = new SqlCommand();
            int cmStatus = 0;
            int cnStatus = 0;
            int plStatus = 0;
            int deStatus = 0;
            try
            {
                //oComand.CommandText = "sp_PatientTreatmentRelatedSelectByFieldWithPrice";
                oComand.CommandText = "sp_PatientTreatmentRelatedSelectByPatientID";
                oComand.CommandType = System.Data.CommandType.StoredProcedure;
                oComand.Connection = oCon;
                oComand.Parameters.AddWithValue("@PatientID", PatientID);
                oComand.Parameters.AddWithValue("@AppointmentID", appointmentID);
                foreach (int st in status)
                {
                    switch (st)
                    {
                        case 0:
                            break;
                        case 1:
                            cmStatus = 1;
                            break;
                        case 2:
                            plStatus = 2;
                            break;
                        case 3:
                            cnStatus = 3;
                            break;
                        case 4:
                            deStatus = 4;
                            break;
                        default:
                            break;
                    }
                }

                oComand.Parameters.AddWithValue("@cmStatus", cmStatus);
                oComand.Parameters.AddWithValue("@cnStatus", cnStatus);
                oComand.Parameters.AddWithValue("@plStatus", plStatus);
                oComand.Parameters.AddWithValue("@deStatus", deStatus);
                oComand.Parameters.AddWithValue("@ShowPersianName", showPersian);
                oComand.Parameters.AddWithValue("@ToothCode", toothCode);

                SqlDataAdapter oAdapter = new SqlDataAdapter(oComand);
                oAdapter.Fill(aDataSet, "PatientTreatmentRelated");

                oComand.CommandText = "sp_PatientTreatmentSelectByField";
                oComand.CommandType = System.Data.CommandType.StoredProcedure;
                oComand.Connection = oCon;
                oComand.Parameters.Clear();
                oComand.Parameters.AddWithValue("@AppointmentID", appointmentID);
                oComand.Parameters.AddWithValue("@PatientID", PatientID);
                oComand.Parameters.AddWithValue("@ToothCode", toothCode);
                //oComand.Parameters.AddWithValue("@cmStatus", cmStatus);
                //oComand.Parameters.AddWithValue("@cnStatus", cnStatus);
                //oComand.Parameters.AddWithValue("@plStatus", plStatus);
                // oComand.Parameters.AddWithValue("@deStatus", deStatus);

                oAdapter.Fill(aDataSet, "PatientTreatment");


                return aDataSet;
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public void DeletePatientTreatment()
        {
            SqlTransaction oTran = null;
            try
            {
                SqlCommand oComand = new SqlCommand();
                oComand.CommandText = "sp_PatientTreatmentDeleteByID";
                oComand.CommandType = System.Data.CommandType.StoredProcedure;
                oComand.Parameters.AddWithValue("@PatientTreatmentID", oPatientTreatment.PatientTreatmentID);
                oComand.Connection = oCon;
                oCon.Open();
                oTran = oCon.BeginTransaction();
                oComand.Transaction = oTran;
                oComand.ExecuteNonQuery();
                oTran.Commit();
            }
            catch (Exception ex)
            {
                oTran.Rollback();
                throw;
            }
            finally
            {
                if (oCon.State == ConnectionState.Open)
                    oCon.Close();
            }
        }

        public void ChangePatientTreatmentStatus(Int64 patientTreatmentID, int newStatus)
        {
            SqlCommand oComand = new SqlCommand();
            oComand.CommandText = "sp_PatientTreatmentStatusUpdate";

            oComand.CommandType = System.Data.CommandType.StoredProcedure;
            oComand.Connection = oCon;
            try
            {
                oComand.Parameters.AddWithValue("@Status", newStatus);
                oComand.Parameters.AddWithValue("@PatientTreatmentID", patientTreatmentID);
                oCon.Open();
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

        public void UpdatePatientToothType()
        {
            SqlCommand oComand = new SqlCommand();
            oComand.CommandType = System.Data.CommandType.StoredProcedure;
            oComand.Connection = oCon;
            try
            {
                if (oPatientToothType.ToothCode != 0)
                {
                    oComand.CommandText = "sp_PatientToothTypeUpdate";
                    oComand.Parameters.AddWithValue("@ToothType", (int)oPatientToothType.ToothType);
                    oComand.Parameters.AddWithValue("@PatientID", oPatientToothType.PatientID);
                    oComand.Parameters.AddWithValue("@ToothCode", oPatientToothType.ToothCode);
                }
                else
                {
                    oComand.CommandText = "sp_PatientToothTypeDelete";
                    oComand.Parameters.AddWithValue("@PatientID", oPatientToothType.PatientID);
                }

                oCon.Open();

                int rowAffected = Convert.ToInt32(oComand.ExecuteNonQuery());

                if (rowAffected != 0 && oPatientToothType.ToothCode != 0)
                    return;
                oComand.CommandText = "sp_PatientToothTypeInsert";
                oComand.Parameters.Clear();

                oComand.Parameters.AddWithValue("@PatientID", oPatientToothType.PatientID);
                oComand.Parameters.AddWithValue("@ToothCode", oPatientToothType.ToothCode);
                oComand.Parameters.AddWithValue("@ToothType", (int)oPatientToothType.ToothType);
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

        public DataSet GetPatientToothTypeList(int PatientID)
        {
            System.Data.DataSet aDataSet = new System.Data.DataSet();
            SqlCommand oComand = new SqlCommand();
            try
            {
                oComand.CommandText = "sp_PatientToothTypeSelectByPatientID";
                oComand.CommandType = System.Data.CommandType.StoredProcedure;
                oComand.Connection = oCon;
                oComand.Parameters.AddWithValue("@PatientID", PatientID);
                SqlDataAdapter oAdapter = new SqlDataAdapter(oComand);
                oAdapter.Fill(aDataSet);
                return aDataSet;
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public DataSet GetXRayList(int patientID)
        {
            DataSet aDataSet = new DataSet();
            SqlCommand oComand = new SqlCommand();
            //oComand.CommandText = "sp_TreatmentTariffSelect";
            oComand.CommandText = "sp_XRayImageSelectByPatientID";
            oComand.CommandType = System.Data.CommandType.StoredProcedure;
            oComand.Connection = oCon;
            try
            {
                oComand.Parameters.AddWithValue("@PatientID", patientID);
                SqlDataAdapter oAdapter = new SqlDataAdapter(oComand);
                oAdapter.Fill(aDataSet);
                return aDataSet;
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public void InsertXRayImage()
        {
            System.Data.DataSet ds = new System.Data.DataSet();
            SqlCommand oComand = new SqlCommand();
            try
            {
                oComand.CommandText = "sp_XRayImageInsert";
                oComand.CommandType = System.Data.CommandType.StoredProcedure;
                oComand.Connection = oCon;
                oComand.Parameters.AddWithValue("@PatientID", oXRayImage.PatientID);
                oComand.Parameters.AddWithValue("@XRayImage", oXRayImage.Imagebyte);
                oComand.Parameters.AddWithValue("@DateOfRegister", oXRayImage.DateOfRegister);

                oCon.Open();
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

        public void DeleteXRayImages(string rIDList)
        {
            System.Data.DataSet ds = new System.Data.DataSet();
            SqlCommand oComand = new SqlCommand();
            try
            {
                oComand.CommandText = "delete from tbl_XRayImages where XRayImageID in (" + rIDList + ")";
                oComand.CommandType = System.Data.CommandType.Text;
                oComand.Connection = oCon;
                oCon.Open();
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

        public DataSet GetTreatmentsReportList(int patientID, int doctorID, string startRangeDate, string endRangeDate, bool showPersian)
        {
            DataSet aDataSet = new DataSet();
            SqlCommand oComand = new SqlCommand();
            oComand.CommandText = "sp_TreatmentsReport";
            oComand.CommandType = System.Data.CommandType.StoredProcedure;
            oComand.Connection = oCon;
            try
            {
                oComand.Parameters.AddWithValue("@PatientID", patientID);
                oComand.Parameters.AddWithValue("@DoctorID", doctorID);
                oComand.Parameters.AddWithValue("@StartRangeDate", startRangeDate);
                oComand.Parameters.AddWithValue("@EndRangeDate", endRangeDate);
                oComand.Parameters.AddWithValue("@ShowPersianName", showPersian);
                SqlDataAdapter oAdapter = new SqlDataAdapter(oComand);
                oAdapter.Fill(aDataSet);
                return aDataSet;
            }
            catch (Exception ex)
            {

                throw;
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
