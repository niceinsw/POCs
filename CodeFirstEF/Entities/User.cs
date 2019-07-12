using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFirstEF.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string EmailId { get; set; }
        public string Name { get; set; }

        [InverseProperty("Blocked")]
        public virtual ICollection<Block> BlockedUsers { get; set; }
        [InverseProperty("Blocker")]
        public virtual ICollection<Block> BlockerUsers { get; set; }
    }
}
