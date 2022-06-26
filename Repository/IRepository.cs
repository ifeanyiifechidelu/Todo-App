using System.Data.SqlClient;

namespace Webform.Repository
{
    public interface IRepository
    {
        public bool ExecuteQuery(string statement);
        public SqlConnection GetConnection();
        public SqlDataReader DataFromDB(string statement);
    }
}
