using Microsoft.AspNetCore.Mvc;
using POS_Folders.Repository;

namespace CoffeeShopWebsiteAngular.Server.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        public IActionResult Index()
        {
            return View();
        }
        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;

        }
    
    }
}
