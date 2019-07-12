using System;
using System.Collections.Generic;
using EmployeeApplication.Entities;
using EmployeeApplication.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NUnit.Framework;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

//using NUnit.Framework;

namespace EmployeeApplication.Tests
{
    [TestClass]
    public class EmployeeTests
    {
        private Mock<IEmployeeService> _employeeServiceMock;
        private Mock<IEmailService> _emailServiceMock;

        [TestInitialize]
        public void Setup()
        {
            _employeeServiceMock = new Mock<IEmployeeService>();
            _emailServiceMock = new Mock<IEmailService>();

            _emailServiceMock.Setup(x => x.SendEmail(It.IsAny<string>())).Returns(true);
        }

        [TestMethod]
        public void EmployeeDetailsTest()
        {
            //Arrange
            var employeeService = new EmployeeService(null);

            //Act
            var salary = employeeService.GetEmployeeSalary(1);

            //Assert
            Assert.AreEqual(salary, 4000);
        }

        [TestMethod]
        public void EmployeeSalaryTest()
        {
            //Arrange
            var employeeService = new EmployeeService(null);

            //Act
            var salary = employeeService.GetEmployeeSalary(1);

            //Assert
            Assert.AreEqual(salary, 4000);
        }

        [TestMethod]
        public void EmployeeBonusEligibilityTest()
        {
            _employeeServiceMock.Setup(x => x.GetEmployeeSalary(It.IsAny<int>())).Returns(() => 6000);

            //Arrange
            var eligibleForBonus = new EmployeePerformanceService(_employeeServiceMock.Object).IsEligibleForBonus(It.IsAny<int>());

            Assert.AreEqual(eligibleForBonus, true);
        }

        [TestMethod]
        public void IsGetEmployeeSalaryMethodCalled()
        {
            var eligibleForBonus = new EmployeePerformanceService(_employeeServiceMock.Object).IsEligibleForBonus(It.IsAny<int>());

            _employeeServiceMock.Verify(x => x.GetEmployeeSalary(It.IsAny<int>()), Times.AtLeastOnce);

            //mockEmployeeService.Verify(x=>x.GetEmployeeSalary(It.IsAny<int>()), Times.Exactly(1));
        }

        [TestMethod]
        public void IsGetEmployeSalaryMethodCalledMultipleTimes()
        {
            //List<int> idList = new List<int>(){1,2,3};

            List<int> idList = new List<int>() { It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>() };

            //var areAllEligibleForBonus = new EmployeePerformanceService(_employeeServiceMock.Object).AreAllEligibleForBonus(It.IsAny<List<int>>());

            var areAllEligibleForBonus = new EmployeePerformanceService(_employeeServiceMock.Object).AreAllEligibleForBonus(idList);

            _employeeServiceMock.Verify(x => x.GetEmployeeSalary(It.IsAny<int>()), Times.Exactly(3));
        }

        [TestMethod]
        public void IsGetEmployeSalaryMethodCalledNTimes()
        {
            int n = 5;

            List<int> idList = new List<int>();

            for (int i = 0; i < n; i++)
            {
                idList.Add(It.IsAny<int>());
            }


            //var areAllEligibleForBonus = new EmployeePerformanceService(var _employeeServiceMock = new Mock<IEmployeeService>();.Object).AreAllEligibleForBonus(It.IsAny<List<int>>());

            var areAllEligibleForBonus = new EmployeePerformanceService(_employeeServiceMock.Object).AreAllEligibleForBonus(idList);

            _employeeServiceMock.Verify(x => x.GetEmployeeSalary(It.IsAny<int>()), Times.Exactly(n));
        }

        [TestMethod]
        public void AddEmployeeTest()
        {
            var employee = new Employee()
            {
                Id = 1,
                Name = "Karthik",
                DurationWorked = 24,
                Grade = 1,
                Salary = 4000,
                Email = "emp1@emp.com"
            };

            var moqEmailService = new Mock<IEmailService>();
            moqEmailService.Setup(x => x.SendEmail(It.IsAny<string>())).Returns(true);

            var employeeService = new EmployeeService(moqEmailService.Object);

            var res = employeeService.AddEmployee(employee);

            Assert.AreEqual(res, true);
            //moqEmailService.Verify(x=>x.SendEmail(It.IsAny<string>()), Times.AtLeast(1));
        }

        [TestMethod]
        public void AddEmployeeTest2()
        {
            var employee = new Employee()
            {
                Id = 1,
                Name = "Karthik",
                DurationWorked = 24,
                Grade = 1,
                Salary = 4000,
                Email = "emp1@emp.com"
            };

            var employeeService = new EmployeeService(_emailServiceMock.Object);

            var res = employeeService.AddEmployee(employee);

            Assert.AreEqual(res, true);
            //moqEmailService.Verify(x=>x.SendEmail(It.IsAny<string>()), Times.AtLeast(1));
        }
    }
}
