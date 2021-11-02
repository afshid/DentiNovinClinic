using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DentiNovin.Common;
using System.Data;
using System.Data.OleDb;
using System.Collections;
using System.Data.SqlClient;
using System.Configuration;

namespace DentiNovin.DataAccess
{
    public class UserAccessDal : BaseDAL
    {
        private User _oUserd;
        public User OUserD
        {
            get
            {
                if (_oUserd == null)
                    _oUserd = new User();
                return _oUserd;
            }
            set { _oUserd = value; }
        }


        private Int32 _oRowSelectIDD;
        public Int32 ORowSelectIDD
        {
            get { return _oRowSelectIDD; }
            set { _oRowSelectIDD = value; }
        }

        //public void SaveInfo()
        //{
        //    System.Data.DataSet ds = new System.Data.DataSet();
        //    SqlConnection oCon = new SqlConnection();
        //    oCon.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\Documents and Settings\\maryam\\Desktop\\MNMDenti.mdb";
        //    SqlCommand oComand = new SqlCommand();
        //    oComand.CommandText = "sp_UserInsert";
        //    oComand.CommandType = System.Data.CommandType.StoredProcedure;
        //    oComand.Connection = oCon;

        //    SqlParameter oparam1 = new SqlParameter();
        //    oparam1.ParameterName = "@FullName";
        //    oparam1.OleDbType = System.Data.OleDb.OleDbType.VarChar;
        //    oparam1.Value = OUserD.FullName;
        //    oComand.Parameters.Add(oparam1);

        //    SqlParameter oparam2 = new SqlParameter();
        //    oparam2.ParameterName = "@UserName";
        //    oparam2.OleDbType = System.Data.OleDb.OleDbType.VarChar;
        //    oparam2.Value = OUserD.UserName;
        //    oComand.Parameters.Add(oparam2);

        //    SqlParameter oparam3 = new SqlParameter();
        //    oparam3.ParameterName = "@Password";
        //    oparam3.OleDbType = System.Data.OleDb.OleDbType.VarChar;
        //    oparam3.Value = OUserD.Password;
        //    oComand.Parameters.Add(oparam3);

        //    oCon.Open();

        //    int rowAffected = Convert.ToInt32(oComand.ExecuteNonQuery());
        //    oComand.CommandText = "select max(UserID) from tbl_User";
        //    oComand.CommandType = System.Data.CommandType.Text;
        //    int MaxRecord = Convert.ToInt32(oComand.ExecuteScalar());
        //    OUserD.UserID = MaxRecord;

        //    for (int i = 0; i < OUserD.LForms.Count; i++)
        //    {
        //        oComand.CommandText = "sp_UserFormsInsert";
        //        oComand.CommandType = System.Data.CommandType.StoredProcedure;
        //        oComand.Parameters.Clear();
        //        SqlParameter oparam4 = new SqlParameter();
        //        oparam4.ParameterName = "@UserID";
        //        oparam4.OleDbType = System.Data.OleDb.OleDbType.Integer;
        //        oparam4.Value = OUserD.UserID;
        //        oComand.Parameters.Add(oparam4);

        //        SqlParameter oparam5 = new SqlParameter();
        //        oparam5.ParameterName = "@FormID";
        //        oparam5.OleDbType = System.Data.OleDb.OleDbType.Integer;
        //        oparam5.Value = OUserD.LForms[i].FormID;
        //        oComand.Parameters.Add(oparam5);

        //        oComand.ExecuteNonQuery();
        //    }

        //    oCon.Close();

        //}

        public DataSet FillTreeview()
        {
            DataSet ds = new DataSet();
            SqlCommand oComand = new SqlCommand();

            oComand.CommandText = "select Name,FormsID from tbl_Forms";
            oComand.CommandType = System.Data.CommandType.Text;
            oComand.Connection = oCon;
            try
            {
                SqlDataAdapter oDataAdapte = new SqlDataAdapter(oComand);
                oDataAdapte.Fill(ds);
            }
            catch (Exception ex)
            {
                throw;
            }

            return ds;
        }

        //public DataSet FillgridUser()
        //{
        //    System.Data.DataSet ds = new System.Data.DataSet();
        //    SqlConnection oCon = new SqlConnection();
        //    oCon.ConnectionString =" Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\Documents and Settings\\maryam\\Desktop";

