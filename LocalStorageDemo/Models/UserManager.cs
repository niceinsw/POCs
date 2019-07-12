using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LocalStorageDemo.Models
{
    public static class UserManager
    {
        public static List<User> OnlineUsers { get; set; } = new List<User>();

        public static void GoOnline(User user)
        {
            OnlineUsers.Add(user);
        }
    }
}