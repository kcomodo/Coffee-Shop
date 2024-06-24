using Microsoft.AspNetCore.Mvc;
using POS_Folders.Repository;
using POS_Folders.Services;
using ZstdSharp.Unsafe;

namespace CoffeeShopWebsiteAngular.Server.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IEmployeeServices _employeeServices;
        public IActionResult Index()
        {
            return View();
        }
        public EmployeeController(IEmployeeRepository employeeRepository, IEmployeeServices employeeServices)
        {
            _employeeRepository = employeeRepository;
            _employeeServices = employeeServices;
        }
        [HttpPost("EmployeeValidateLogin")]
        public IActionResult ValidateLogin(string email, string password)
        {
            bool isValid = _employeeServices.validateEmployeeLogin(email, password);
            return Ok(isValid);
        }
        [HttpGet("GetEmployeeByEmail")]
        public IActionResult GetEmployeeByEmail(string email)
        {
            var employee = _employeeRepository.getEmployeeByEmail(email);
            return Ok(employee);
        }
        [HttpGet("GetEmployeeById")]
        public IActionResult GetEmployeeById(int id)
        {
            var employee = _employeeRepository.getEmployeeId(id);
            return Ok(employee);
        }
        [HttpPost("updateEmployee")]
        public IActionResult updateEmployee(string firstname, string lastname, string email, string password, string target)
        {
            _employeeRepository.updateEmployee(firstname, lastname, email, password, target);
            return Ok();
        }
        [HttpDelete("DeleteEmployee")]
        public IActionResult DeleteEmployee(string email)
        {
            _employeeRepository.deleteEmployeebyEmail(email);
            return Ok();
        }
        [HttpPost("AddEmployee")]
        public IActionResult AddEmployee(string firstname, string lastname, string email, string password)
        {
            _employeeRepository.addEmployee(firstname, lastname, email, password);
            return Ok();
        }

    }
}
