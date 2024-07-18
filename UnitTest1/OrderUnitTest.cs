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
using Castle.Core.Resource;
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
            var mockRepository = new Mock<IOrderRepository>();
            var order_itemId = 1;
            mockRepository.Setup(repo => repo.addOrder(
                 It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<double>(), It.IsAny<double>()))
                 .Callback<string, string, string, string, string, int, int, double, double>((FirstName, LastName, Address, State, Phone, item_id, quantity, unitPrice, totalPrice) =>
                 {
                     var order = new OrderModel
                     {
                         orderItem_id = 1,
                         FirstName = FirstName,
                         LastName = LastName,
                         Address = Address,
                         State = State,
                         Phone = Phone,
                         item_id = item_id,
                         quantity = quantity,
                         unitPrice = unitPrice,
                         totalPrice = totalPrice
                     };
                     mockRepository.Setup(x => x.GetOrder(order_itemId)).Returns(order);
                 });
                mockRepository.Object.addOrder("TestFirstName", "TestLastName", "1234 Test St", "TestState", "1234567890", 1, 1, 1.00, 1.00);
            var results = mockRepository.Object.GetOrder(order_itemId);
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
        public void addOrder_False()
        {
            var mockRepository = new Mock<IOrderRepository>();
            var order_itemId = 1;
            mockRepository.Setup(repo => repo.addOrder(
                 It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<double>(), It.IsAny<double>()))
                 .Callback<string, string, string, string, string, int, int, double, double>((FirstName, LastName, Address, State, Phone, item_id, quantity, unitPrice, totalPrice) =>
                 {
                     var order = new OrderModel
                     {
                         orderItem_id = 1,
                         FirstName = FirstName,
                         LastName = LastName,
                         Address = Address,
                         State = State,
                         Phone = Phone,
                         item_id = item_id,
                         quantity = quantity,
                         unitPrice = unitPrice,
                         totalPrice = totalPrice
                     };
                     mockRepository.Setup(x => x.GetOrder(order_itemId)).Returns(order);
                 });
            mockRepository.Object.addOrder("TestFirstName", "TestLastName", "1234 Test St", "TestState", "1234567890", 1, 1, 1.00, 1.00);
            var results = mockRepository.Object.GetOrder(order_itemId);
            Assert.NotEqual(2, results.orderItem_id);
            Assert.NotEqual("FirstName", results.FirstName);
            Assert.NotEqual("LastName", results.LastName);
            Assert.NotEqual("Test St", results.Address);
            Assert.NotEqual("State", results.State);
            Assert.NotEqual("234567890", results.Phone);
            Assert.NotEqual(2, results.item_id);
            Assert.NotEqual(2, results.quantity);
            Assert.NotEqual(2.00, results.unitPrice);
            Assert.NotEqual(2.00, results.totalPrice);
        }
        [Fact]
        public void updateOrder_True()
        {
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
            mockRepository.Setup(repo => repo.updateOrder(
             It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>(), It.IsAny<double>(), It.IsAny<double>()))
             .Callback<int, string, string, string, int, double, double>((id, Address, State, Phone, quantity, unitPrice, totalPrice) =>
             {
          
                    order.Address = Address;
                 order.State = State;
                 order.Phone = Phone;
                 order.quantity = quantity;
                 order.unitPrice = unitPrice;
                 order.totalPrice = totalPrice;
                
             });
            mockRepository.Object.updateOrder(1, "1235 Test St", "NewTestState", "12345678901", 2, 2.00, 2.00);
            var results = mockRepository.Object.GetOrder(1);
            Assert.Equal("1235 Test St", results.Address);
            Assert.Equal("NewTestState", results.State);
            Assert.Equal("12345678901", results.Phone);
            Assert.Equal(2, results.quantity);
            Assert.Equal(2.00, results.unitPrice);
            Assert.Equal(2.00, results.totalPrice);

        
        }
        [Fact]
        public void updateOrder_False()
        {
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
            mockRepository.Setup(repo => repo.updateOrder(
             It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>(), It.IsAny<double>(), It.IsAny<double>()))
             .Callback<int, string, string, string, int, double, double>((id, Address, State, Phone, quantity, unitPrice, totalPrice) =>
             {

                 order.Address = Address;
                 order.State = State;
                 order.Phone = Phone;
                 order.quantity = quantity;
                 order.unitPrice = unitPrice;
                 order.totalPrice = totalPrice;

             });
        
            var results = mockRepository.Object.GetOrder(1);
            Assert.NotEqual("1235 Test St", results.Address);
            Assert.NotEqual("NewTestState", results.State);
            Assert.NotEqual("12345678901", results.Phone);
            Assert.NotEqual(2, results.quantity);
            Assert.NotEqual(2.00, results.unitPrice);
            Assert.NotEqual(2.00, results.totalPrice);
        }
        [Fact]
        public void deleteOrder_True()
        {
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
            mockRepository.Setup(x => x.deleteOrder(1));
            var fetchedOrder = mockRepository.Object.GetOrder(1);
            mockRepository.Object.deleteOrder(1);
            Assert.NotNull(fetchedOrder); 
            mockRepository.Verify(x => x.deleteOrder(1), Times.Once);
        }
        [Fact]
        public void deleteOrder_False()
        {
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
            mockRepository.Setup(x => x.deleteOrder(1)).Throws(new Exception("Delete failed"));
            var fetchedOrder = mockRepository.Object.GetOrder(1);
            Assert.NotNull(fetchedOrder); // Verify that customer is fetched
            Exception ex = Assert.Throws<Exception>(() => mockRepository.Object.deleteOrder(1));
            Assert.Equal("Delete failed", ex.Message);
            mockRepository.Verify(x => x.deleteOrder(1), Times.Once);
        }
    }
}
