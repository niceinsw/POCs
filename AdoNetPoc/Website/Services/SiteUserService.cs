using BusinessLogic.DomainModels.UserModels;
using System;
using System.Collections.Generic;
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

        /// <summary>
        /// Stored procedure
        /// </summary>
        /// <param name="procedure"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        private async Task<SqlDataReader> ExecReader(string procedure, SqlParameter[] parameters)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand()
                {
                    Connection = connection,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = procedure
                };

                connection.Open();

                if (parameters != null)
                    command.Parameters.AddRange(parameters);

                return await command.ExecuteReaderAsync();
            }
        }

        private async Task<int> ExecNonQuery(string procedure, SqlParameter[] parameters)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var command = new SqlCommand()
                {
                    Connection = connection,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = procedure
                };

                if (parameters != null)
                    command.Parameters.AddRange(parameters);

                return await command.ExecuteNonQueryAsync();
            }
        }

        private async Task CallReader()
        {
            List<UserResponse> users = new List<UserResponse>();

            using (var reader = await ExecReader("GetUsers", null))
            {
                while (reader.Read())
                {
                    users.Add(new UserResponse()
                    {
                        Id = int.Parse(reader["Id"].ToString()),
                        FullName = reader["FullName"].ToString(),
                        Email = reader["Email"].ToString(),
                        DateCreated = !string.IsNullOrEmpty(reader["DateCreated"].ToString()) ? DateTime.Parse(reader["DateCreated"].ToString()) : default(DateTime?)
                    });
                }
            }
        }

        private async Task CallNonQuery()
        {
            var userParameters = new SqlParameter[]
            {
                new SqlParameter(){
                    ParameterName = "@FullName",
                    Value = "Tester 77",
                },
                new SqlParameter(){
                    ParameterName = "@Email",
                    Value = "Tester@77.com",
                },
                new SqlParameter(){
                    ParameterName = "@DateCreated",
                    Value = DateTime.UtcNow,
                }
            };

            await ExecNonQuery("CreateUser", userParameters);
        }

    }
}