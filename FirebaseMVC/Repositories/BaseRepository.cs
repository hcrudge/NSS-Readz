using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Readz.Repositories
{
    public class BaseRepository
    {
        private string _connectionString;

        //Parent class where that Repositores can inherit the connection string
        public BaseRepository(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("DefaultConnection");
        }

        protected SqlConnection Connection
        {
            get
            {
                return new SqlConnection(_connectionString);
            }
        }
    }
}
