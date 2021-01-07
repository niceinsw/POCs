using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Threading.Tasks;

namespace DbFirstApi.SpServices
{
    public class SqlDbProvider
    {
        private readonly string _connectionString;

        public SqlDbProvider()
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            string connectionString = configuration.GetConnectionString("DefaultConnection");
            _connectionString = connectionString;

        }

        public async Task<SqlDataReader> ExcecuteReaderProcedure(string storedProcedure, SqlParameter[] parameters = null)
        {
            try
            {
                var connection = new SqlConnection(_connectionString);
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
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<int> ExecuteNonQueryProcedure(string storedProcedure, SqlParameter[] parameters = null)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = storedProcedure;

                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);

                    return await cmd.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
