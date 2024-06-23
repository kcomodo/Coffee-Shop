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
        [HttpGet("GetEmployeeByEmail")]
        public IActionResult GetEmployeeByEmail(string email)
        {
            var employee = _employeeRepository.getEmployeeByEmail(email);
            return Ok(employee);
        }
    }
}
