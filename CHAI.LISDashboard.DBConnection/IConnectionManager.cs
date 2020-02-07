using System;
using System.Data;
using System.Data.SqlClient;

namespace CHAI.LISDashboard.DBConnection
{
    public interface IConnectionManager
    {
        void CloseConnection();
        bool ConnectionInitSuceeded { get; }
        
        SqlConnection GetSqlConnection();
        SqlTransaction GetSqlTransaction();

        SqlConnection SqlConnection { get; }
        
    }
}
