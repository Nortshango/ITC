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
            /*var uriString = ConfigurationManager.AppSettings["SQLSERVER_URI"];

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
                DataSource = "86e95deb-3cb3-4729-80f7-a26600bf1e84.sqlserver.sequelizer.com",
                InitialCatalog = "db86e95deb3cb3472980f7a26600bf1e84",
                UserID = "gvhdololevszhtrr",
                Password = "VcVdrpbVe5vFDpRVwKNSdQkUJL8Te5yNG7kecFDY7ar8LRiTNeCk8SMfZbAMppRh",
            }.ConnectionString;


        }

        public DataSet GetUser()
        {
            string query = "SELECT * FROM \"User\"";
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