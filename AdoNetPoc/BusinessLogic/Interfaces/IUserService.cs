using BusinessLogic.DomainModels.UserModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IUserService
    {
        Task<int> AddUser(CreateUserRequest model);
        Task<List<UserResponse>> GetUsers();
        Task<UserResponse> GetUser(int id);
        Task DeleteUser(int id);
    }
}
