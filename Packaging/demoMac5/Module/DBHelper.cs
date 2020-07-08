using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace demoMac5.Module
{
    public class DBHelper
    {
        private static string szDbUser = ConfigurationManager.AppSettings["DBUser"];
        private static string szDbPassword = ConfigurationManager.AppSettings["DBPassword"];

        public static SqlConnection ConnectDb(ref string errMsg)
        {
            string connStrFmt = "Data Source={0}; Initial Catalog={1};User ID={2}; Password={3};";
            string connString = string.Format(connStrFmt, ConfigurationManager.AppSettings["DBServer"], ConfigurationManager.AppSettings["DBName"], szDbUser, szDbPassword);
            try
            {
                var conn = new SqlConnection(connString);
                conn.Open();
                return conn;
            }
            catch (Exception ex)
            {
                errMsg = ex.ToString();
                return null;
            }
        }

        public static DataTable List(string query, SqlConnection conn)
        {
            var dt = new DataTable();
            var dataAdapter = new SqlDataAdapter(query, conn);
            dataAdapter.SelectCommand.CommandTimeout = 0;
            dataAdapter.Fill(dt);
            return dt;
        }

        public static DataTable List(string query, SqlConnection conn, SqlTransaction sqlTransaction)
        {
            var dt = new DataTable();
            var sqlCommand = new SqlCommand(query, conn, sqlTransaction);
            var dataAdapter = new SqlDataAdapter(sqlCommand);
            dataAdapter.SelectCommand.CommandTimeout = 0;
            dataAdapter.Fill(dt);
            return dt;
        }

        public static int Execute(string query, SqlConnection conn)
        {
            int i = 0;
            var sqlCommand = new SqlCommand(query, conn);
            i = sqlCommand.ExecuteNonQuery();
            return (i > 0) ? i : 0;
        }

        public static int Execute(string query, SqlConnection conn, SqlTransaction sqlTransaction)
        {
            int i = 0;
            var sqlCommand = new SqlCommand(query, conn, sqlTransaction);
            i = sqlCommand.ExecuteNonQuery();
            return (i > 0) ? i : 0;
        }

        public static void Close(SqlConnection conn)
        {

            conn.Close();
        }
    }
}