        //    SqlCommand oComand = new SqlCommand();
        //    oComand.CommandText = "select UserID,FullName,Username from tbl_user";
        //    oComand.CommandType = System.Data.CommandType.Text;
        //    oComand.Connection = oCon;
        //    oCon.Open();
        //    SqlDataAdapter oadapter = new SqlDataAdapter(oComand);
        //    oadapter.Fill(ds);
        //    return ds;
        //}

        //public void DeleteUser(int ORowSelectIDD)
        //{

        //    SqlConnection oCon = new SqlConnection();
        //    oCon.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\Documents and Settings\\maryam\\Desktop\\MNMDenti.mdb";

        //    SqlCommand oComand = new SqlCommand();
        //    oComand.CommandText = "sp_UserFormsDeleteByUserID";
        //    oComand.CommandType = System.Data.CommandType.StoredProcedure;
        //    SqlParameter oparam1 = new SqlParameter();
        //    oparam1.ParameterName = "@UserID";
        //    oparam1.OleDbType = System.Data.OleDb.OleDbType.Integer;
        //    oparam1.Value = ORowSelectIDD;
        //    oComand.Parameters.Add(oparam1);
        //    oComand.Connection = oCon;
        //    oCon.Open();
        //    oComand.ExecuteNonQuery();

        //    oComand.CommandText = "sp_UserDeleteByID";
        //    oComand.CommandType = System.Data.CommandType.StoredProcedure;
        //    SqlParameter oparam2 = new SqlParameter();
        //    oparam2.ParameterName = "@UserID";
        //    oparam2.OleDbType = System.Data.OleDb.OleDbType.Integer;
        //    oparam2.Value = ORowSelectIDD;
        //    oComand.Parameters.Add(oparam2);
        //    oComand.Connection = oCon;
        //    oComand.ExecuteNonQuery();

        //    oCon.Close();
        //}

