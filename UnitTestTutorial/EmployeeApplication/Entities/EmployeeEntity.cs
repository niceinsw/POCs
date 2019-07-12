using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeApplication.Entities
{
    public class EmployeeEntity
    {
        public List<Employee> EmployeeCollection = new List<Employee>()
        {
            new Employee()
            {
                Id = 1,
                Name = "Karthik",
                DurationWorked = 24,
                Grade = 1,
                Salary = 4000,
                Email = "emp1@emp.com"
            },
            new Employee()
            {
                Id = 2,
                Name = "Prashanth",
                DurationWorked = 30,
                Grade = 2,
                Salary = 7000,
                Email = "emp2@emp.com"
            },
            new Employee()
            {
                Id = 3,
                Name = "Ramesh",
                DurationWorked = 13,
                Grade = 2,
                Salary = 3500,
                Email = "emp3@emp.com"
            },
            new Employee()
            {
                Id = 4,
                Name = "John",
                DurationWorked = 18,
                Grade = 3,
                Salary = 2500,
                Email = "emp4@emp.com"
            },
        };
    }
}
