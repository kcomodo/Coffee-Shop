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
    public class InventoryUnitTest
    {
        [Fact]
        public void getInventoryInfo_True()
        {
            var mockRepository = new Mock<IInventoryRepository>();
            var expectedInventory = new List<InventoryModel> {
                new InventoryModel
            {
                item_id = 1,
                itemName = "test",
                category = "Coffee",
                quantity = 1,
                cost = 1.00
            }
          };
            mockRepository.Setup(x => x.GetInventoryInfo()).Returns(expectedInventory);
            var results = mockRepository.Object.GetInventoryInfo();
         
            Assert.Equal(expectedInventory.Count, results.Count());

            foreach (var expectedItem in expectedInventory)
            {
                Assert.Contains(expectedItem, results);
            }

        }
        [Fact]
        public void getInventoryInfo_False()
        {
  
            var mockRepository = new Mock<IInventoryRepository>();
            var inventory = new List<InventoryModel>(); 

            mockRepository.Setup(x => x.GetInventoryInfo()).Returns(inventory);

            var results = mockRepository.Object.GetInventoryInfo();

            Assert.Empty(results);
        }
        [Fact]
        public void addInventory_True()
        {
            var mockRepository = new Mock<IInventoryRepository>();
            

            // Setup mock repository behavior for adding a customer
            //setup the repository while calling the addCustomer method, then do a callback to set the customer object with the new values
            mockRepository.Setup(repo => repo.addInventory(
                It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>(), It.IsAny<double>()))
                .Callback<string, string, int, double>((itemName, category, quantity, cost) =>
                {
                    var expectedInventory = new List<InventoryModel> {
                new InventoryModel
                    {
                        itemName = itemName,
                        category = category,
                        quantity = quantity,
                        cost = cost

                    }
                };

                    // Setup the getCustomerByEmail to return this customer after adding
                    mockRepository.Setup(x => x.GetInventoryInfo()).Returns(expectedInventory);
                });
            mockRepository.Object.addInventory("test", "Coffee", 1, 1.00);
            var results = mockRepository.Object.GetInventoryInfo();
            Assert.NotEmpty(results);
            Assert.NotNull(results);
            foreach (var expectedItem in results)
            {
                Assert.Contains(expectedItem, results);
            }
        }
        [Fact]
        public void addInventory_False()
        {
            var mockRepository = new Mock<IInventoryRepository>();


            // Setup mock repository behavior for adding a customer
            //setup the repository while calling the addCustomer method, then do a callback to set the customer object with the new values
            mockRepository.Setup(repo => repo.addInventory(
                It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>(), It.IsAny<double>()))
                .Callback<string, string, int, double>((itemName, category, quantity, cost) =>
                {
                    var expectedInventory = new List<InventoryModel> {
                new InventoryModel
                    {
                        itemName = itemName,
                        category = category,
                        quantity = quantity,
                        cost = cost

                    }
                };

                    // Setup the getCustomerByEmail to return this customer after adding
                    mockRepository.Setup(x => x.GetInventoryInfo()).Returns(expectedInventory);
                });
            
            var results = mockRepository.Object.GetInventoryInfo();
            Assert.Empty(results);

        }
        [Fact]
        public void updateInventory_True()
        {
            var mockRepository = new Mock<IInventoryRepository>();


            // Setup mock repository behavior for adding a customer
            //setup the repository while calling the addCustomer method, then do a callback to set the customer object with the new values
            mockRepository.Setup(repo => repo.addInventory(
                It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>(), It.IsAny<double>()))
                .Callback<string, string, int, double>((itemName, category, quantity, cost) =>
                {
                    var expectedInventory = new List<InventoryModel> {
                new InventoryModel
                    {
                        itemName = itemName,
                        category = category,
                        quantity = quantity,
                        cost = cost

                    }
                };

                    // Setup the getCustomerByEmail to return this customer after adding
                    mockRepository.Setup(x => x.GetInventoryInfo()).Returns(expectedInventory);
                });

            var results = mockRepository.Object.GetInventoryInfo();
            Assert.Empty(results);
        }
        [Fact]
        public void updateInventory_False()
        {

        }
        [Fact]
        public void deleteInventory_True()
        {

        }
        [Fact]
        public void deleteInventory_False()
        {

        }
    }
}
