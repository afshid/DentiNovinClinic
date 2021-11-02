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
    public class TreatmentDAL : BaseDAL
    {
        private Treatment _oTreatment;
        public Treatment oTreatment
        {
            get { return _oTreatment; }
            set { _oTreatment = value; }
        }

        private AssuranceService _oAssuranceService;
        public AssuranceService OAssuranceService
        {
            get
            {
                return _oAssuranceService;
            }
            set { _oAssuranceService = value; }
        }

        public void TreatmentServiceInsert()
        {
            SqlCommand oComand = new SqlCommand();
            SqlTransaction oTran = null;

            oComand.Connection = oCon;
            try
            {
                oCon.Open();
                oTran = oCon.BeginTransaction();
                oComand.Transaction = oTran;
                oComand.CommandText = "sp_TreatmentServiceInsert";
                oComand.CommandType = System.Data.CommandType.StoredProcedure;
                oComand.Parameters.AddWithValue("@TreatmentClassID", oTreatment.TreatmentClassID);
                oComand.Parameters.AddWithValue("@Code", oTreatment.Code);
                oComand.Parameters.AddWithValue("@PersianName", oTreatment.PersianName);
                oComand.Parameters.AddWithValue("@LatinName", oTreatment.LatinName);
                oComand.Parameters.AddWithValue("@Abbreviation", oTreatment.AbbreviationName);
                oComand.Parameters.AddWithValue("@Price", oTreatment.Price);
                oComand.Parameters.AddWithValue("@TreatmentArea", oTreatment.TreatmentArea);
                oComand.Parameters.AddWithValue("@DrawType", oTreatment.DrawType);
                oComand.Parameters.AddWithValue("@BrushType", oTreatment.BrushType);
                oComand.Parameters.AddWithValue("@BrushColor", oTreatment.BrushColor);
                oComand.Parameters.AddWithValue("@ShowInToolBox", oTreatment.ShowInToolBox);
                oComand.Parameters.AddWithValue("@ToolBoxImageIndex", oTreatment.ToolBoxImageIndex);
                oComand.Parameters.AddWithValue("@DateOfRegister", oTreatment.DateOfRegister);
                oComand.Parameters.AddWithValue("@ShowRootInfoForm", oTreatment.ShowRootInfoForm);
                oComand.Parameters.AddWithValue("@MarkToothMissing", oTreatment.MarkToothMissing);

                int LastInsertID = Convert.ToInt32(oComand.ExecuteScalar());

                if (oTreatment.TreatmentArea == 1 || oTreatment.TreatmentArea == 3)
                {
                    oComand.CommandText = "sp_RelatedTreatmentServiceInsert";
                    for (int i = 0; i < oTreatment.RelateCode.Count; i++)
                    {
                        oComand.Parameters.Clear();
                        oComand.Parameters.AddWithValue("@PTreatmentServiceID", LastInsertID);
                        if (oTreatment.RelateCode[i] == 0)
                            oTreatment.RelateCode[i] = LastInsertID;
                        oComand.Parameters.AddWithValue("@CTreatmentServiceID", oTreatment.RelateCode[i]);
                        oComand.Parameters.AddWithValue("@SurfaceCount", i + 1);
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

        public DataSet GetTreatmentClassList()
        {
            try
            {
                DataSet aDataSet = new DataSet();
                SqlCommand oComand = new SqlCommand();
                oComand.CommandText = "sp_TreatmentClassSelect";
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

        public DataSet GetTreatmentServiceList(ServiceFilterType sft, string currentDate, int treatmentClassID, string treatmentCode, string treatmentName, bool showPersian)
        {
            try
            {
                DataSet aDataSet = new DataSet();
                SqlCommand oComand = new SqlCommand();
                if (sft == ServiceFilterType.OnlyNotRelated)
                    oComand.CommandText = "sp_TreatmentServiceSelect";
                else
                    oComand.CommandText = "sp_TreatmentServiceSelect";
                oComand.CommandType = System.Data.CommandType.StoredProcedure;
                oComand.Connection = oCon;
                if (sft != ServiceFilterType.ShowAll)
                    oComand.Parameters.AddWithValue("@ShowInToolBox", (int)sft);
                if (currentDate != "")
                    oComand.Parameters.AddWithValue("@DateOfRegister", currentDate);
                if (treatmentClassID != 0)
                    oComand.Parameters.AddWithValue("@TreatmentClassID", treatmentClassID);
                if (treatmentCode != "")
                    oComand.Parameters.AddWithValue("@TreatmentCode", treatmentCode);
                if (treatmentName != "")
                    oComand.Parameters.AddWithValue("@TreatmentName", treatmentName);
                oComand.Parameters.AddWithValue("@ShowPersianName", showPersian);
                SqlDataAdapter oAdapter = new SqlDataAdapter(oComand);
                oAdapter.Fill(aDataSet);
                return aDataSet;
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public DataSet GetTreatmentServiceListForTreatmentBox()
        {
            try
            {
                DataSet aDataSet = new DataSet();
                SqlCommand oComand = new SqlCommand();
                oComand.CommandText = "sp_TreatmentServiceSelectForTreatmentBox";
                oComand.CommandType = System.Data.CommandType.StoredProcedure;
                oComand.Connection = oCon;
                SqlDataAdapter oAdapter = new SqlDataAdapter(oComand);
                oAdapter.Fill(aDataSet, "AllTreatmentService");
                oComand.CommandText = "sp_TreatmentServiceSelectTopTen";
                oAdapter.Fill(aDataSet, "TopTenTreatmentService");
                return aDataSet;
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public DataSet GetRelatedTreatmentServiceList(int serviceID)
        {
            try
            {
                DataSet aDataSet = new DataSet();
                SqlCommand oComand = new SqlCommand();

                oComand.CommandText = "sp_RelatedTreatmentServiceSelect";
                oComand.CommandType = System.Data.CommandType.StoredProcedure;
                oComand.Connection = oCon;
                oComand.Parameters.AddWithValue("@PtreatmentServiceID", serviceID);
                SqlDataAdapter oAdapter = new SqlDataAdapter(oComand);
                oAdapter.Fill(aDataSet);
                return aDataSet;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public void TreatmentServiceEdit()
        {
            SqlCommand oComand = new SqlCommand();
            SqlTransaction oTran = null;
            oComand.Connection = oCon;
            try
            {
                oCon.Open();
                oTran = oCon.BeginTransaction();
                oComand.Transaction = oTran;
                oComand.CommandType = System.Data.CommandType.StoredProcedure;
                oComand.CommandText = "sp_TreatmentServiceUpdate";

                oComand.Parameters.AddWithValue("@TreatmentClassID", oTreatment.TreatmentClassID);
                oComand.Parameters.AddWithValue("@Code", oTreatment.Code);
                oComand.Parameters.AddWithValue("@PersianName", oTreatment.PersianName);
                oComand.Parameters.AddWithValue("@LatinName", oTreatment.LatinName);
                oComand.Parameters.AddWithValue("@Abbreviation", oTreatment.AbbreviationName);
                oComand.Parameters.AddWithValue("@Price", oTreatment.Price);
                oComand.Parameters.AddWithValue("@TreatmentArea", oTreatment.TreatmentArea);
                oComand.Parameters.AddWithValue("@DrawType", oTreatment.DrawType);
                oComand.Parameters.AddWithValue("@BrushType", oTreatment.BrushType);
                oComand.Parameters.AddWithValue("@BrushColor", oTreatment.BrushColor);
                oComand.Parameters.AddWithValue("@ShowInToolBox", oTreatment.ShowInToolBox);
                oComand.Parameters.AddWithValue("@ToolBoxImageIndex", oTreatment.ToolBoxImageIndex);
                oComand.Parameters.AddWithValue("@DateOfRegister", oTreatment.DateOfRegister);
                oComand.Parameters.AddWithValue("@TreatmentServiceID", oTreatment.TreatmentServiceID);
                oComand.Parameters.AddWithValue("@ShowRootInfoForm", oTreatment.ShowRootInfoForm);
                oComand.Parameters.AddWithValue("@MarkToothMissing", oTreatment.MarkToothMissing);

                oComand.ExecuteNonQuery();

                oComand.CommandText = "sp_RelatedTreatmentServiceDelete";
                oComand.CommandType = System.Data.CommandType.StoredProcedure;

                oComand.Parameters.Clear();
                oComand.Parameters.AddWithValue("@PtreatmentServiceID", oTreatment.TreatmentServiceID);
                oComand.ExecuteNonQuery();

                if (oTreatment.TreatmentArea == (int)TreatmentArea.Surface || oTreatment.TreatmentArea == (int)TreatmentArea.Root)
                {

                    oComand.CommandText = "sp_RelatedTreatmentServiceInsert";
                    for (int i = 0; i < oTreatment.RelateCode.Count; i++)
                    {
                        if (oTreatment.TreatmentArea == (int)TreatmentArea.Root && i > 2)
                            break;
                        oComand.Parameters.Clear();
                        oComand.Parameters.AddWithValue("@PTreatmentServiceID", oTreatment.TreatmentServiceID);
                        if (oTreatment.RelateCode[i] == 0)
                            oTreatment.RelateCode[i] = oTreatment.TreatmentServiceID;
                        oComand.Parameters.AddWithValue("@CTreatmentServiceID", oTreatment.RelateCode[i]);
                        oComand.Parameters.AddWithValue("@SurfaceCount", i + 1);
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

        public void TreatmentUsedCountIncrease()
        {
            SqlCommand oComand = new SqlCommand();
            oComand.Connection = oCon;
            try
            {
                oCon.Open();
                oComand.CommandType = System.Data.CommandType.StoredProcedure;
                oComand.CommandText = "sp_TreatmentUsedCountIncrease";
                oComand.Parameters.AddWithValue("@TreatmentServiceID", oTreatment.TreatmentServiceID);
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

        public void AssuranceServiceDetailsUsedCountIncrease(Int64 serviceID)
        {
            SqlCommand oComand = new SqlCommand();
            oComand.Connection = oCon;
            try
            {
                oCon.Open();
                oComand.CommandType = System.Data.CommandType.StoredProcedure;
                oComand.CommandText = "sp_AssuranceServiceDetailsUsedCountIncrease";
                oComand.Parameters.AddWithValue("@ServiceID", serviceID);
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

        public void AssuranceServiceHeaderUsedCountIncrease(int serviceHeaderID)
        {
            SqlCommand oComand = new SqlCommand();
            oComand.Connection = oCon;
            try
            {
                oCon.Open();
                oComand.CommandType = System.Data.CommandType.StoredProcedure;
                oComand.CommandText = "sp_AssuranceServiceHeaderUsedCountIncrease";
                oComand.Parameters.AddWithValue("@ServiceHeaderID", serviceHeaderID);
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

        public void TreatmentServiceShowingStatusChange(int treatmentServiceID, bool showingStatus)
        {
            SqlCommand oComand = new SqlCommand();
            oComand.Connection = oCon;
            try
            {
                oCon.Open();
                oComand.CommandType = System.Data.CommandType.StoredProcedure;
                oComand.CommandText = "sp_TreatmentServiceShowInUpdateByID";
                oComand.Parameters.AddWithValue("@TreatmentServiceID", treatmentServiceID);
                oComand.Parameters.AddWithValue("@ShowInToolBox", showingStatus);
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

        public void TreatmentServiceCountReset(int treatmentServiceID)
        {
            SqlCommand oComand = new SqlCommand();
            oComand.Connection = oCon;
            try
            {
                oCon.Open();
                oComand.CommandType = System.Data.CommandType.StoredProcedure;
                oComand.CommandText = "sp_TreatmentServiceCountReset";
                oComand.Parameters.AddWithValue("@TreatmentServiceID", treatmentServiceID);
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
        
        public DataSet GetAssuranceServiceList(string serviceCode, string serviceName, int assuranceID, int serviceHeaderID, decimal selectedOrganKCoeff, bool showAll)
        {
            try
            {
                DataSet aDataSet = new DataSet();
                SqlCommand oComand = new SqlCommand();
                oComand.CommandText = "sp_AssuranceServiceSelect";
                oComand.CommandType = System.Data.CommandType.StoredProcedure;
                oComand.Parameters.AddWithValue("@ServiceCode", serviceCode);
                oComand.Parameters.AddWithValue("@ServiceName", "%" + serviceName + "%");
                oComand.Parameters.AddWithValue("@AssuranceID", assuranceID);
                oComand.Parameters.AddWithValue("@serviceHeaderID", serviceHeaderID);
                oComand.Parameters.AddWithValue("@KCoeff", selectedOrganKCoeff);
                oComand.Parameters.AddWithValue("@isVisible", showAll);
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

        public DataSet GetServiceHeaderList(int assuranceID, bool isVisible)
        {
            try
            {
                DataSet aDataSet = new DataSet();
                SqlCommand oComand = new SqlCommand();
                oComand.CommandText = "sp_AssuranceServiceHeaderSelect";
                oComand.CommandType = System.Data.CommandType.StoredProcedure;
                oComand.Parameters.AddWithValue("@IsVisible", isVisible);
                oComand.Parameters.AddWithValue("@AssuranceID", assuranceID);
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

        public void DeleteAssuranceService(Int64 serviceID)
        {
            try
            {
                SqlCommand oComand = new SqlCommand();

                oComand.CommandText = "sp_AssuranceServiceDelete";
                oComand.CommandType = System.Data.CommandType.StoredProcedure;
                oComand.Parameters.AddWithValue("@ServiceID", serviceID);
                oComand.Connection = oCon;
                oCon.Open();
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

        public void InsertAssuranceService()
        {
            SqlCommand oComand = new SqlCommand();
            oComand.Connection = oCon;
            try
            {
                oCon.Open();
                oComand.CommandText = "sp_AssuranceServiceInsert";
                oComand.CommandType = System.Data.CommandType.StoredProcedure;
                oComand.Parameters.AddWithValue("@ServiceHeaderID", OAssuranceService.ServiceHeaderID);
                oComand.Parameters.AddWithValue("@AssuranceID", OAssuranceService.AssuranceID);
                oComand.Parameters.AddWithValue("@ServiceCode", OAssuranceService.ServiceCode);
                oComand.Parameters.AddWithValue("@ServiceName", OAssuranceService.ServiceName);
                oComand.Parameters.AddWithValue("@KPrice", OAssuranceService.KPrice);
                oComand.Parameters.AddWithValue("@Price", OAssuranceService.ServicePrice);
                oComand.Parameters.AddWithValue("@BaseOnK", OAssuranceService.BaseOnK);
                oComand.Parameters.AddWithValue("@IsVisible", OAssuranceService.IsVisible);

                oComand.ExecuteScalar();
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

        public void UpdateAssuranceService()
        {
            SqlCommand oComand = new SqlCommand();
            oComand.Connection = oCon;
            try
            {
                oCon.Open();
                oComand.CommandText = "sp_AssuranceServiceUpdate";
                oComand.CommandType = System.Data.CommandType.StoredProcedure;
                oComand.Parameters.AddWithValue("@ServiceID", OAssuranceService.ServiceID);
                oComand.Parameters.AddWithValue("@ServiceHeaderID", OAssuranceService.ServiceHeaderID);
                oComand.Parameters.AddWithValue("@AssuranceID", OAssuranceService.AssuranceID);
                oComand.Parameters.AddWithValue("@ServiceCode", OAssuranceService.ServiceCode);
                oComand.Parameters.AddWithValue("@ServiceName", OAssuranceService.ServiceName);
                oComand.Parameters.AddWithValue("@KPrice", OAssuranceService.KPrice);
                oComand.Parameters.AddWithValue("@Price", OAssuranceService.ServicePrice);
                oComand.Parameters.AddWithValue("@BaseOnK", OAssuranceService.BaseOnK);
                oComand.Parameters.AddWithValue("@IsVisible", OAssuranceService.IsVisible);
                oComand.ExecuteScalar();
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

        public override void Delete<T>(T recID)
        {
            try
            {
                SqlCommand oComand = new SqlCommand();

                oComand.CommandText = "sp_TreatmentServiceDelete";
                oComand.CommandType = System.Data.CommandType.StoredProcedure;
                oComand.Parameters.AddWithValue("@TreatmentServiceID", recID);
                oComand.Connection = oCon;
                oCon.Open();
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
