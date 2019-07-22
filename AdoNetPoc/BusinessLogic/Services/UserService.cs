using BusinessLogic.DomainModels.UserModels;
using BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
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

        public Task<int> AddUser(CreateUserRequest model)
        {
            _sqlDbProvider.ExecuteNonQueryProcedure("CreateUser", GetCreateUserParameters(model));
            throw new NotImplementedException();
        }

        public Task DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public Task<UserResponse> GetUser(int id)
        {
            throw new NotImplementedException();
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

    }
}
