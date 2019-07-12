using System;

namespace MiscDemo.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? DateCreated { get; set; }
    }
}