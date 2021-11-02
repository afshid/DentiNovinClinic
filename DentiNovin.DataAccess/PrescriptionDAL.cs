using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using DentiNovin.Common;
using System.Data;

namespace DentiNovin.DataAccess
{
    public class PrescriptionDAL : BaseDAL
    {
        private Patient _oPatient;
        public Patient oPatient
        {
            get { return _oPatient; }
            set { _oPatient = value; }
        }

        private Prescription _oPrescription;
        public Prescription OPrescription
        {
            get
            {
                return _oPrescription;
            }
            set { _oPrescription = value; }
        }

        public void SelectPatient(string assuranceCode)
        {
            SqlCommand oComand = new SqlCommand();
            oComand.CommandText = "sp_PatientSelectByAssuranceCode";
            oComand.CommandType = System.Data.CommandType.StoredProcedure;
            oComand.Connection = oCon;
            try
            {
                oComand.Parameters.AddWithValue("@AssuranceCode", assuranceCode);
                oCon.Open();
                SqlDataReader oreader = oComand.ExecuteReader();
                if (oreader.Read())
                {
                    oPatient.PatientID = (int)oreader[0];
                    oPatient.FirstName = oreader[1].ToString();
                    oPatient.LastName = oreader[2].ToString();
                    oPatient.Sex = (Boolean)oreader[3];
                    oPatient.PatientAssuranceList.Clear();
                    PatientAssurance aPatientAssurance = new PatientAssurance();
                    aPatientAssurance.AssuranceCode = oreader[7].ToString();
                    aPatientAssurance.AssuranceID = (int)oreader[5];
                    aPatientAssurance.AssuranceName = oreader[6].ToString();
                    aPatientAssurance.ValidityDate = oreader[9].ToString();
                    oPatient.PatientAssuranceList.Add(aPatientAssurance);
                    oPatient.DoctorID = (Int16)oreader[4];
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

        public override void Insert()
        {
            SqlCommand oComand = new SqlCommand();
            SqlTransaction oTran = null;
            oComand.Connection = oCon;
            try
            {
                oCon.Open();
                oTran = oCon.BeginTransaction();
                oComand.Transaction = oTran;
                oComand.CommandText = "sp_PrescriptionHeaderInsert";
                oComand.CommandType = System.Data.CommandType.StoredProcedure;

                oComand.Parameters.AddWithValue("@PatientID", OPrescription.PatientID);
                oComand.Parameters.AddWithValue("@DoctorID", OPrescription.DoctorID);
                oComand.Parameters.AddWithValue("@AssuranceCode", OPrescription.AssuranceCode);
                oComand.Parameters.AddWithValue("@ActionDate", OPrescription.ActionDate);
                oComand.Parameters.AddWithValue("@PageNumber", OPrescription.PageNumber);
                oComand.Parameters.AddWithValue("@ReferenceDate", OPrescription.ReferencedDate);
                oComand.Parameters.AddWithValue("@IsReferenced", OPrescription.IsReferenced);
                oComand.Parameters.AddWithValue("@PatientPayment", OPrescription.PatientPayment);
                oComand.Parameters.AddWithValue("@KCoeff", OPrescription.KCoeff);
                oComand.Parameters.AddWithValue("@VisitPrice", OPrescription.VisitPrice);
                oComand.Parameters.AddWithValue("@Year", OPrescription.Year);
                oComand.Parameters.AddWithValue("@Month", OPrescription.Month);

                OPrescription.PrescriptionID = Convert.ToInt32(oComand.ExecuteScalar());
                oComand.Parameters.Clear();

                oComand.CommandText = "sp_PrescriptionDetailsInsert";

                foreach (AssuranceService  aS in OPrescription.AssuranceServiceList)
                {
                    oComand.Parameters.AddWithValue("@PrescriptionID", OPrescription.PrescriptionID);
                    oComand.Parameters.AddWithValue("@AssuranceServiceID", aS.ServiceID);
                    oComand.Parameters.AddWithValue("@AssuranceServicePrice", aS.ServicePrice);
                    oComand.Parameters.AddWithValue("@AssuranceKPrice", aS.KPrice);
                    oComand.ExecuteNonQuery();
                    oComand.Parameters.Clear();
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

        public override void Update()
        {
            SqlCommand oComand = new SqlCommand();
            SqlTransaction oTran = null;
            oComand.Connection = oCon;
            try
            {

                oCon.Open();
                oTran = oCon.BeginTransaction();
                oComand.Transaction = oTran;
                oComand.CommandText = "sp_PrescriptionUpdate";
                oComand.CommandType = System.Data.CommandType.StoredProcedure;

                oComand.Parameters.AddWithValue("@PrescriptionID", OPrescription.PrescriptionID);
                oComand.Parameters.AddWithValue("@DoctorID", OPrescription.DoctorID);
                oComand.Parameters.AddWithValue("@ActionDate", OPrescription.ActionDate);
                oComand.Parameters.AddWithValue("@PageNumber", OPrescription.PageNumber);
                oComand.Parameters.AddWithValue("@ReferenceDate", OPrescription.ReferencedDate);
                oComand.Parameters.AddWithValue("@IsReferenced", OPrescription.IsReferenced);
                oComand.Parameters.AddWithValue("@PatientPayment", OPrescription.PatientPayment);
                oComand.Parameters.AddWithValue("@KCoeff", OPrescription.KCoeff);
                oComand.Parameters.AddWithValue("@VisitPrice", OPrescription.VisitPrice);
                oComand.Parameters.AddWithValue("@Year", OPrescription.Year);
                oComand.Parameters.AddWithValue("@Month", OPrescription.Month);

                oComand.ExecuteNonQuery();

                oComand.Parameters.Clear();

                oComand.CommandText = "sp_PrescriptionDetailsInsert";

                foreach (AssuranceService aS in OPrescription.AssuranceServiceList)
                {
                    oComand.Parameters.AddWithValue("@PrescriptionID", OPrescription.PrescriptionID);
                    oComand.Parameters.AddWithValue("@AssuranceServiceID", aS.ServiceID);
                    oComand.Parameters.AddWithValue("@AssuranceServicePrice", aS.ServicePrice);
                    oComand.Parameters.AddWithValue("@AssuranceKPrice", aS.KPrice);
                    oComand.ExecuteNonQuery();
                    oComand.Parameters.Clear();
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

        public override void Delete()
        {
            throw new NotImplementedException();
        }

        public override System.Data.DataSet Select()
        {
            throw new NotImplementedException();
        }

        public override System.Data.DataSet FillGrid()
        {
            throw new NotImplementedException();
        }

        public DataSet GetPrescriptionList(int year, int month, int assuranceID, int doctorID)
        {
            System.Data.DataSet aDataSet = new System.Data.DataSet();
            SqlCommand oComand = new SqlCommand();
            try
            {
                oComand.CommandText = "sp_PrescriptionHeaderSelectByField";
                oComand.CommandType = System.Data.CommandType.StoredProcedure;
                oComand.Connection = oCon;
                oComand.Parameters.AddWithValue("@Year", year);
                oComand.Parameters.AddWithValue("@Month", month);
                oComand.Parameters.AddWithValue("@AssuranceID", assuranceID);
                oComand.Parameters.AddWithValue("@DoctorID", doctorID);

                SqlDataAdapter oAdapter = new SqlDataAdapter(oComand);
                oAdapter.Fill(aDataSet,"PrescriptionHeader");

                oComand.CommandText = "sp_PrescriptionDetailsSelectByField";
                oAdapter.Fill(aDataSet, "PrescriptionDetails");

                return aDataSet;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        
        public DataSet GetPrescritionGroupList()
        {
            System.Data.DataSet aDataSet = new System.Data.DataSet();
            SqlCommand oComand = new SqlCommand();
            try
            {
                oComand.CommandText = "sp_PrescriptionGroupList";
                oComand.CommandType = System.Data.CommandType.StoredProcedure;
                oComand.Connection = oCon;
                SqlDataAdapter oAdapter = new SqlDataAdapter(oComand);
                oAdapter.Fill(aDataSet);
                return aDataSet;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public override void Delete<T>(T recID)
        {
            System.Data.DataSet ds = new System.Data.DataSet();
            SqlTransaction oTran = null;
            SqlCommand oComand = new SqlCommand();
            oComand.CommandText = "sp_PrescriptionDelete";

            oComand.CommandType = System.Data.CommandType.StoredProcedure;
            oComand.Connection = oCon;
            try
            {
                oCon.Open();
                oTran = oCon.BeginTransaction();
                oComand.Transaction = oTran;
                oComand.Parameters.AddWithValue("@PrescriptionHrID", recID);
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

        public DataSet GetKhPrescriptionVisitServiceMixedList(Doctor doctor, int year, int month, int assuranceID, int visitOrganPercent)
        {
            System.Data.DataSet aDataSet = new System.Data.DataSet();
            SqlCommand oComand = new SqlCommand();
            try
            {
                oComand.CommandText = "sp_PrescriptionVisitMixedForKhSelectByField";
                oComand.CommandType = System.Data.CommandType.StoredProcedure;
                oComand.Connection = oCon;
                oComand.Parameters.AddWithValue("@Year", year);
                oComand.Parameters.AddWithValue("@Month", month);
                oComand.Parameters.AddWithValue("@AssuranceID", assuranceID);
                oComand.Parameters.AddWithValue("@DoctorID", doctor.DoctorID);
                oComand.Parameters.AddWithValue("@VisitOrganPercent", visitOrganPercent);
                oComand.Parameters.AddWithValue("@HandBookID",1);
                SqlDataAdapter oAdapter = new SqlDataAdapter(oComand);
                oAdapter.Fill(aDataSet, "KhPrescriptionMixedVisitHType1");
                oComand.Parameters["@HandBookID"].Value = 2;
                oAdapter.Fill(aDataSet, "KhPrescriptionMixedVisitHType2");
                oComand.Parameters["@HandBookID"].Value = 3;
                oAdapter.Fill(aDataSet, "KhPrescriptionMixedVisitHType3");
                oComand.Parameters["@HandBookID"].Value = 4;
                oAdapter.Fill(aDataSet, "KhPrescriptionMixedVisitHType4");

                return aDataSet;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public DataSet GetKhPrescriptionServiceMixedList(Doctor doctor, int year, int month, int assuranceID, int organPercent)
        {
            System.Data.DataSet aDataSet = new System.Data.DataSet();
            SqlCommand oComand = new SqlCommand();
            try
            {
                oComand.CommandText = "sp_PrescriptionServiceMixedForKhSelectByField";
                oComand.CommandType = System.Data.CommandType.StoredProcedure;
                oComand.Connection = oCon;
                oComand.Parameters.AddWithValue("@Year", year);
                oComand.Parameters.AddWithValue("@Month", month);
                oComand.Parameters.AddWithValue("@AssuranceID", assuranceID);
                oComand.Parameters.AddWithValue("@DoctorID", doctor.DoctorID);
                oComand.Parameters.AddWithValue("@OrganPercent", organPercent);
                oComand.Parameters.AddWithValue("@HandBookID", 1);
                SqlDataAdapter oAdapter = new SqlDataAdapter(oComand);
                oAdapter.Fill(aDataSet, "KhPrescriptionMixedServiceHType1");
                oComand.Parameters["@HandBookID"].Value = 2;
                oAdapter.Fill(aDataSet, "KhPrescriptionMixedServiceHType2");
                oComand.Parameters["@HandBookID"].Value = 3;
                oAdapter.Fill(aDataSet, "KhPrescriptionMixedServiceHType3");
                oComand.Parameters["@HandBookID"].Value = 4;
                oAdapter.Fill(aDataSet, "KhPrescriptionMixedServiceHType4");

                return aDataSet;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public DataSet GetMoPrescriptionVisitServiceMixedList(Doctor doctor, int year, int month, int assuranceID, int visitOrganPercent)
        {
            System.Data.DataSet aDataSet = new System.Data.DataSet();
            SqlCommand oComand = new SqlCommand();
            try
            {
                oComand.CommandText = "sp_PrescriptionVisitMixedForMoSelectByField";
                oComand.CommandType = System.Data.CommandType.StoredProcedure;
                oComand.Connection = oCon;
                oComand.Parameters.AddWithValue("@Year", year);
                oComand.Parameters.AddWithValue("@Month", month);
                oComand.Parameters.AddWithValue("@AssuranceID", assuranceID);
                oComand.Parameters.AddWithValue("@DoctorID", doctor.DoctorID);
                oComand.Parameters.AddWithValue("@VisitOrganPercent", visitOrganPercent);
                SqlDataAdapter oAdapter = new SqlDataAdapter(oComand);
                oAdapter.Fill(aDataSet, "MoPrescriptionMixedVisit");
                return aDataSet;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public DataSet GetMoPrescriptionServiceMixedList(Doctor doctor, int year, int month, int assuranceID, int organPercent)
        {
            System.Data.DataSet aDataSet = new System.Data.DataSet();
            SqlCommand oComand = new SqlCommand();
            try
            {
                oComand.CommandText = "sp_PrescriptionServiceMixedForMoSelectByField";
                oComand.CommandType = System.Data.CommandType.StoredProcedure;
                oComand.Connection = oCon;
                oComand.Parameters.AddWithValue("@Year", year);
                oComand.Parameters.AddWithValue("@Month", month);
                oComand.Parameters.AddWithValue("@AssuranceID", assuranceID);
                oComand.Parameters.AddWithValue("@DoctorID", doctor.DoctorID);
                oComand.Parameters.AddWithValue("@OrganPercent", organPercent);
                SqlDataAdapter oAdapter = new SqlDataAdapter(oComand);
                oAdapter.Fill(aDataSet, "MoPrescriptionMixedService");
                return aDataSet;
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        public Int64 GetVisitServiceID(int headID, int assuranceID)
        {
            Int64 visitServiceID = 0;
            SqlCommand oComand = new SqlCommand();
            oComand.Connection = oCon;
            try
            {
                oCon.Open();
                oComand.CommandText = "sp_AssuranceVisitServiceIDSelect";
                oComand.CommandType = System.Data.CommandType.StoredProcedure;

                oComand.Parameters.AddWithValue("@serviceHeaderID", headID);
                oComand.Parameters.AddWithValue("@AssuranceID", assuranceID);
                visitServiceID = Convert.ToInt64(oComand.ExecuteScalar());
                return visitServiceID;
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
    }
}
