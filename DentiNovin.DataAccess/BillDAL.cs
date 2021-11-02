using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DentiNovin.Common;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Configuration;

namespace DentiNovin.DataAccess
{

    public class BillDAL : BaseDAL
    {
        private Bill _BiLLD;
        public Bill BiLLD
        {
            get { return _BiLLD; }
            set { _BiLLD = value; }
        }

        private BillDetails _oBillDetails;
        public BillDetails OBillDetails
        {
            get { return _oBillDetails; }
            set { _oBillDetails = value; }
        }

        private Patient _oPatient;
        public Patient oPatient
        {
            get { return _oPatient; }
            set { _oPatient = value; }
        }

        public System.Data.DataSet FilldgvBill()
        {
            DataSet ds = new DataSet();
            SqlCommand oComand = new SqlCommand();
            oComand.CommandText = "sp_BillSelectByPatientID";
            oComand.CommandType = System.Data.CommandType.StoredProcedure;
            oComand.Connection = oCon;
            try
            {
                oComand.Parameters.AddWithValue("@PatientID", oPatient.PatientID);

                SqlDataAdapter oadapter = new SqlDataAdapter(oComand);
                oadapter.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public DataSet GetPatientTreatmentList(int PatientID, Int64 billID, int showListMode, bool showPersian)
        {
            System.Data.DataSet aDataSet = new System.Data.DataSet();
            SqlCommand oComand = new SqlCommand();
            try
            {
                switch (showListMode)
                {
                    //case 0:
                        //oComand.CommandText = "sp_PatientTreatmentBillPriceSelectByField";
                        //break;
                    case 1:
                        //oComand.CommandText="sp_PatientTreatmentBillPriceSelectPaied";
                        oComand.CommandText = "sp_PatientTreatmentBillSelectPaied";
                        break;
                    case 2:
                        //oComand.CommandText = "sp_PatientTreatmentBillPriceSelectUnpaied";
                        oComand.CommandText = "sp_PatientTreatmentBillSelectUnpaied";
                        break;
                    //default:
                        //oComand.CommandText = "sp_PatientTreatmentBillPriceSelectByField";
                        //break;
                }
                oComand.CommandType = System.Data.CommandType.StoredProcedure;
                oComand.Connection = oCon;
                oComand.Parameters.AddWithValue("@PatientID", PatientID);
                oComand.Parameters.AddWithValue("@BillID", billID);
                //oComand.Parameters.AddWithValue("@AppointmentID", 0);
                //oComand.Parameters.AddWithValue("@cmStatus", 1);
                oComand.Parameters.AddWithValue("@ShowPersianName", showPersian);

                SqlDataAdapter oAdapter = new SqlDataAdapter(oComand);
                oAdapter.Fill(aDataSet, "PatientTreatmentRelated");

                return aDataSet;
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public void SelectPatient()
        {
            SqlCommand oComand = new SqlCommand();
            oComand.CommandText = "sp_PatientSelectByFileNumber";
            oComand.CommandType = System.Data.CommandType.StoredProcedure;
            oComand.Connection = oCon;
            try
            {
                oComand.Parameters.AddWithValue("@FileNumber", oPatient.FileNumber);

                oCon.Open();
                SqlDataReader oreader = oComand.ExecuteReader();
                if (oreader.Read())
                {
                    oPatient.PatientID = (int)oreader[0];
                    oPatient.FirstName = oreader[3].ToString();
                    oPatient.LastName = oreader[4].ToString();
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

        public void InsertBillInfo()
        {
            System.Data.DataSet ds = new System.Data.DataSet();
            SqlCommand oComand = new SqlCommand();
            SqlTransaction oTran = null;
            oComand.CommandText = "sp_BillInsert";
            oComand.CommandType = System.Data.CommandType.StoredProcedure;
            oComand.Connection = oCon;
            try
            {
                oComand.Parameters.AddWithValue("@PatientID", BiLLD.PatientID);
                oComand.Parameters.AddWithValue("@TotalFees", BiLLD.TotalFees);
                oComand.Parameters.AddWithValue("@FeesPayable", BiLLD.FeesPayable);
                oComand.Parameters.AddWithValue("@DateOfRegister", BiLLD.DateOfRegister);


                oCon.Open();
                oTran = oCon.BeginTransaction();
                oComand.Transaction = oTran;
                BiLLD.BillID = Convert.ToInt32(oComand.ExecuteScalar());

                oComand.Parameters.Clear();

                oComand.CommandText = "sp_BillTreatmentInsert";



                foreach (Int64 bt in BiLLD.BillTreatmentList)
                {
                    oComand.Parameters.AddWithValue("@BillID", BiLLD.BillID);
                    oComand.Parameters.AddWithValue("@PatientTreatmentID", bt);
                    oComand.ExecuteNonQuery();
                    oComand.Parameters.Clear();
                }

                oComand.CommandText = "sp_BillDetailsInsert";

                foreach (BillDetails bDs in BiLLD.BillDetailsList)
                {
                    oComand.Parameters.AddWithValue("@BillID", BiLLD.BillID);
                    oComand.Parameters.AddWithValue("@FeesReceived", bDs.FeesReceived);
                    oComand.Parameters.AddWithValue("@DateOfRegister", bDs.DateOfRegister);
                    oComand.Parameters.AddWithValue("@PayType", bDs.PayType);
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

        public void UpdateBillInfo()
        {
            System.Data.DataSet ds = new System.Data.DataSet();
            SqlCommand oComand = new SqlCommand();
            SqlTransaction oTran = null;
            oComand.CommandType = System.Data.CommandType.StoredProcedure;
            oComand.Connection = oCon;
            try
            {

                oCon.Open();
                oTran = oCon.BeginTransaction();
                oComand.Transaction = oTran;
                oComand.CommandText = "sp_BillUpdate";

                oComand.Parameters.AddWithValue("@BillID", BiLLD.BillID);
                oComand.Parameters.AddWithValue("@TotalFees", BiLLD.TotalFees);
                oComand.Parameters.AddWithValue("@FeesPayable", BiLLD.FeesPayable);
                oComand.Parameters.AddWithValue("@DateOfRegister", BiLLD.DateOfRegister);
                oComand.ExecuteNonQuery();
                oComand.Parameters.Clear();

                oComand.CommandText = "sp_BillDetailsInsert";
                foreach (BillDetails bDs in BiLLD.BillDetailsList)
                {
                    oComand.Parameters.AddWithValue("@BillID", BiLLD.BillID);
                    oComand.Parameters.AddWithValue("@FeesReceived", bDs.FeesReceived);
                    oComand.Parameters.AddWithValue("@DateOfRegister", bDs.DateOfRegister);
                    oComand.Parameters.AddWithValue("@PayType", bDs.PayType);
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

        public DataSet GetBillTreatmentList(int patientID, Int64 billID, bool showPersian)
        {
            DataSet aDataSet = new DataSet();
            SqlCommand oComand = new SqlCommand();
            oComand.CommandText = "sp_PatientTreatmentBillSelectPaied";
            oComand.CommandType = System.Data.CommandType.StoredProcedure;
            oComand.Connection = oCon;
            try
            {
                oComand.Parameters.AddWithValue("@PatientID", patientID);
                oComand.Parameters.AddWithValue("@BillID", billID);
                oComand.Parameters.AddWithValue("@ShowPersianName", showPersian);
                SqlDataAdapter oAdapter = new SqlDataAdapter(oComand);
                oAdapter.Fill(aDataSet);
                return aDataSet;
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

        public DataSet GetBillDetailsList(Int64 billID)
        {
            DataSet ds = new DataSet();
            SqlCommand oComand = new SqlCommand();
            oComand.CommandText = "sp_BillDetailsSelectByBillID";
            oComand.CommandType = System.Data.CommandType.StoredProcedure;
            oComand.Connection = oCon;
            try
            {
                oComand.Parameters.AddWithValue("@BillID", billID);

                SqlDataAdapter oadapter = new SqlDataAdapter(oComand);
                oadapter.Fill(ds);
                return ds;
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
            System.Data.DataSet ds = new System.Data.DataSet();
            SqlCommand oComand = new SqlCommand();
            oComand.CommandText = "sp_BillDelete";
            SqlTransaction oTran = null;
            oComand.CommandType = System.Data.CommandType.StoredProcedure;
            oComand.Connection = oCon;
            try
            {
                oCon.Open();
                oTran = oCon.BeginTransaction();
                oComand.Transaction = oTran;
                oComand.Parameters.AddWithValue("@BillID", recID);
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

        public override DataSet Select()
        {
            throw new NotImplementedException();
        }

        public override DataSet FillGrid()
        {
            throw new NotImplementedException();
        }

        public DataSet GetBillsReportList(int patientID, int doctorID, string startRangeDate, string endRangeDate,bool isForPatient, bool withBillID)
        {
            DataSet aDataSet = new DataSet();
            SqlCommand oComand = new SqlCommand();
            oComand.CommandType = System.Data.CommandType.StoredProcedure;
            oComand.Connection = oCon;
            try
            {
                if (isForPatient)
                {
                    oComand.Parameters.AddWithValue("@PatientID", patientID);
                    if (withBillID)
                        oComand.CommandText = "sp_BillsForPatientWithBillIDReport";
                    else
                        oComand.CommandText = "sp_BillsForPatientWithoutBillIDReport";
                }
                else
                {
                    oComand.Parameters.AddWithValue("@DoctorID", doctorID);

                    if (withBillID)
                        oComand.CommandText = "sp_BillsForDocotrWithBillIDReport";
                    else
                        oComand.CommandText = "sp_BillsForDocotrWithoutBillIDReport";
                }
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
    
    }



}
