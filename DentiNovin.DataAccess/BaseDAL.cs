using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;
using DentiNovin.Common.SerialMaker;

namespace DentiNovin.DataAccess
{
    public abstract class BaseDAL
    {
        private static SqlConnection _oCon = null;
        public static SqlConnection oCon
        {
            get
            {
                if (_oCon == null)
                {
                    _oCon = new SqlConnection();
                    _oCon.ConnectionString = ConfigurationManager.ConnectionStrings["DentiNovin.Properties.Settings.MNMDentiDBConnectionString"].ConnectionString;
                }
                return _oCon;
            }
        }

        public abstract void Insert();

        public abstract void Update();

        public abstract void Delete();

        public abstract void Delete<T>(T recID);

        public abstract DataSet Select();

        public abstract System.Data.DataSet FillGrid();

    }
}
