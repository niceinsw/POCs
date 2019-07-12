using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApi.ApiServices
{
    public class UserService
    {
        public List<User> GetUsers()
        {
            using (var db = new ProjectDbContext())
            {
                return db.Users.ToList();
            }
        }
    }
}
