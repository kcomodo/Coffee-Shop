using Microsoft.AspNetCore.Mvc;
using POS_Folders.Repository;
using POS_Folders.Services;
namespace CoffeeShopWebsiteAngular.Server.Controllers
{
    public class InventoryController : Controller
    {
        private readonly IInventoryRepository _inventoryRepository;

        public IActionResult Index()
        {
            return View();
        }
        public InventoryController(IInventoryRepository inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;

        }
        [HttpGet("GetInventoryInfo")]
        public IActionResult GetInventoryInfo()
        {
            var inventory = _inventoryRepository.GetInventoryInfo();
            return Ok(inventory);
        }
        [HttpPost("AddInventory")]
        public IActionResult AddInventory(string itemName, string category, int quantity, double cost)
        {
            _inventoryRepository.addInventory(itemName, category, quantity, cost);
            return Ok();
        }

        [HttpDelete("DeleteInventory")]
        public IActionResult DeleteInventory(int item_id)
        {
            _inventoryRepository.deleteInventory(item_id);
            return Ok();
        }
        [HttpPut("UpdateInventory")]
        public IActionResult UpdateInventory(string itemName, string category, int quantity, double cost, string target)
        {
            _inventoryRepository.updateInventory(itemName, category, quantity, cost, target);
            return Ok();
        }
    }
}
