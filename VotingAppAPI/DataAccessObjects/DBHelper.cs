using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace VotingAppAPI.DataAccessObjects
{
    public class DBHelper : IDisposable
    {
        private SqlConnection _SQLConnection;
        public SqlConnection SQLConnection
        {
            get
            {
                return _SQLConnection ?? InitializeConnectionString();
            }
            set
            {
                _SQLConnection = value;
            }
        }

        private SqlConnection InitializeConnectionString()
        {
            return new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
        }

        public void Dispose()
        {
            if (SQLConnection != null && SQLConnection.State == System.Data.ConnectionState.Open)
            {
                SQLConnection.Close();
                SQLConnection = null;
            }
        }
    }
}