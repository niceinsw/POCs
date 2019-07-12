using System;
using System.Collections.Generic;
using System.Text;
using EmployeeApplication.Entities;

namespace EmployeeApplication.Services
{
    public interface IEmployeePerformanceService
    {
        bool IsEligibleForBonus(int id);
        bool AreAllEligibleForBonus(List<int> idList);
        string GetEmployeeValidEmail(Employee employee);
    }
    public class EmployeePerformanceService : IEmployeePerformanceService
    {
        private readonly IEmployeeService _employeeService;

        public EmployeePerformanceService(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
     
        public bool IsEligibleForBonus(int id)
        {
            var salary = _employeeService.GetEmployeeSalary(id);

            return salary > 4000;
        }

        public bool AreAllEligibleForBonus(List<int> idList)
        {
            bool res = false;
            foreach (var id in idList)
            {
                var salary = _employeeService.GetEmployeeSalary(id);
                res = salary >= 4000;
            }

            return res;
        }

        public string GetEmployeeValidEmail(Employee employee)
        {
            if (_employeeService.IsValidEmail(employee.Email))
            {
                return employee.Email;
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
