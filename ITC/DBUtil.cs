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

            var uriString = ConfigurationManager.AppSettings["SQLSERVER_URI"];

            var uri = new Uri(uriString);
            connectionString = new SqlConnectionStringBuilder
            {
                DataSource = uri.Host,
                InitialCatalog = uri.AbsolutePath.Trim('/'),
                UserID = uri.UserInfo.Split(':').First(),
                Password = uri.UserInfo.Split(':').Last(),
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