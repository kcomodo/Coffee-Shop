using Microsoft.AspNetCore.Mvc;
using POS_Folders.Repository;
using POS_Folders.Services;

namespace CoffeeShopWebsiteAngular.Server.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderServices _orderServices;
        public IActionResult Index()
        {
            return View();
        }
        public OrderController(IOrderRepository orderRepository, IOrderServices orderServices)
        {
            _orderRepository = orderRepository;
            _orderServices = orderServices;

        }
        [HttpGet("GetOrder")]
        public IActionResult GetOrder(int id)
        {
            var order = _orderRepository.GetOrder(id);
            return Ok(order);
        }
        [HttpPost("AddOrder")]
        public IActionResult AddOrder(string FirstName, string LastName, string Address, string State, string Phone, int item_id, int quantity, double unitPrice, double totalPrice)
        {
            _orderRepository.addOrder(FirstName, LastName, Address, State, Phone, item_id, quantity, unitPrice, totalPrice);
            return Ok();
        }
        [HttpDelete]
        public IActionResult DeleteOrder(int id)
        {
            _orderRepository.deleteOrder(id);
            return Ok();
        }
        [HttpPut("UpdateOrder")]
        public IActionResult UpdateOrder(int id, string Address, string State, string Phone, int quantity, double unitPrice, double totalPrice)
        {
            _orderRepository.updateOrder(id, Address, State, Phone, quantity, unitPrice, totalPrice);
            return Ok();
        }
        [HttpPost("CustomerAddOrder")]
        public IActionResult CustomerAddOrder(string FirstName, string LastName, string Address, string State, string Phone, int item_id, int quantity, int unitPrice, int totalPrice)
        {
            _orderServices.CustomerAddOrder(FirstName, LastName, Address, State, Phone, item_id, quantity, unitPrice, totalPrice);
            return Ok();
        }
        [HttpPut("CustomerOrderChange")]
        public IActionResult CustomerOrderChange(int id, string Address, string State, string Phone, int quantity, double unitPrice, double totalPrice)
        {
            _orderServices.orderChange(id, Address, State, Phone, quantity, unitPrice, totalPrice);
            return Ok();
        }
        [HttpDelete("CustomerDeleteOrder")]
        public IActionResult CustomerDeleteOrder(int id)
        {
            _orderRepository.deleteOrder(id);
            return Ok();
        }
    
    }
}
