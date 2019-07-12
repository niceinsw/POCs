using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFirstEF.Entities
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Student> Students { get; set; }

        public virtual School School { get; set; }
    }
}
