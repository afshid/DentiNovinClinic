using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace DentiClinic.DataAccess
{
   public class PatientDossierDAL
    {
       public DataSet GetAccomplishedTreatmentList(int PatientID, int ToothNumber,int ToothDirection)
       {
           DataSet aDataSet = new DataSet();
           System.Data.OleDb.OleDbConnection oCon = new System.Data.OleDb.OleDbConnection();
           oCon.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=c:\\MNMDenti.mdb";
           System.Data.OleDb.OleDbCommand oComand = new System.Data.OleDb.OleDbCommand();
           //oComand.CommandText = "sp_TreatmentTariffSelect";
           oComand.CommandText = "sp_PatientAccomplishedTreatmentSelectByField";
           oComand.CommandType = System.Data.CommandType.StoredProcedure;
           oComand.Connection = oCon;

           System.Data.OleDb.OleDbParameter oparam1 = new System.Data.OleDb.OleDbParameter();
           oparam1.ParameterName = "@ToothNumber";
           oparam1.OleDbType = System.Data.OleDb.OleDbType.Integer;
           oparam1.Value = ToothNumber;
           oComand.Parameters.Add(oparam1);

           System.Data.OleDb.OleDbParameter oparam2 = new System.Data.OleDb.OleDbParameter();
           oparam2.ParameterName = "@ToothDirection";
           oparam2.OleDbType = System.Data.OleDb.OleDbType.Integer;
           oparam2.Value = ToothDirection;
           oComand.Parameters.Add(oparam2);

           System.Data.OleDb.OleDbParameter oparam0 = new System.Data.OleDb.OleDbParameter();
           oparam0.ParameterName = "@PatientID";
           oparam0.OleDbType = System.Data.OleDb.OleDbType.Integer;
           oparam0.Value = PatientID;
           oComand.Parameters.Add(oparam0);

           System.Data.OleDb.OleDbDataAdapter oAdapter = new System.Data.OleDb.OleDbDataAdapter(oComand);
           oAdapter.Fill(aDataSet);
           return aDataSet;
       }
    }
}
