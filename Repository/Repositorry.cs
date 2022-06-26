using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace Webform.Repository
{
    public class Repositorry : IRepository
    {
        private readonly string _dbConnection;
        public Repositorry(IConfiguration configure)
        {
            _dbConnection = configure.GetSection("ConnectionStrings:WebformConnection").Value;
        }
        public SqlDataReader DataFromDB(string statement)
        {
            var con = GetConnection();
            con.Open();
            using(var command = new SqlCommand(statement, con))
            {
                var rows = command.ExecuteReader();
                return rows;
            }
        }

        public bool ExecuteQuery(string statement)
        {
            var con = GetConnection();
            try
            {
                con.Open();
                using(var command = new SqlCommand (statement, con))
                {
                    var res = command.ExecuteNonQuery();
                    if (res > 0)
                        return true;
                    else
                        return false;
                }
            }
            finally
            {
                con.Close();
            }
        }

        public SqlConnection GetConnection()
        {
            return new SqlConnection(_dbConnection);
        }
    }
}
