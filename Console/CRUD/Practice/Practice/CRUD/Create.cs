using Practice.Database;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.CRUD
{
    public class Create
    {
        private SqlConnection sqlConn;

        public Create()
        {
            this.sqlConn = Connection.GetClassInstance().GetConnection();
        }

        public void Insert(String name, String description, String trailer)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO [Movies].[dbo].[movie](name, description, trailer_link) VALUES ('");
            sb.Append(name + "', '");
            sb.Append(description + "', '");
            sb.Append(trailer + "')");

            String query = sb.ToString();

            using (SqlCommand command = new SqlCommand(query, this.sqlConn))
            {
                command.ExecuteNonQuery();
                // close command
            }
        }
    }
}
