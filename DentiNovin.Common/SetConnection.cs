using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;
using System.Configuration;

namespace DentiNovin.Common
{
    public  sealed class SetConnection
    {
        private static string  ConnectionString = ConfigurationSettings.AppSettings["ConnectionString"];

        private static   OleDbConnection _oCon;
        public static OleDbConnection OCon
        {
            get
            {

                if (_oCon == null)
                    _oCon = new OleDbConnection();
                return _oCon;
            }

        }

        private static OleDbCommand _oCommand;
        public static OleDbCommand oCommand
        {
            get
            {

                if (_oCommand == null)
                    _oCommand = new OleDbCommand();
                return _oCommand;
            }
        }

        public static void SetConnect(CommandType oCommandType, string oCommandtext)
        {

            if (OCon.State == ConnectionState.Closed)
            {
                OCon.ConnectionString = ConnectionString;
                OCon.Open();
            }        
            oCommand.CommandType = oCommandType;
            oCommand.CommandText = oCommandtext;
            oCommand.Connection = OCon;
                
        }
        
        public static void DisposeConnection()
        {

            if (OCon.State == ConnectionState.Open)
            {
                oCommand.Dispose();
                OCon.Close();
            }
        }

      

    }
}
