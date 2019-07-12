using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFirstEF.Entities
{
    public class School
    {
        public int SchoolId { get; set; }
        public string SchoolName { get; set; }
        public string PostCode { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public virtual ICollection<Teacher> Teachers { get; set; }
    }
}
