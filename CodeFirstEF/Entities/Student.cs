using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFirstEF.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TeacherId { get; set; }
        public string City { get; set; }        
        public virtual Teacher Teacher { get; set; }
    }
}
