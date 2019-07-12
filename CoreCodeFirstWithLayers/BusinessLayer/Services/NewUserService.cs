using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLayer.Services
{
    public class NewUserService
    {
        public List<User> GetUsers()
        {
            using (var db = new ProjectDbContext())
            {
                return db.Users.ToList();
            }
        }

        public User GetUser(int id)
        {
            using (var db = new ProjectDbContext())
            {
                return db.Users.Where(x=>x.Id == id).FirstOrDefault();
            }
        }

    }
}
