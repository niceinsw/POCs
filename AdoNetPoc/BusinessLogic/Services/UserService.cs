using BusinessLogic.DomainModels.UserModels;
using BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class UserService : IUserService
    {
        private readonly ISqlDbProvider _sqlDbProvider;

        public UserService(ISqlDbProvider sqlDbProvider)
        {
            _sqlDbProvider = sqlDbProvider;
        }

        public async Task<int> AddUser(CreateUserRequest model)
        {
            return await _sqlDbProvider.ExecuteNonQueryProcedure("CreateUser", GetCreateUserParameters(model));
        }

        public async Task DeleteUser(int id)
        {
            await _sqlDbProvider.ExecuteNonQueryProcedure("DeleteUser", GetDeleteUserParameters(id));
        }

        public async Task<List<UserResponse>> GetUsers()
        {
            var users = new List<UserResponse>();
            using (var reader = await _sqlDbProvider.ExcecuteReaderProcedure("GetUsers"))
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
            return users;
        }

        public async Task<UserResponse> GetUser(int id)
        {
            var user = new UserResponse();
            using (var reader = await _sqlDbProvider.ExcecuteReaderProcedure("GetUser", new[] { new SqlParameter("@Id", id) }))
            {
                if (reader.Read())
                {
                    user = new UserResponse()
                    {
                        Id = int.Parse(reader["Id"].ToString()),
                        FullName = reader["FullName"].ToString(),
                        Email = reader["Email"].ToString(),
                        DateCreated = !string.IsNullOrEmpty(reader["DateCreated"].ToString()) ? DateTime.Parse(reader["DateCreated"].ToString()) : default(DateTime?)
                    };
                }
            }

            return user;
        }

        private SqlParameter[] GetCreateUserParameters(CreateUserRequest model)
        {
            return new[]
            {
                new SqlParameter(){
                    ParameterName = "@FullName",
                    Value = model.FullName
                },
                new SqlParameter(){
                    ParameterName = "@Email",
                    Value = model.FullName
                },
                new SqlParameter(){
                    ParameterName = "@DateCreated",
                    Value = DateTime.UtcNow
                },
            };
        }

        private SqlParameter[] GetDeleteUserParameters(int userId)
        {
            return new SqlParameter[] {
                new SqlParameter()
                {
                    ParameterName = "@UserId",
                    Value = userId
                }
            };
        }
    }
}
