using BusinessLogic.DomainModels.UserModels;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Website.Services
{
    public class SiteUserService
    {
        private readonly string _connectionString;
        public SiteUserService()
        {
            _connectionString = ConfigurationManager.AppSettings["MyConnectionString"];
        }

        public async Task<SqlDataReader> ExecureReader(string storedProcedure, SqlParameter[] parameters)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var cmd = new SqlCommand()
                {
                    Connection = connection,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = storedProcedure
                };

                if (parameters != null)
                    cmd.Parameters.AddRange(parameters);

                return await cmd.ExecuteReaderAsync();
            }
        }

        public async Task<int> ExecureNonQuery(string storedProcedure, SqlParameter[] parameters)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var cmd = new SqlCommand()
                {
                    Connection = connection,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = storedProcedure
                };

                if (parameters != null)
                    cmd.Parameters.AddRange(parameters);

                return await cmd.ExecuteNonQueryAsync();
            }
        }


        private SqlParameter[] GetCreateUserParameters(CreateUserRequest model)
        {
            return new SqlParameter[]
            {
                new SqlParameter()
                {
                    ParameterName = "@FullName",
                    Value = model.FullName
                },
                new SqlParameter()
                {
                    ParameterName = "@Email",
                    Value = model.Email
                },
                new SqlParameter()
                {
                    ParameterName = "@DateCreated",
                    Value = DateTime.UtcNow
                }
            };
        }
    }
}