using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using POS_Folders.Models;
using POS_Folders.Repository;
namespace POS_Folders.Services
{
    //Main Services Folder, has an interface using IEmployeeServices
    //Services Layer, Contains the implementation of the business logic
    public class EmployeeServices : IEmployeeServices
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeServices(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
        }
        public bool validateEmployeeLogin(string email, string password)
        {
            //get employee list first then c   heck if email and password match
            if (_employeeRepository == null)
            {
                // Handle the case where _employeeRepository is null
                return false;
            }
            EmployeeModel employee = _employeeRepository.getEmployeeByEmail(email);
            if (email == employee.employee_email && password == employee.employee_password)
            { return true; }
            return false;
        }



    }
}
