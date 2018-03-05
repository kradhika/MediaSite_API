using System;
using System.Data.SqlClient;
using DH.Curbside.Core.Enterprise.Common;

namespace DH.Curbside.API.RegressionTest.DataAccess
{
    public class DbConnection
    {
        readonly string _connectionString = ConfigurationHelper.ConnectionString;
        public int GetUserCount()
        {
            string tenantId = ConfigurationHelper.TenentId;
            string selectUsers = String.Concat(Constants.SelectStmt, tenantId, Constants.SingleQuote);
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                SqlCommand userscmd = new SqlCommand(selectUsers, con);
                con.Open();
                int numrows = (int)userscmd.ExecuteScalar();
                return numrows;
            }
        }
    }
}