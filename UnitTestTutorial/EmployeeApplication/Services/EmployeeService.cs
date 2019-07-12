using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using EmployeeApplication.Entities;

namespace EmployeeApplication.Services
{
    public interface IEmployeeService
    {
        Employee GetEmployee(int id);
        int GetEmployeeDurationWorked(int id);
        float GetEmployeeSalary(int id);
        bool IsValidEmail(string email);
    }
    public class EmployeeService : IEmployeeService
    {
        private readonly EmployeeEntity _employeeEntity;
        private readonly IEmailService _emailService;
        public EmployeeService(IEmailService emailService)
        {
                _employeeEntity = new EmployeeEntity();
                _emailService = emailService;
        }
        public Employee GetEmployee(int id) => _employeeEntity.EmployeeCollection.First(x => x.Id == id);

        public int GetEmployeeDurationWorked(int id) => _employeeEntity.EmployeeCollection.First(x => x.Id == id).DurationWorked;

        public float GetEmployeeSalary(int id) => _employeeEntity.EmployeeCollection.First(x => x.Id == id).Salary;

        public bool IsValidEmail(string email)
        {
            var res = _employeeEntity.EmployeeCollection.FirstOrDefault(x => x.Email == email);

            if (res!=null)
                return true;

            return false;
        }

        public bool AddEmployee(Employee employee)
        {
            var res = _emailService.SendEmail(employee.Email);
            if (res)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
