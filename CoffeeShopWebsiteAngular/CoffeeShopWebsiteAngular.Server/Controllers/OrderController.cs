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
        public IActionResult AddOrder(int customer_id, int product_id, int quantity, string status)
        {
            _orderRepository.addOrder(customer_id, product_id, quantity, status);
            return Ok();
        }
        [HttpDelete]
        public IActionResult DeleteOrder(int id)
        {
            _orderRepository.deleteOrder(id);
            return Ok();
        }
        [HttpPut("UpdateOrder")]
        public IActionResult UpdateOrder(int id, int quantity)
        {
            _orderRepository.updateOrder(id, quantity);
            return Ok();
        }
        [HttpPost("CustomerAddOrder")]
        public IActionResult CustomerAddOrder(int customer_id, int product_id, int quantity, string status)
        {
            _orderServices.CustomerAddOrder(customer_id, product_id, quantity, status);
            return Ok();
        }
        [HttpPut("CustomerOrderChange")]
        public IActionResult CustomerOrderChange(int id, int quantity)
        {
            _orderServices.orderChange(id, quantity);
            return Ok();
        }
    
    }
}
