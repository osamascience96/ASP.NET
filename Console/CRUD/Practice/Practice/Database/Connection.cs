using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Database
{
    public class Connection
    {
        private SqlConnection sqlConn;
        private static Connection? connection;

        private Connection(String connStr)
        {
            this.sqlConn = new SqlConnection(connStr);

            try
            {
                // open connection 
                this.sqlConn.Open();
            }catch (Exception ex)
            {
                Console.WriteLine("Error" + ex.Message);
            }
        }

        public static Connection GetClassInstance()
        {
            if(connection == null)
            {
                var datasource = "DESKTOP-M9US879";
                var database = "Movies";
                var username = @"DESKTOP-M9US879\osama";
                var password = "";

                var connString = @"data source=" + datasource + ";Initial Catalog=" + database +
                    ";Persist Security Info=True;Trusted_Connection=true;" +
                    "User ID=" + username + ";Password=" + password;

                connection = new Connection(connString);
            }

            return connection;
        }

        public SqlConnection GetConnection()
        {
            return this.sqlConn;
        }
    }
}
