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
using POS_Folders.Models;
using Org.BouncyCastle.Crypto.Macs;
using MySqlX.XDevAPI.Common;
using Microsoft.AspNetCore.Mvc;
using System.Net.Sockets;
namespace UnitTest
{
    public class OrderUnitTest
    {
        [Fact]
        public void getOrder_true()
        {
            //create a mock repository, assign the order object with values for testing
            var mockRepository = new Mock<IOrderRepository>();
            var order = new OrderModel
            {
                orderItem_id = 1,
                FirstName = "TestFirstName",
                LastName = "TestLastName",
                Address = "1234 Test St",
                State = "TestState",
                Phone = "1234567890",
                item_id = 1,
                quantity = 1,
                unitPrice = 1.00,
                totalPrice = 1.00
            };
            mockRepository.Setup(x => x.GetOrder(1)).Returns(order);
            var results = mockRepository.Object.GetOrder(1);
            Assert.Equal(1, results.orderItem_id);
            Assert.Equal("TestFirstName", results.FirstName);
            Assert.Equal("TestLastName", results.LastName);
            Assert.Equal("1234 Test St", results.Address);
            Assert.Equal("TestState", results.State);
            Assert.Equal("1234567890", results.Phone);
            Assert.Equal(1, results.item_id);
            Assert.Equal(1, results.quantity);
            Assert.Equal(1.00, results.unitPrice);
            Assert.Equal(1.00, results.totalPrice);

        }
        [Fact]
        public void getOrder_false()
        {
            //create a mock repository, assign the order object with values for testing
            var mockRepository = new Mock<IOrderRepository>();
            var order = new OrderModel
            {
                orderItem_id = 1,
                FirstName = "TestFirstName",
                LastName = "TestLastName",
                Address = "1234 Test St",
                State = "TestState",
                Phone = "1234567890",
                item_id = 1,
                quantity = 1,
                unitPrice = 1.00,
                totalPrice = 1.00
            };
            mockRepository.Setup(x => x.GetOrder(1)).Returns(order);
            var results = mockRepository.Object.GetOrder(1);
            Assert.NotEqual(2, results.orderItem_id);
            Assert.NotEqual("NotTestFirstName", results.FirstName);
            Assert.NotEqual("NotTestLastName", results.LastName);
            Assert.NotEqual("1234 NotTest St", results.Address);
            Assert.NotEqual("NotTestState", results.State);
            Assert.NotEqual("0987654321", results.Phone);
            Assert.NotEqual(2, results.item_id);
            Assert.NotEqual(2, results.quantity);
            Assert.NotEqual(2.00, results.unitPrice);
            Assert.NotEqual(2.00, results.totalPrice);
        }
        [Fact]
        public void addOrder_True()
        {

        }
        [Fact]
        public void addOrder_False()
        {

        }
        [Fact]
        public void updateOrder_True()
        {

        }
        [Fact]
        public void updateOrder_False()
        {

        }
        [Fact]
        public void deleteOrder_True()
        {
        }
    }
}
