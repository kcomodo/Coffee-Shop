using Microsoft.AspNetCore.Mvc;
using POS_Folders.Repository;
namespace CoffeeShopWebsiteAngular.Server.Controllers
{
    //Create a new controller for customer
    //Call the repository
    //Call the CRUD operations
 
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _customerRepository;
        public IActionResult Index()
        {
            return View();
        }
        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        [HttpGet("GetCustomerByEmail")]
        public IActionResult GetCustomerByEmail(string email)
        {
            var customer = _customerRepository.getCustomerByEmail(email);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }
    }
}
