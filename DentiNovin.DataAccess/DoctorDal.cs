using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DentiNovin.Common;
using System.Collections;
using System.Data.OleDb;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DentiNovin.DataAccess
{
    public class DoctorDal : BaseDAL
    {
        private Doctor _doctorD;
        public Doctor DoctorD
        {
            get { return _doctorD; }
            set { _doctorD = value; }
        }

        public System.Data.DataSet FillGroupCheckBoxList()
        {
            try
            {
                System.Data.DataSet ds = new System.Data.DataSet();
                SqlCommand oComand = new SqlCommand();
                oComand.CommandText = "sp_GroupSelect";
                oComand.CommandType = System.Data.CommandType.StoredProcedure;
                oComand.Connection = oCon;
                SqlDataAdapter oadapter = new SqlDataAdapter(oComand);
                oadapter.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<DoctorShift> GetListGroupSelectForDoc(int ORowSelectID)
        {
            List<DoctorShift> LDoctorShift = new List<DoctorShift>();
            ArrayList a = new ArrayList();
            try
            {
                SqlCommand oComand = new SqlCommand();
                oComand.CommandText = "sp_DoctorShiftSelectByDoctorID";
                oComand.CommandType = System.Data.CommandType.StoredProcedure;

                oComand.Parameters.AddWithValue("@DoctorID", ORowSelectID);
                oComand.Connection = oCon;
                oCon.Open();
                SqlDataReader oreader = oComand.ExecuteReader();

                while (oreader.Read())
                {
                    DoctorShift aDoctorShift = new DoctorShift();
                    aDoctorShift.SelectedShiftCode = oreader.GetInt32(0);
                    aDoctorShift.SelectedDays = (int)oreader[1];
                    LDoctorShift.Add(aDoctorShift);
                }

                return LDoctorShift;

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
            System.Data.DataSet ds = new System.Data.DataSet();
            SqlCommand oComand = new SqlCommand();
            SqlTransaction oTran = null;
            oComand.CommandText = "sp_DoctorInsert";
            oComand.CommandType = System.Data.CommandType.StoredProcedure;
            oComand.Connection = oCon;

            oComand.Parameters.AddWithValue("@Name", DoctorD.Docname);
            oComand.Parameters.AddWithValue("@LastName", DoctorD.LastName);
            oComand.Parameters.AddWithValue("@Code", DoctorD.Code);
            oComand.Parameters.AddWithValue("@PhoneNumber", DoctorD.PhoneNumber);
            oComand.Parameters.AddWithValue("@Address", DoctorD.Address);
            oComand.Parameters.AddWithValue("@Active", DoctorD.Active);
            oComand.Parameters.AddWithValue("@VisitPrice", DoctorD.VisitPrice);
            oComand.Parameters.AddWithValue("@IdentificationCodeKhadamat", DoctorD.IdentificationCodeKhadamat);
            oComand.Parameters.AddWithValue("@IdentificationCodeMosallah", DoctorD.IdentificationCodeMosallah);
            oComand.Parameters.AddWithValue("@DoctorKind", DoctorD.DoctorKind);
            oComand.Parameters.AddWithValue("@HaveContractWithKhadamat", DoctorD.HaveContractWithKhadamat);
            oComand.Parameters.AddWithValue("@HaveContractWithMosallah", DoctorD.HaveContractWithMosallah);
            oComand.Parameters.AddWithValue("@CellPhoneNumber", DoctorD.CellPhoneNumber);
            try
            {
                oCon.Open();
                oTran = oCon.BeginTransaction();
                oComand.Transaction = oTran;
                DoctorD.DoctorID = Convert.ToInt32(oComand.ExecuteScalar());
                oComand.Parameters.Clear();
                oComand.CommandText = "sp_GroupDoctorInsert";
                oComand.CommandType = System.Data.CommandType.StoredProcedure;

                for (int i = 0; i < DoctorD.LDoctorShift.Count; i++)
                {
                    oComand.Parameters.AddWithValue("@DoctorID", DoctorD.DoctorID);
                    oComand.Parameters.AddWithValue("@GroupCode", DoctorD.LDoctorShift[i].SelectedShiftCode);
                    oComand.Parameters.AddWithValue("@DaysNumber", DoctorD.LDoctorShift[i].SelectedDays);
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
            System.Data.DataSet ds = new System.Data.DataSet();
            SqlCommand oComand = new SqlCommand();
            SqlTransaction oTran = null;
            oComand.CommandText = "sp_DoctorUpdateBYDoctorID";
            oComand.CommandType = System.Data.CommandType.StoredProcedure;
            oComand.Connection = oCon;

            oComand.Parameters.AddWithValue("@DoctorID", DoctorD.DoctorID);
            oComand.Parameters.AddWithValue("@Name", DoctorD.Docname);
            oComand.Parameters.AddWithValue("@LastName", DoctorD.LastName);
            oComand.Parameters.AddWithValue("@Code", DoctorD.Code);
            oComand.Parameters.AddWithValue("@PhoneNumber", DoctorD.PhoneNumber.Trim());
            oComand.Parameters.AddWithValue("@Address", DoctorD.Address);
            oComand.Parameters.AddWithValue("@Active", DoctorD.Active);
            oComand.Parameters.AddWithValue("@VisitPrice", DoctorD.VisitPrice);
            oComand.Parameters.AddWithValue("@IdentificationCodeKhadamat", DoctorD.IdentificationCodeKhadamat);
            oComand.Parameters.AddWithValue("@IdentificationCodeMosallah", DoctorD.IdentificationCodeMosallah);
            oComand.Parameters.AddWithValue("@DoctorKind", DoctorD.DoctorKind);
            oComand.Parameters.AddWithValue("@HaveContractWithKhadamat", DoctorD.HaveContractWithKhadamat);
            oComand.Parameters.AddWithValue("@HaveContractWithMosallah", DoctorD.HaveContractWithMosallah);
            oComand.Parameters.AddWithValue("@CellPhoneNumber", DoctorD.CellPhoneNumber.Trim());
            try
            {
                oCon.Open();
                oTran = oCon.BeginTransaction();
                oComand.Transaction = oTran;
                oComand.ExecuteNonQuery();

                for (int i = 0; i < DoctorD.LDoctorShift.Count; i++)
                {
                    oComand.Parameters.Clear();
                    oComand.CommandText = "sp_GroupDoctorUpdateByFields";
                    oComand.CommandType = System.Data.CommandType.StoredProcedure;


                    oComand.Parameters.AddWithValue("@DaysNumber", DoctorD.LDoctorShift[i].SelectedDays);
                    oComand.Parameters.AddWithValue("@DoctorID", DoctorD.DoctorID);
                    oComand.Parameters.AddWithValue("@GroupCode", DoctorD.LDoctorShift[i].SelectedShiftCode);

                    if (oComand.ExecuteNonQuery() == 0)
                    {
                        oComand.Parameters.Clear();
                        oComand.CommandText = "sp_GroupDoctorInsert";
                        oComand.CommandType = System.Data.CommandType.StoredProcedure;


                        oComand.Parameters.AddWithValue("@DoctorID", DoctorD.DoctorID);
                        oComand.Parameters.AddWithValue("@GroupCode", DoctorD.LDoctorShift[i].SelectedShiftCode);
                        oComand.Parameters.AddWithValue("@DaysNumber", DoctorD.LDoctorShift[i].SelectedDays);

                        oComand.ExecuteNonQuery();
                    }
                   
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
        }

        public override DataSet Select()
        {
            throw new NotImplementedException();
        }

        public DataSet GetDoctorList(bool showOnlyActive)
        {
            try
            {
                DataSet ds = new DataSet();
                SqlCommand oComand = new SqlCommand();
                oComand.CommandText = "sp_DoctorSelect";
                oComand.CommandType = System.Data.CommandType.StoredProcedure;
                oComand.Parameters.AddWithValue("@ShowOnlyActive", showOnlyActive);
                oComand.Connection = oCon;
                SqlDataAdapter oadapter = new SqlDataAdapter(oComand);
                oadapter.Fill(ds);
                return ds;
            }
            catch (Exception)
            {
                throw;
            }


        }

        public override DataSet FillGrid()
        {
            throw new NotImplementedException();
        }

        public override void Delete<T>(T recID)
        {
            SqlCommand oComand = new SqlCommand();
            SqlTransaction oTran = null;
            oComand.CommandText = "sp_DoctorDeleteByID";
            oComand.CommandType = System.Data.CommandType.StoredProcedure;

            oComand.Parameters.AddWithValue("@DoctorID", recID);

            oComand.Connection = oCon;
            try
            {
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
    }
}
