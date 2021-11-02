using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DentiClinic.DataAccess
{
       public  class ListUserDal
    {
           private Int32 _oRowSelectIDD;
        public Int32 ORowSelectIDD
        {
            get { return _oRowSelectIDD; }
            set { _oRowSelectIDD = value; }
        }

       public DataSet  FillgridUser()
       {
           System.Data.DataSet ds = new System.Data.DataSet();
           System.Data.OleDb.OleDbConnection oCon = new System.Data.OleDb.OleDbConnection();
           oCon.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\Documents and Settings\\afshid\\My Documents\\MNMDenti.mdb";
           
            System.Data.OleDb.OleDbCommand oComand=new System.Data.OleDb.OleDbCommand();
            oComand.CommandText="select UserID,FullName,Username from tbl_user";
            oComand.CommandType=System.Data.CommandType.Text;
            oComand.Connection = oCon;
            oCon.Open();
            System.Data.OleDb.OleDbDataAdapter oadapter = new System.Data.OleDb.OleDbDataAdapter(oComand);
            oadapter.Fill(ds);
            return ds;

       }
       public void DeleteRowByUserID(int ORowSelectIDD)
       {

         //  System.Data.DataSet ds = new System.Data.DataSet();
           System.Data.OleDb.OleDbConnection oCon = new System.Data.OleDb.OleDbConnection();
           oCon.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\Documents and Settings\\afshid\\My Documents\\MNMDenti.mdb";

           System.Data.OleDb.OleDbCommand oComand = new System.Data.OleDb.OleDbCommand();
           oComand.CommandText = "tbl_sp_DeleteUserByID";
           oComand.CommandType = System.Data.CommandType.StoredProcedure;
           System.Data.OleDb.OleDbParameter oparam1 = new System.Data.OleDb.OleDbParameter();
           oparam1.ParameterName = "@UserID";
           oparam1.OleDbType = System.Data.OleDb.OleDbType.Integer;
           oparam1.Value = ORowSelectIDD;
           oComand.Parameters.Add(oparam1);
           oComand.Connection = oCon;
           oCon.Open();
           oComand.ExecuteNonQuery();
          

       
       }
       public void DeleteFormsByUserID(int ORowSelectIDD)
       {

           //  System.Data.DataSet ds = new System.Data.DataSet();
           System.Data.OleDb.OleDbConnection oCon = new System.Data.OleDb.OleDbConnection();
           oCon.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\Documents and Settings\\afshid\\My Documents\\MNMDenti.mdb";

           System.Data.OleDb.OleDbCommand oComand = new System.Data.OleDb.OleDbCommand();
           oComand.CommandText = "sp_DeleteFormsBYUserID";
           oComand.CommandType = System.Data.CommandType.StoredProcedure;
           System.Data.OleDb.OleDbParameter oparam1 = new System.Data.OleDb.OleDbParameter();
           oparam1.ParameterName = "@UserID";
           oparam1.OleDbType = System.Data.OleDb.OleDbType.Integer;
           oparam1.Value = ORowSelectIDD;
           oComand.Parameters.Add(oparam1);
           oComand.Connection = oCon;
           oCon.Open();
           oComand.ExecuteNonQuery();



       }

    }
}
