using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using POS_Folders.Repository;
using POS_Folders.Services;
namespace CoffeeShopWebsiteAngular.Server.Controllers
{
    //Create a new controller for customer
    //Call the repository
    //Call the CRUD operations
 
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ICustomerServices _customerServices;
        public IActionResult Index()
        {
            return View();
        }
        public CustomerController(ICustomerRepository customerRepository, ICustomerServices customerServices)
        {
            _customerRepository = customerRepository;
            _customerServices = customerServices;

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
        [HttpPost("ValidateLogin")]
        public IActionResult ValidateLogin([FromBody] LoginRequest loginRequest)
        {
            var customer = _customerServices.validateCustomerLogin(loginRequest.Email, loginRequest.Password);
            if (customer == null)
            {
                return Unauthorized("Invalid email or password");
            }
            return Ok(customer);
        }
    }
}

