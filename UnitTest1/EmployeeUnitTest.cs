using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeShopWebsiteAngular.Server.Controllers;
using Microsoft.AspNetCore.Mvc.Testing;
using Moq;
using POS_Folders.Repository;
using POS_Folders.Services;
using CoffeeShopWebsiteAngular.Server.Controllers;
using POS_Folders.Models;
using Org.BouncyCastle.Crypto.Macs;
using MySqlX.XDevAPI.Common;
using Microsoft.AspNetCore.Mvc;
using System.Net.Sockets;
namespace CustomerUnitTest
{
    public class EmployeeUnitTest
    {
        [Fact]
        public void getEmployeeById_True()
        {
            //create a mock repository, assign the employee object with values for email and password for testing
            var mockRepository = new Mock<IEmployeeRepository>();
            var employee = new EmployeeModel
            {
                employee_id = 1,
                employee_firstname = "test",
                employee_lastname = "testing",
                employee_email = "testing@gmail.com",
                employee_password = "testing12345"
            };
            mockRepository.Setup(x => x.getEmployeeId(1)).Returns(employee);
            var results = mockRepository.Object.getEmployeeId(1);
            Assert.Equal(1, results.employee_id);
            Assert.Equal("test", results.employee_firstname);
            Assert.Equal("testing", results.employee_lastname);
            Assert.Equal("testing@gmail.com", results.employee_email);
            Assert.Equal("testing12345", results.employee_password);
        }
        [Fact]
        public void getEmployeeById_False()
        {
            //create a mock repository, assign the employee object with values for email and password for testing
            var mockRepository = new Mock<IEmployeeRepository>();
            var employee = new EmployeeModel
            {
                employee_id = 1,
                employee_firstname = "test",
                employee_lastname = "testing",
                employee_email = "testing@gmail.com",
                employee_password = "testing12345"
            };
            mockRepository.Setup(x => x.getEmployeeId(1)).Returns(employee);
            var results = mockRepository.Object.getEmployeeId(1);
            Assert.NotEqual(2, results.employee_id);
            Assert.NotEqual("NotTest", results.employee_firstname);
            Assert.NotEqual("NotTesting", results.employee_lastname);
            Assert.NotEqual("NotTesting@gmail.com", results.employee_email);
            Assert.NotEqual("NotTesting12345", results.employee_password);
        }
        [Fact]
        public void updateEmployee_True()
        {
            //create a mock repository, assign the employee object with values for email and password for testing
            var mockRepository = new Mock<IEmployeeRepository>();
            var employee = new EmployeeModel
            {
                employee_id = 1,
                employee_firstname = "test",
                employee_lastname = "testing",
                employee_email = "testing@gmail.com",
                employee_password = "testing12345"
            };
            mockRepository.Setup(repo => repo.getEmployeeByEmail("testing@gmail.com")).Returns(employee);
            mockRepository.Setup(repo => repo.updateEmployee(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .Callback<string, string, string, string, string>((firstname, lastname, email, password, oldemail) =>
                {
                    employee.employee_firstname = firstname;
                    employee.employee_lastname = lastname;
                    employee.employee_email = email;
                    employee.employee_password = password;
                });

            mockRepository.Object.updateEmployee("newtest", "newtesting", "newtesting@gmail.com", "newtesting12345", "testing@gmail.com");
            var results = mockRepository.Object.getEmployeeByEmail("testing@gmail.com");
            Assert.Equal("newtest", results.employee_firstname);
            Assert.Equal("newtesting", results.employee_lastname);
            Assert.Equal("newtesting@gmail.com", results.employee_email);
            Assert.Equal("newtesting12345", results.employee_password);
        }
        [Fact]
        public void updateEmployee_False()
        {
            //create a mock repository, assign the employee object with values for email and password for testing
            var mockRepository = new Mock<IEmployeeRepository>();
            var employee = new EmployeeModel
            {
                employee_id = 1,
                employee_firstname = "test",
                employee_lastname = "testing",
                employee_email = "testing@gmail.com",
                employee_password = "testing12345"
            };
            mockRepository.Setup(repo => repo.getEmployeeByEmail("testing@gmail.com")).Returns(employee);
            mockRepository.Setup(repo => repo.updateEmployee(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .Callback<string, string, string, string, string>((firstname, lastname, email, password, oldemail) =>
                {
                    employee.employee_firstname = firstname;
                    employee.employee_lastname = lastname;
                    employee.employee_email = email;
                    employee.employee_password = password;
                });

            mockRepository.Object.updateEmployee("newtest", "newtesting", "newtesting@gmail.com", "newtesting12345", "testing@gmail.com");
            var results = mockRepository.Object.getEmployeeByEmail("testing@gmail.com");
            Assert.NotEqual("test", results.employee_firstname);
            Assert.NotEqual("testing", results.employee_lastname);
            Assert.NotEqual("testing@gmail.com", results.employee_email);
            Assert.NotEqual("testing12345", results.employee_password);
        }
    }
}
