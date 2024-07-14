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
        //_employeeRepository is an object of IEmployeeRepository
        //It is used to access the methods in the EmployeeRepository
        private readonly IEmployeeRepository _employeeRepository;

        //EmployeeServices parameter will take in an IEmployeeRepository object
        //This is a dependency injection
        //The constructor is designed to inject an implementation of the IEmployeeRepository interface into the EmployeeServices class
        public EmployeeServices(IEmployeeRepository employeeRepository)
        {
            //If employeeRepository object is null, throw an exception
            _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
        }
        public bool validateEmployeeLogin(string email, string password)
        {
            //get employee email list first then check if email and password match
            //employee object will store the employee information as a list
            EmployeeModel employee = _employeeRepository.getEmployeeByEmail(email);
            if (employee == null)
            {
                return false;
            }
            //If the email and passwrod that the user enter matches with the database then send true, else false
            if (email == employee.employee_email && password == employee.employee_password)
            { return true; }
            return false;
        }



    }
}
