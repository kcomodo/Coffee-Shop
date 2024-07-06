using CoffeeShopWebsiteAngular.Server.Controllers;
using Microsoft.AspNetCore.Mvc.Testing;
using Moq;
using POS_Folders.Repository;
using POS_Folders.Services;
using CoffeeShopWebsiteAngular.Server.Controllers;
using POS_Folders.Models;
using Org.BouncyCastle.Crypto.Macs;
namespace UnitTest1
{
    public class UnitTest1
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
                customer_password = ""
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
                customer_email = "Testing@gmail.com",
                customer_password = ""
            };
            mockRepository.Setup(x => x.getCustomerByEmail("Testing@gmail.com")).Returns(customer);
            var mockService = new CustomerServices(mockRepository.Object);
            var results = mockService.validateCustomerLogin(customer.customer_email, customer.customer_password);
            Assert.False(results);
        }
    }
}