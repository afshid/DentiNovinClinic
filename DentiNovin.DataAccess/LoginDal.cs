using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DentiNovin.Common;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Configuration;
using System.Data;
using System.IO;
using System.Configuration;
namespace DentiNovin.DataAccess
{
    public class LoginDal : BaseDAL
    {
        private Login _oLoginD;
        public Login OLoginD
        {
            get { return _oLoginD; }
            set { _oLoginD = value; }
        }

        private User _oUserd;
        public User OUserD
        {
            get { return _oUserd; }
            set { _oUserd = value; }
        }

        public void SearchtUser()
        {
            DateTime start1 = DateTime.Now;
            System.Data.DataSet ds = new System.Data.DataSet();
            //System.Data.SqlClient.SqlConnection oCon = new SqlConnection();
            //oCon.ConnectionString = ConfigurationManager.ConnectionStrings["DentiNovin.Properties.Settings.MNMDentiDBServerConnectionString"].ConnectionString;
            SqlCommand oComand = new SqlCommand();
            oComand.CommandText = "sp_UserSearchByField";
            oComand.CommandType = System.Data.CommandType.StoredProcedure;
            oComand.Connection = oCon;
            try
            {

                oComand.Parameters.AddWithValue("@UserName", OUserD.UserName);
                oComand.Parameters.AddWithValue("@Password", OUserD.Password);
                SqlDataAdapter oadapter = new SqlDataAdapter(oComand);
                oadapter.Fill(ds);
                DateTime end1 = DateTime.Now;
                int userid = 0;
                if (ds.Tables[0].Rows.Count > 0)
                    userid = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
                OUserD.UserID = userid;
                DateTime end2 = DateTime.Now;
                if (userid != 0)
                {
                    List<Forms> lForms;// = new List<Forms>();
                    lForms = ListForms();
                    OUserD.LForms = lForms;
                }
                DateTime end3 = DateTime.Now;
                long testTime1 = (end1.Ticks - start1.Ticks) / TimeSpan.TicksPerSecond;
                long testTime2 = (end2.Ticks - end1.Ticks) / TimeSpan.TicksPerSecond;
                long testTime3 = (end3.Ticks - end2.Ticks) / TimeSpan.TicksPerSecond;

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

        public List<Forms> ListForms()
        {
            SqlCommand oComand = new SqlCommand();
            try
            {
                oComand.CommandText = "sp_UserFormsSelectByUserID";
                oComand.CommandType = System.Data.CommandType.StoredProcedure;
                oComand.Connection = oCon;

                oComand.Parameters.AddWithValue("@UserID", OUserD.UserID);
                oCon.Open();
                List<Forms> Lforms = new List<Forms>();
                SqlDataReader oreader = oComand.ExecuteReader();

                while (oreader.Read())
                {
                    Forms aforms = new Forms();
                    int x = oreader.GetInt32(0);
                    aforms.FormID = x;
                    Lforms.Add(aforms);
                }
                OUserD.LForms = Lforms;
                return Lforms;
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

        public override DataSet Select()
        {
            throw new NotImplementedException();
        }

        public override DataSet FillGrid()
        {
            throw new NotImplementedException();
        }

        public override void Delete<T>(T recID)
        {
            throw new NotImplementedException();
        }
    }
}
