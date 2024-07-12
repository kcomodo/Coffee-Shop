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
    }
}
