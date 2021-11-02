using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DentiNovin.Common;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using DentiNovin.Common.SerialMaker;

namespace DentiNovin.DataAccess
{
    public class PatientDAL : BaseDAL
    {

        private Patient _oPatient;
        public Patient oPatient
        {
            get { return _oPatient; }
            set { _oPatient = value; }
        }

        public SerialMaker.RunTypes RunType { get; set; }

        public void PatientInsert()
        {
            SqlCommand oComand = new SqlCommand();
            SqlTransaction oTran = null;
            oComand.Connection = oCon;
            try
            {
                oCon.Open();
                //for trial start
                oComand.CommandText = "SELECT Count(*) AS RecCount FROM [tbl_Patient]";
                oComand.CommandType = System.Data.CommandType.Text;
                int patientCount = System.Convert.ToInt32(oComand.ExecuteScalar());
                if (patientCount > 10 && this.RunType != SerialMaker.RunTypes.Full)
                {
                    string errorMessage = "اتمام تعداد مجاز ثبت بیمار جدید در نسخه رایگان";
                    throw new TrialException(errorMessage);
                }
                //end
                oTran = oCon.BeginTransaction();
                oComand.Transaction = oTran;
                oComand.CommandText = "sp_PatientInsert";
                oComand.CommandType = System.Data.CommandType.StoredProcedure;
                oComand.Parameters.Clear();

                oComand.Parameters.AddWithValue("@DoctorID", oPatient.DoctorID);
                oComand.Parameters.AddWithValue("@FileNumber", oPatient.FileNumber);
                oComand.Parameters.AddWithValue("@FirstName", oPatient.FirstName);
                oComand.Parameters.AddWithValue("@LastName", oPatient.LastName);
                oComand.Parameters.AddWithValue("@IdentityNumber", oPatient.IdentityNumber);
                oComand.Parameters.AddWithValue("@NationalCode", oPatient.NationalCode);
                oComand.Parameters.AddWithValue("@Age", oPatient.Age);
                oComand.Parameters.AddWithValue("@Sex", oPatient.Sex);
                oComand.Parameters.AddWithValue("@Profession", oPatient.Profession);
                oComand.Parameters.AddWithValue("@Telephone", oPatient.Telephone);
                oComand.Parameters.AddWithValue("@Portable", oPatient.Portable);
                oComand.Parameters.AddWithValue("@Address", oPatient.Address);
                oComand.Parameters.AddWithValue("@Malady", oPatient.Malady);
                oComand.Parameters.AddWithValue("@Surgery", oPatient.Surgery);
                oComand.Parameters.AddWithValue("@SurgeryDesc", oPatient.SurgeryDesc);
                oComand.Parameters.AddWithValue("@Drug", oPatient.Drug);
                oComand.Parameters.AddWithValue("@DrugDesc", oPatient.DrugDesc);
                oComand.Parameters.AddWithValue("@Pregnancy", oPatient.Pregnancy);
                oComand.Parameters.AddWithValue("@pregnancyDesc", oPatient.PregnancyDesc);
                oComand.Parameters.AddWithValue("@Description", oPatient.Description);
                oComand.Parameters.AddWithValue("@Alert", oPatient.Alert);
                // oComand.Parameters.AddWithValue("@AlertDesc", oPatient.AlertDesc);
                oComand.Parameters.AddWithValue("@DateOfRegister", oPatient.DateOfRegister);

                if (oPatient.Image != null)
                    //    oComand.Parameters.AddWithValue("@Image", System.DBNull.Value);
                    //else
                    oComand.Parameters.AddWithValue("@Image", oPatient.Image);

                oPatient.PatientID = oComand.ExecuteNonQuery();

                oComand.CommandText = "sp_PatientAssuranceInsert";
                oComand.Parameters.Clear();
                foreach (PatientAssurance pAe in oPatient.PatientAssuranceList)
                {
                    oComand.Parameters.AddWithValue("@PatientID", oPatient.PatientID);
                    oComand.Parameters.AddWithValue("@AssuranceID", pAe.AssuranceID);
                    oComand.Parameters.AddWithValue("@AssuranceCode", pAe.AssuranceCode);
                    oComand.Parameters.AddWithValue("@HandBookID", pAe.HandBookID);
                    oComand.Parameters.AddWithValue("@ValidityDate", pAe.ValidityDate);
                    oComand.ExecuteNonQuery();
                    oComand.Parameters.Clear();
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

        public void PatientFastInsert()
        {
            SqlCommand oComand = new SqlCommand();
            oComand.Connection = oCon;
            try
            {
                oCon.Open();
                //for trial start
                oComand.CommandText = "SELECT Count(*) AS RecCount FROM [tbl_Patient]";
                oComand.CommandType = System.Data.CommandType.Text;
                int patientCount = System.Convert.ToInt32(oComand.ExecuteScalar());
                if (patientCount > 10 && this.RunType != SerialMaker.RunTypes.Full)
                {
                    string errorMessage = "اتمام تعداد مجاز ثبت بیمار جدید در نسخه رایگان";
                    throw new TrialException(errorMessage);
                }
                //end
                oComand.CommandText = "sp_PatientFastInsert";
                oComand.CommandType = System.Data.CommandType.StoredProcedure;


                SqlParameter aSqlParameter = new SqlParameter("@FileNumber", SqlDbType.Int);
                aSqlParameter.Direction = ParameterDirection.Output;
                oComand.Parameters.Add(aSqlParameter);
                oComand.Parameters.AddWithValue("@FirstName", oPatient.FirstName);
                oComand.Parameters.AddWithValue("@LastName", oPatient.LastName);
                oComand.Parameters.AddWithValue("@DoctorID", oPatient.DoctorID);
                oPatient.PatientID = Convert.ToInt32(oComand.ExecuteScalar());

                oPatient.FileNumber = (int)oComand.Parameters["@FileNumber"].Value;
            }
            catch (TrialException tex)
            {
                throw;
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

        public DataSet SelectPatientListByField(int fileNumber, string patientLastname,bool showAllField)
        {
            DataSet aDataSet = new DataSet();
            SqlCommand oComand = new SqlCommand();
            if(showAllField)
                oComand.CommandText = "sp_PatientSelectByField";
            else
                oComand.CommandText = "sp_PatientSelectSomeFieldByField";
            
            oComand.CommandType = System.Data.CommandType.StoredProcedure;

            oComand.Parameters.AddWithValue("@FileNumber", fileNumber);
            oComand.Parameters.AddWithValue("@LastName", "%" + patientLastname + "%");
            oComand.Connection = oCon;
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

        public void PatientEdit()
        {
            SqlCommand oComand = new SqlCommand();
            SqlTransaction oTran = null;
            oComand.Connection = oCon;
            try
            {

                oCon.Open();
                oTran = oCon.BeginTransaction();
                oComand.Transaction = oTran;
                oComand.CommandText = "sp_PatientUpdate";
                oComand.CommandType = System.Data.CommandType.StoredProcedure;

                oComand.Parameters.AddWithValue("@DoctorID", oPatient.DoctorID);
                oComand.Parameters.AddWithValue("@FileNumber", oPatient.FileNumber);
                oComand.Parameters.AddWithValue("@FirstName", oPatient.FirstName);
                oComand.Parameters.AddWithValue("@LastName", oPatient.LastName);
                oComand.Parameters.AddWithValue("@IdentityNumber", oPatient.IdentityNumber);
                oComand.Parameters.AddWithValue("@NationalCode", oPatient.NationalCode);
                oComand.Parameters.AddWithValue("@Age", oPatient.Age);
                oComand.Parameters.AddWithValue("@Sex", oPatient.Sex);
                oComand.Parameters.AddWithValue("@Profession", oPatient.Profession);
                oComand.Parameters.AddWithValue("@Telephone", oPatient.Telephone);
                oComand.Parameters.AddWithValue("@Portable", oPatient.Portable);
                oComand.Parameters.AddWithValue("@Address", oPatient.Address);
                oComand.Parameters.AddWithValue("@Malady", oPatient.Malady);
                oComand.Parameters.AddWithValue("@Surgery", oPatient.Surgery);
                oComand.Parameters.AddWithValue("@SurgeryDesc", oPatient.SurgeryDesc);
                oComand.Parameters.AddWithValue("@Drug", oPatient.Drug);
                oComand.Parameters.AddWithValue("@DrugDesc", oPatient.DrugDesc);
                oComand.Parameters.AddWithValue("@Pregnancy", oPatient.Pregnancy);
                oComand.Parameters.AddWithValue("@pregnancyDesc", oPatient.PregnancyDesc);
                oComand.Parameters.AddWithValue("@Description", oPatient.Description);
                oComand.Parameters.AddWithValue("@Alert", oPatient.Alert);
                //oComand.Parameters.AddWithValue("@AlertDesc", oPatient.AlertDesc);
                oComand.Parameters.AddWithValue("@DateOfRegister", oPatient.DateOfRegister);

                if (oPatient.Image != null)
                    //    oComand.Parameters.AddWithValue("@Image", System.DBNull.Value);
                    //else
                    oComand.Parameters.AddWithValue("@Image", oPatient.Image);
                oComand.Parameters.AddWithValue("@PatientID", oPatient.PatientID);
                oComand.ExecuteNonQuery();

                oComand.CommandText = "sp_PatientAssuranceInsert";
                oComand.Parameters.Clear();
                foreach (PatientAssurance pAe in oPatient.PatientAssuranceList)
                {
                    oComand.Parameters.AddWithValue("@PatientID", oPatient.PatientID);
                    oComand.Parameters.AddWithValue("@AssuranceID", pAe.AssuranceID);
                    oComand.Parameters.AddWithValue("@AssuranceCode", pAe.AssuranceCode);
                    oComand.Parameters.AddWithValue("@HandBookID", pAe.HandBookID);
                    oComand.Parameters.AddWithValue("@ValidityDate", pAe.ValidityDate);
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

        public int GetLastFileNumber()
        {
            SqlCommand oComand = new SqlCommand();
            oComand.Connection = oCon;
            try
            {
                oCon.Open();
                oComand.CommandText = "sp_PatientGetMaxFileNumber";
                oComand.CommandType = System.Data.CommandType.StoredProcedure;
                return (int)oComand.ExecuteScalar();
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

        public void GetPatientByID()
        {
            SqlCommand oComand = new SqlCommand();
            oComand.CommandText = "sp_PatientSelectByID";
            oComand.CommandType = System.Data.CommandType.StoredProcedure;
            oComand.Connection = oCon;

            oComand.Parameters.AddWithValue("@PatientID", oPatient.PatientID);
            try
            {
                oCon.Open();

                SqlDataReader oReader = oComand.ExecuteReader();

                if (oReader.Read())
                {
                    oPatient.DoctorID = System.Convert.ToInt32(oReader["DoctorID"]);
                    oPatient.PatientID = System.Convert.ToInt32(oReader["PatientID"]);
                    oPatient.FileNumber = System.Convert.ToInt32(oReader["FileNumber"]);
                    oPatient.FirstName = oReader["FirstName"].ToString();
                    oPatient.LastName = oReader["LastName"].ToString();
                    oPatient.IdentityNumber = oReader["IdentityNumber"].ToString();
                    oPatient.Age = System.Convert.ToInt32(oReader["Age"]);
                    oPatient.Sex = System.Convert.ToBoolean(oReader["Sex"]); ;
                    oPatient.Profession = oReader["Profession"].ToString();
                    oPatient.Telephone = oReader["Telephone"].ToString();
                    oPatient.Address = oReader["Address"].ToString();
                    oPatient.Description = oReader["Description"].ToString();
                    oPatient.DrugDesc = oReader["DrugDesc"].ToString();
                    oPatient.SurgeryDesc = oReader["SurgeryDesc"].ToString();
                    oPatient.PregnancyDesc = oReader["PregnancyDesc"].ToString();
                    oPatient.Malady =System.Convert.ToInt32(oReader["Malady"]);
                    oPatient.Alert = (bool)oReader["Alert"];
                    oPatient.Image = null;
                    if (oReader["Image"] != System.DBNull.Value)
                        oPatient.Image = (Byte[])oReader["Image"];
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

        public void GetPatientAssuranceList()
        {
            DataSet aDataSet = new DataSet();
            SqlCommand oComand = new SqlCommand();
            oComand.CommandText = "sp_PatientAssuranceSelectByPatientID";
            oComand.CommandType = System.Data.CommandType.StoredProcedure;
            oComand.Connection = oCon;
            try
            {
                oComand.Parameters.AddWithValue("@PatientID", oPatient.PatientID);

                SqlDataAdapter oadapter = new SqlDataAdapter(oComand);

                oadapter.Fill(aDataSet);
                oPatient.PatientAssuranceList.Clear();
                for (int i = 0; i < aDataSet.Tables[0].Rows.Count; i++)
                {
                    PatientAssurance aPatientAssurance = new PatientAssurance();
                    aPatientAssurance.AssuranceCode = aDataSet.Tables[0].Rows[i]["AssuranceCode"].ToString();
                    aPatientAssurance.AssuranceID = (int)aDataSet.Tables[0].Rows[i]["AssuranceID"];
                    aPatientAssurance.AssuranceName = aDataSet.Tables[0].Rows[i]["AssuranceName"].ToString();
                    aPatientAssurance.HandBookID = (Int16)aDataSet.Tables[0].Rows[i]["HandBookID"];
                    aPatientAssurance.PatientAssuranceID = (Int64)aDataSet.Tables[0].Rows[i]["PatientAssuranceID"];
                    aPatientAssurance.PatientID = oPatient.PatientID;
                    aPatientAssurance.ValidityDate = aDataSet.Tables[0].Rows[i]["ValidityDate"].ToString();
                    aPatientAssurance.CountUsed = (int)aDataSet.Tables[0].Rows[i]["CountUsed"];
                    oPatient.PatientAssuranceList.Add(aPatientAssurance);
                }
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
            SqlTransaction oTran = null;
            try
            {
                SqlCommand oComand = new SqlCommand();
                oComand.CommandText = "sp_PatientDelete";
                oComand.CommandType = System.Data.CommandType.StoredProcedure;
                oComand.Parameters.AddWithValue("@PatientID", recID);
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

        public override DataSet Select()
        {
            throw new NotImplementedException();
        }

        public override DataSet FillGrid()
        {
            throw new NotImplementedException();
        }

        public void DisableAlertForm(int patientID)
        {
            SqlCommand oComand = new SqlCommand();
            oComand.Connection = oCon;
            try
            {
                oCon.Open();
                oComand.CommandText = "sp_PatientAlertDisable";
                oComand.CommandType = System.Data.CommandType.StoredProcedure;
                oComand.Parameters.AddWithValue("@PatientID", patientID);
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
    }
}