        public List<Forms> GetListFormsSelectForUser(int ORowSelectID)
        {
            List<Forms> Lforms = new List<Forms>();

            ArrayList a = new ArrayList();
            SqlCommand oComand = new SqlCommand();
            oComand.CommandText = "sp_UserFormsSelectByUserID";
            oComand.CommandType = System.Data.CommandType.StoredProcedure;
            oComand.Parameters.AddWithValue("@UserID", ORowSelectID);
            try
            {
                oComand.Connection = oCon;
                oCon.Open();
                SqlDataReader oreader = oComand.ExecuteReader();

                while (oreader.Read())
                {
                    Forms aforms = new Forms();
                    aforms.FormID = (int)oreader["FormsID"];
                    aforms.Code = oreader["Code"].ToString();
                    aforms.Name = oreader["Name"].ToString();
                    Lforms.Add(aforms);

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
            return Lforms;
        }

        //public void  EditUser()
        //{
        //   // System.Data.DataSet ds = new DataSet();
        //    SqlConnection oCon = new SqlConnection();
        //    oCon.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\Documents and Settings\\maryam\\Desktop\\MNMDenti.mdb";

        //    SqlCommand oComand = new SqlCommand();
        //    oComand.CommandText = "sp_UserUpdate";

        //    oComand.CommandType = System.Data.CommandType.StoredProcedure;
        //   // SqlDataAdapter oadapter = new SqlDataAdapter("sp_UserUpdate", oCon);
        //    oComand.Connection = oCon;


        //    SqlParameter oparam1 = new SqlParameter();
        //    oparam1.ParameterName = "@FullName";
        //    oparam1.OleDbType = System.Data.OleDb.OleDbType.VarChar;
        //    oparam1.Value = OUserD.FullName;
        //    oComand.Parameters.Add(oparam1);

        //    SqlParameter oparam2 = new SqlParameter();
        //    oparam2.ParameterName = "@Username";
        //    oparam2.OleDbType = System.Data.OleDb.OleDbType.VarChar;
        //    oparam2.Value = OUserD.UserName;
        //    oComand.Parameters.Add(oparam2);

        //    SqlParameter oparam3 = new SqlParameter();
        //    oparam3.ParameterName = "@Password";
        //    oparam3.OleDbType = System.Data.OleDb.OleDbType.VarChar;
        //    oparam3.Value = OUserD.Password;
        //    oComand.Parameters.Add(oparam3);

        //    SqlParameter oparam4 = new SqlParameter();
        //    oparam4.ParameterName = "@UserID";
        //    oparam4.OleDbType = System.Data.OleDb.OleDbType.Integer;
        //    oparam4.Value = OUserD.UserID;
        //    oComand.Parameters.Add(oparam4);

        //    oCon.Open();



        //    int rowAffected = Convert.ToInt32(oComand.ExecuteNonQuery());
        //    oCon.Close();

        //}

        public override void Insert()
        {
            System.Data.DataSet ds = new System.Data.DataSet();
            SqlTransaction oTran=null;
            SqlCommand oComand = new SqlCommand();

            try
            {
                oCon.Open();
                oTran = oCon.BeginTransaction();
                oComand.CommandText = "sp_UserInsert";
                oComand.CommandType = System.Data.CommandType.StoredProcedure;
                oComand.Connection = oCon;
                oComand.Transaction = oTran;
                oComand.Parameters.AddWithValue("@Username", OUserD.UserName);
                oComand.Parameters.AddWithValue("@Password", OUserD.Password);
                oComand.Parameters.AddWithValue("@Active", OUserD.Active);
                oComand.Parameters.AddWithValue("@FullName", OUserD.FullName);
                oComand.Parameters.AddWithValue("@DateOfRegister", OUserD.DateOfRegister);
                OUserD.UserID = System.Convert.ToInt32(oComand.ExecuteScalar());
                oComand.CommandText = "sp_UserFormsInsert";
                oComand.CommandType = System.Data.CommandType.StoredProcedure;
                for (int k = 0; k < OUserD.LForms.Count; k++)
                {
                    oComand.Parameters.Clear();
                    oComand.Parameters.AddWithValue("@UserID", OUserD.UserID);
                    oComand.Parameters.AddWithValue("@FormsID", OUserD.LForms[k].FormID);
                    oComand.ExecuteNonQuery();
                    //throw new DivideByZeroException();
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
            SqlTransaction oTran = null;
            SqlCommand oComand = new SqlCommand();
            oComand.CommandText = "sp_UserUpdate";
            oComand.CommandType = System.Data.CommandType.StoredProcedure;
            oComand.Connection = oCon;

            oComand.Parameters.AddWithValue("@Username", OUserD.UserName);
            oComand.Parameters.AddWithValue("@Password", OUserD.Password);
            oComand.Parameters.AddWithValue("@Active", OUserD.Active);
            oComand.Parameters.AddWithValue("@FullName", OUserD.FullName);
            oComand.Parameters.AddWithValue("@DateOfRegister", OUserD.DateOfRegister);
            oComand.Parameters.AddWithValue("@UserID", OUserD.UserID);

            try
            {
                oCon.Open();
                oTran = oCon.BeginTransaction();
                oComand.Transaction = oTran;
                oComand.ExecuteNonQuery();
                oComand.CommandText = "sp_UserFormsInsert";
                for (int k = 0; k < OUserD.LForms.Count; k++)
                {
                    oComand.Parameters.Clear();
                    oComand.Parameters.AddWithValue("@UserID", OUserD.UserID);
                    oComand.Parameters.AddWithValue("@FormsID", OUserD.LForms[k].FormID);
                    oComand.ExecuteNonQuery();
                   // throw new DivideByZeroException();
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

        public override DataSet FillGrid()
        {
            System.Data.DataSet ds = new System.Data.DataSet();
            SqlCommand oComand = new SqlCommand();
            oComand.CommandText = "sp_UserSelect";
            oComand.CommandType = System.Data.CommandType.StoredProcedure;
            oComand.Connection = oCon;
            try
            {
                SqlDataAdapter oadapter = new SqlDataAdapter(oComand);
                oadapter.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {

                throw;
            }

           
        }

        public void SaveInfo()
        {
            throw new NotImplementedException();
        }

        public override void Delete<T>(T recID)
        {
            SqlTransaction oTran = null;
            SqlCommand oComand = new SqlCommand();

            try
            {
                oComand.Connection = oCon;
                oCon.Open();
                oTran = oCon.BeginTransaction();
                oComand.Transaction = oTran;
                oComand.CommandText = "sp_UserDeleteByID";
                oComand.CommandType = System.Data.CommandType.StoredProcedure;
                oComand.Parameters.AddWithValue("@UserID", recID);
                oComand.Connection = oCon;

                oComand.ExecuteNonQuery();
                oTran.Commit();
                //throw new DivideByZeroException();
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
