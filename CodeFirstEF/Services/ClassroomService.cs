using CodeFirstEF.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFirstEF.Services
{
    public class ClassroomService
    {
        public List<User> GetBlockedUsers(int id)
        {
            using (var db = new ClassroomContext())
            {
                return db.Blocks
                    .Include(x=>x.Blocked)
                    .Where(b => b.Blocker.Id == 1).Select(x=>x.Blocked).ToList();
            }
        }

        public List<User> GetBlockerUsers(int id)
        {
            using (var db = new ClassroomContext())
            {
                return db.Blocks
                    .Include(x => x.Blocker)
                    .Where(b => b.Blocked.Id == 1).Select(x=>x.Blocker).ToList();
            }
        }
    }
}
