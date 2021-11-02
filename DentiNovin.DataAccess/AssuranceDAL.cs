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
    public class AssuranceDAL:BaseDAL
    {

        public DataSet GetAssuranceList(bool showForPrescription)
        {
            try
            {
                DataSet aDataSet = new DataSet();
                SqlCommand oComand = new SqlCommand();
                oComand.CommandText = "sp_AssuranceSelect";
                oComand.CommandType = System.Data.CommandType.StoredProcedure;
                oComand.Parameters.AddWithValue("@ShowForPrescription", showForPrescription);

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
