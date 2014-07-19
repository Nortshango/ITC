using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ITC
{
    public class DBUtil
    {
        public string connectionString;

        public DBUtil()
        {
            /*
            var uriString = ConfigurationManager.AppSettings["SQLSERVER_URI"];

            var uri = new Uri(uriString);
            connectionString = new SqlConnectionStringBuilder
            {
                DataSource = uri.Host,
                InitialCatalog = uri.AbsolutePath.Trim('/'),
                UserID = uri.UserInfo.Split(':').First(),
                Password = uri.UserInfo.Split(':').Last(),
            }.ConnectionString;*/

            connectionString = new SqlConnectionStringBuilder
            {
                DataSource = "dfa9aca7-b866-48e1-99fb-a36d00c748a9.sqlserver.sequelizer.com",
                InitialCatalog = "dbdfa9aca7b86648e199fba36d00c748a9",
                UserID = "minklsvtsvreqaea",
                Password = "hFDLoKVeE7jnBeunDwKfgBKmf7UtcXgK8qpJunF3Fz4CGMtPDCNryf3N4sFpXBcP",
            }.ConnectionString;


        }

        public DataSet GetUser()
        {
            string query = "SELECT * FROM User";
            SqlCommand cmd = new SqlCommand(query);
            return FillDataSet(cmd, "User");
        }

        private DataSet FillDataSet(SqlCommand cmd, string tableName)
        {
            SqlConnection con = new SqlConnection(connectionString);
            cmd.Connection = con;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            DataSet ds = new DataSet();
            try
            {
                con.Open();
                adapter.Fill(ds, tableName);
            }
            finally { con.Close(); }
            return ds;
        }

    }
}