using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeApplication.Entities
{
    public class Employee
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public float Salary { get; set; }
        public int DurationWorked { get; set; }
        public int Grade { get; set; }
        public string Email { get; set; }
    }
}
