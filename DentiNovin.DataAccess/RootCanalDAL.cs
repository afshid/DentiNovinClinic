using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DentiNovin.Common;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace DentiNovin.DataAccess
{
    public class RootCanalDAL : BaseDAL
    {
        private List<Roots> _lRoots;
        public List<Roots> LRoots
        {
            get { return _lRoots;  }
            set { _lRoots = value; }

        }

        public void SelectRoots(Int64 patientTreatmentID)
        {
            SqlCommand oComand = new SqlCommand();
            oComand.CommandText = "sp_RootsSelectByPatientTreatmentID";
            oComand.CommandType = System.Data.CommandType.StoredProcedure;
            oComand.Connection = oCon;
            try
            {
                oComand.Parameters.AddWithValue("@PatientTreatmentID", patientTreatmentID);

                oCon.Open();
                SqlDataReader oreader = oComand.ExecuteReader();

                while (oreader.Read())
                {
                    Roots aRoots = new Roots();
                    aRoots.PatientTreatmentRootID = (Int64)oreader[0];
                    aRoots.PatientTreatmentID = (Int64)oreader[1];
                    aRoots.RootName = oreader[2].ToString();
                    aRoots.RootLenght = (Decimal)oreader[3];
                    LRoots.Add(aRoots);
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
                oComand.CommandText = "sp_RootTreatmentInsert";
                oComand.CommandType = System.Data.CommandType.StoredProcedure;
                foreach (Roots rts in LRoots)
                {
                    oComand.Parameters.Clear();
                    oComand.Parameters.AddWithValue("@PatientTreatmentID", rts.PatientTreatmentID);
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

        public override void Update()
        {
            throw new NotImplementedException();
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

        public override void Delete<T>(T recID)
        {
            throw new NotImplementedException();
        }
    }
}
