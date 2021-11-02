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
    public class GroupDAL:BaseDAL
    {
        private Group _oGroup;
        public Group oGroup
        {
            get { return _oGroup; }
            set { _oGroup = value; }
        }

        public DataSet GetGroupList(Boolean All)
        {
            try
            {
                DataSet aDataSet = new DataSet();
                SqlCommand oComand = new SqlCommand();
                oComand.CommandText = "sp_GroupSelect";
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

        public void InsertNewGroup()
        {
            System.Data.DataSet ds = new System.Data.DataSet();
            SqlCommand oComand = new SqlCommand();

            try
            {
                oCon.Open();
                oComand.CommandText = "sp_GroupInsert";
                oComand.CommandType = System.Data.CommandType.StoredProcedure;
                oComand.Connection = oCon;
                oComand.Parameters.AddWithValue("@GroupCode", oGroup.GroupCode);
                oComand.Parameters.AddWithValue("@Name", oGroup.Name);
                oComand.Parameters.AddWithValue("@StartTime", oGroup.StartTime.Ticks);
                oComand.Parameters.AddWithValue("@EndTime", oGroup.EndTime.Ticks);
                oComand.Parameters.AddWithValue("@StartActiveDate", oGroup.StartActiveDate);
                oComand.Parameters.AddWithValue("@PeriodLength", oGroup.PeriodLength);
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

        public void UpdateGroup()
        {
            System.Data.DataSet ds = new System.Data.DataSet();
            SqlCommand oComand = new SqlCommand();

            oComand.CommandText = "sp_GroupSearchByDate";
            oComand.CommandType = System.Data.CommandType.StoredProcedure;
            oComand.Connection = oCon;
            try
            {

                oComand.Parameters.AddWithValue("@StartActiveDate", oGroup.StartActiveDate);
                oComand.Parameters.AddWithValue("@GroupCode", oGroup.GroupCode);
                oCon.Open();

                //if ((int)oComand.ExecuteScalar() == 0)// agar tarikh tekrari nabood 
                //{
                //    oComand.Parameters.Clear();

                //    oComand.CommandText = "sp_AppointmentSearchForEditGroup";

                //    oComand.Parameters.AddWithValue("@GroupCode", oGroup.GroupCode);
                //    oComand.Parameters.AddWithValue("@NewStartActiveDate", oGroup.StartActiveDate);

                //    if ((int)oComand.ExecuteScalar() != 0)    // agar nobati darin fasele sabt shodeh bood
                //    {
                //        oGroup.RowEffected = false;
                //        oGroup.ActionMessage = "بدلیل ثبت مراجعه با این شیفت کاری امکان تغییر وجود ندارد";
                //    }
                //    else                                       // agar nobati darin fasele sabt nashodeh bood
                //    {
                //        oComand.CommandText = "sp_GroupInsert";

                //        oComand.Parameters.Clear();

                //        oComand.Parameters.AddWithValue("@GroupCode", oGroup.GroupCode);
                //        oComand.Parameters.AddWithValue("@Name", oGroup.Name);

                //        oComand.Parameters.AddWithValue("@StartTime", oGroup.StartTime.Ticks);
                //        oComand.Parameters.AddWithValue("@EndTime", oGroup.EndTime.Ticks);
                //        oComand.Parameters.AddWithValue("@StartActiveDate", oGroup.StartActiveDate);
                //        oComand.Parameters.AddWithValue("@PeriodLength", oGroup.PeriodLength);

                //        oGroup.GroupID = Convert.ToInt32(oComand.ExecuteScalar());
                //        oGroup.RowEffected = true;
                //        oGroup.ActionMessage = Utilises.GetLocalizedString(ProgramMessageID.PM_actinsuccess);

                //    }
                //}
                //else
                //{
                //    oComand.Parameters.Clear();

                //    oComand.CommandText = "sp_AppointmentSearchForEditGroup";

                //    oComand.Parameters.AddWithValue("@GroupCode", oGroup.GroupCode);
                //    oComand.Parameters.AddWithValue("@NewStartActiveDate", oGroup.StartActiveDate);

                //    if ((int)oComand.ExecuteScalar() != 0)    // agar nobati darin fasele sabt shodeh bood
                //    {
                //        oGroup.RowEffected = false;
                //        oGroup.ActionMessage = "بدلیل ثبت مراجعه با این شیفت کاری امکان تغییر وجود ندارد";
                //    }
                //    else                                       // agar nobati darin fasele sabt nashodeh bood
                //    {
                //        oComand.CommandText = "sp_GroupUpdate";

                //        oComand.Parameters.Clear();
                //        oComand.Parameters.AddWithValue("@GroupID", oGroup.GroupID);
                //        oComand.Parameters.AddWithValue("@GroupCode", oGroup.GroupCode);
                //        oComand.Parameters.AddWithValue("@Name", oGroup.Name);

                //        oComand.Parameters.AddWithValue("@StartTime", oGroup.StartTime.Ticks);
                //        oComand.Parameters.AddWithValue("@EndTime", oGroup.EndTime.Ticks);
                //        oComand.Parameters.AddWithValue("@StartActiveDate", oGroup.StartActiveDate);
                //        oComand.Parameters.AddWithValue("@PeriodLength", oGroup.PeriodLength);

                //        oGroup.GroupID = Convert.ToInt32(oComand.ExecuteScalar());
                //        oGroup.RowEffected = true;
                //        oGroup.ActionMessage = Utilises.GetLocalizedString(ProgramMessageID.PM_actinsuccess);
                //    }
                //    oGroup.ActionMessage = "شیفت کاری با تاریخ یکسان قبلآ ثبت شده است";
                //    oGroup.RowEffected = false;
                //}
                oComand.CommandText = "sp_GroupUpdate";

                oComand.Parameters.Clear();
                oComand.Parameters.AddWithValue("@GroupID", oGroup.GroupID);
                oComand.Parameters.AddWithValue("@GroupCode", oGroup.GroupCode);
                oComand.Parameters.AddWithValue("@Name", oGroup.Name);

                oComand.Parameters.AddWithValue("@StartTime", oGroup.StartTime.Ticks);
                oComand.Parameters.AddWithValue("@EndTime", oGroup.EndTime.Ticks);
                oComand.Parameters.AddWithValue("@StartActiveDate", oGroup.StartActiveDate);
                oComand.Parameters.AddWithValue("@PeriodLength", oGroup.PeriodLength);

                oGroup.GroupID = Convert.ToInt32(oComand.ExecuteScalar());
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

        public void DeleteGroup(int groupID)
        {
            System.Data.DataSet ds = new System.Data.DataSet();
            SqlCommand oComand = new SqlCommand();

            oComand.CommandType = System.Data.CommandType.StoredProcedure;
            oComand.Connection = oCon;

            oComand.Parameters.AddWithValue("@GroupID", groupID);
            try
            {
                oCon.Open();
                oComand.CommandText = "sp_GroupDelete";
                oComand.ExecuteNonQuery();
            }
            catch (Exception)
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
