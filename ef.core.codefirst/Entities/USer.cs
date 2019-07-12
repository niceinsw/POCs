using System;
using System.Collections.Generic;
using System.Text;

namespace ef.core.codefirst.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public bool IsActive { get; set; }
    }
}
