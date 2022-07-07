using Practice.Database;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.CRUD
{
    public class Read
    {
        private SqlConnection? sqlConn;

        public Read()
        {
            this.sqlConn = Connection.GetClassInstance().GetConnection();
        }

        public Dictionary<string, string> GetMovieById(int id)
        {
            String query = $"SELECT * FROM [Movies].[dbo].[movie] WHERE id = {id}";

            Dictionary<string, string> column = new Dictionary<string, string>();
            using (SqlCommand cmd = new SqlCommand(query, this.sqlConn))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    column["id"] = reader["id"].ToString();
                    column["name"] = reader["name"].ToString();
                    column["description"] = reader["description"].ToString();
                    column["trailer_link"] = reader["trailer_link"].ToString();
                    column["created_at"] = reader["created_at"].ToString();
                }

                reader.Close();
            }

            return column;
        }

        public List<Dictionary<string, string>> GetAllMovies()
        {
            List<Dictionary<string, string>> rows = new List<Dictionary<string, string>>();
            Dictionary<string, string> column;

            String query = "SELECT [id] ,[name] ,[description] ,[trailer_link] ,[created_at] FROM [Movies].[dbo].[movie]";

            using(SqlCommand cmd = new SqlCommand(query, this.sqlConn))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    column = new Dictionary<string, string>();

                    column["id"] = reader["id"].ToString();
                    column["name"] = reader["name"].ToString();
                    column["description"] = reader["description"].ToString();
                    column["trailer_link"] = reader["trailer_link"].ToString();
                    column["created_at"] = reader["created_at"].ToString();

                    rows.Add(column);
                }

                // close reader
                reader.Close();
            }

            return rows;
        }
    }
}
