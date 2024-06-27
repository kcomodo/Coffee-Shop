using Microsoft.AspNetCore.Mvc;

namespace CoffeeShopWebsiteAngular.Server.Controllers
{
    public class InventoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
