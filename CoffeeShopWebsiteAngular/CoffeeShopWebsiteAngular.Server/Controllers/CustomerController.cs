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

        //call the repository and services
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
        //backend part just to get information from the database
        [HttpGet("GetCustomerByEmail")]
        public IActionResult GetCustomerByEmail(string email)
        {
            var customer = _customerRepository.getCustomerByEmail(email);
            return Ok(customer);
        }
        //service side for customers
        [HttpPost("ValidateLogin")]
        public IActionResult ValidateLogin(string email, string password)
        {
            bool isValid = _customerServices.validateCustomerLogin(email, password);
            return Ok(isValid);
        }
        [HttpPost("RegisterCustomer")]
        public IActionResult RegisterCustomer(string firstname, string lastname, string email, string phone, string password)
        {
            _customerRepository.addCustomer(firstname, lastname, email, phone, password);
            return Ok();
        }
        [HttpDelete("DeleteCustomer")]
        public IActionResult DeleteCustomer(string email)
        {
            _customerRepository.deleteCustomerByEmail(email);
            return Ok();
        }
        [HttpPut("UpdateCustomer")]
        public IActionResult UpdateCustomer(string firstname, string lastname, string email, string phone, string password)
        {
            _customerRepository.updateCustomerByEmail(firstname, lastname, email, phone, password);
            return Ok();
        }
    }
}

