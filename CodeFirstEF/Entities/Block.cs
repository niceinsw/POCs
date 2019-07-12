using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFirstEF.Entities
{
    public class Block
    {
        public int Id { get; set; }

        public virtual User Blocker { get; set; }

        public virtual User Blocked { get; set; }
    }
}
