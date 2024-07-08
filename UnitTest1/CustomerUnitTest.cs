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
namespace UnitTest1
{
    public class CustomerUnitTest
    {
        //Should pass and fail if working correctly
        [Fact]
        public void ValidateCustomerLogin_True()
        {
            //create a mock repository, assign the customer object with values for email and password for testing
            var mockRepository = new Mock<ICustomerRepository>();
            var customer = new CustomerModel
            {
                customer_email = "QuangHo@gmail.com",
                customer_password = "12345"
            };
            mockRepository.Setup(x => x.getCustomerByEmail("QuangHo@gmail.com")).Returns(customer);

            var mockService = new CustomerServices(mockRepository.Object);
            var results = mockService.validateCustomerLogin(customer.customer_email, customer.customer_password);
            Assert.True(results);

        }
        [Fact]
        public void ValidateCustomerLogin_False()
        {
            //create a mock repository, assign the customer object with values for email and password for testing
            var mockRepository = new Mock<ICustomerRepository>();
            var customer = new CustomerModel
            {
                customer_email = "QuangHo@gmail.com",
                customer_password = "12345"
            };
            mockRepository.Setup(x => x.getCustomerByEmail("Testing@gmail.com")).Returns(customer);
            var mockService = new CustomerServices(mockRepository.Object);
            var results = mockService.validateCustomerLogin(customer.customer_email, customer.customer_password);
            Assert.False(results);
        }
        [Fact]
        public void ValidateCustomerLogin_Empty()
        {
            //create a mock repository, assign the customer object with values for email and password for testing
            var mockRepository = new Mock<ICustomerRepository>();
            var customer = new CustomerModel
            {
                customer_email = "QuangHo@gmail.com",
                customer_password = ""
            };
            mockRepository.Setup(x => x.getCustomerByEmail("")).Returns(customer);
            var mockService = new CustomerServices(mockRepository.Object);
            var results = mockService.validateCustomerLogin(customer.customer_email, customer.customer_password);
            Assert.False(results);
        }
        [Fact]
        public void GetCustomerByEmail_True()
        {
            //create a mock repository, assign the customer object with values for email and password for testing
            var mockRepository = new Mock<ICustomerRepository>();
            var customer = new CustomerModel
            {
                customer_id = 1,
                first_name = "Quang",
                last_name = "Ho",
                customer_email = "QuangHo@gmail.com",
                phone_number = "1234567890",
                reward_points = "0",
                orderItem_id = 0,
                customer_password = "12345",

            };
            mockRepository.Setup(x => x.getCustomerByEmail("QuangHo@gmail.com")).Returns(customer);
            var result = mockRepository.Object.getCustomerByEmail("QuangHo@gmail.com");
            Assert.Equal("QuangHo@gmail.com", result.customer_email);
            Assert.Equal("12345", result.customer_password);
            Assert.Equal("Quang", result.first_name);
            Assert.Equal("Ho", result.last_name);
            Assert.Equal("1234567890", result.phone_number);

        }
        [Fact]
        public void GetCustomerByEmail_False()
        {
            //create a mock repository, assign the customer object with values for email and password for testing
            var mockRepository = new Mock<ICustomerRepository>();
            var customer = new CustomerModel
            {
                customer_id = 1,
                first_name = "Quang",
                last_name = "Ho",
                customer_email = "QuangHo@gmail.com",
                phone_number = "1234567890",
                reward_points = "0",
                orderItem_id = 0,
                customer_password = "12345"
            };
            mockRepository.Setup(x => x.getCustomerByEmail("QuangHo@gmail.com")).Returns(customer);
            var result = mockRepository.Object.getCustomerByEmail("QuangHo@gmail.com");
            Assert.NotEqual("Testing@gmail.com", result.customer_email);
            Assert.NotEqual("wrongpassword", result.customer_password);
            Assert.NotEqual("WrongFirstName", result.first_name);
            Assert.NotEqual("WrongLastName", result.last_name);
            Assert.NotEqual("0987654321", result.phone_number);
        }
        [Fact]
        public void GetCustomerByEmail_Empty()
        {
            //create a mock repository, assign the customer object with values for email and password for testing
            var mockRepository = new Mock<ICustomerRepository>();
            var customer = new CustomerModel
            {
                customer_id = 1,
                first_name = "Quang",
                last_name = "Ho",
                customer_email = "QuangHo@gmail.com",
                phone_number = "1234567890",
                reward_points = "0",
                orderItem_id = 0,
                customer_password = "12345"
            };
            mockRepository.Setup(x => x.getCustomerByEmail("")).Returns(customer);
            var result = mockRepository.Object.getCustomerByEmail("");
            Assert.NotEqual("", result.customer_email);
            Assert.NotEqual("", result.customer_password);
            Assert.NotEqual("", result.first_name);
            Assert.NotEqual("", result.last_name);
            Assert.NotEqual("", result.phone_number);

        }
        [Fact]
        public void updateCustomerByEmail_UpdatesCustomerDetails()
        {
            //create the mock repository and fill the customer model with info
            var mockRepository = new Mock<ICustomerRepository>();
            var customer = new CustomerModel
            {
                customer_id = 1,
                first_name = "Quang",
                last_name = "Ho",
                customer_email = "QuangHo@gmail.com",
                phone_number = "1234567890",
                reward_points = "0",
                orderItem_id = 0,
                customer_password = "12345",
            };

            mockRepository.Setup(repo => repo.getCustomerByEmail("QuangHo@gmail.com")).Returns(customer);

            //need this section to set up the new customer details by using a callback to the original argument
            mockRepository.Setup(repo => repo.updateCustomerByEmail(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                          .Callback<string, string, string, string, string>((firstname, lastname, email, phone, password) =>
                          {
                              if (customer.customer_email == email)
                              {
                                  customer.first_name = firstname;
                                  customer.last_name = lastname;
                                  customer.phone_number = phone;
                                  customer.customer_password = password;
                              }
                          });
            //call the method and assign the new values to the customer object
            mockRepository.Object.updateCustomerByEmail("NewFirstName", "NewLastName", "QuangHo@gmail.com", "1234567890", "newpassword");
            var result = mockRepository.Object.getCustomerByEmail("QuangHo@gmail.com");
            Assert.Equal("NewFirstName", result.first_name);
            Assert.Equal("NewLastName", result.last_name);
            Assert.Equal("1234567890", result.phone_number);
            Assert.Equal("newpassword", result.customer_password);
        }
    }
}