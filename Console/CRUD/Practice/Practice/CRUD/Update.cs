using Practice.Database;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.CRUD
{
    public class Update
    {
        private SqlConnection? sqlConn;

        public Update()
        {
            this.sqlConn = Connection.GetClassInstance().GetConnection();
        }
        public void UpdateMovie(int id, String name, String description, String trailer)
        {
            String query = $"UPDATE [Movies].[dbo].[movie] SET name = '{name}', description = '{description}', trailer_link = '{trailer}' WHERE id = {id}";

            using(SqlCommand cmd = new SqlCommand(query, this.sqlConn))
            {
                cmd.ExecuteNonQuery();
            }
        }
    }
}
