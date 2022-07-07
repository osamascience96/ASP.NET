using Practice.Database;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.CRUD
{
    public class Delete
    {
        private SqlConnection? sqlConn;

        public Delete()
        {
            this.sqlConn = Connection.GetClassInstance().GetConnection();
        }

        public void del(int id)
        {
            String query = $"DELETE FROM [Movies].[dbo].[movie] WHERE id = {id}";

            using (SqlCommand cmd = new SqlCommand(query, this.sqlConn))
            {
                cmd.ExecuteNonQuery();
            }
        }
    }
}
