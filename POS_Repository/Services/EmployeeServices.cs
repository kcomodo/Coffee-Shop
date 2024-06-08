using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using POS_Folders.Repository;
namespace POS_Folders.Services
{
    //Main Services Folder, has an interface using IEmployeeServices
    //Services Layer, Contains the implementation of the business logic
    internal class EmployeeServices : IEmployeeServices
    {
        private readonly IEmployeeRepository _employeeRepository;
        public bool validateEmployeeLogin(string email, string password)
        {
            //get employee list first then check if email and password match
            var employee = _employeeRepository.getEmployeeByEmail(email);
            if(email == employee.employee_email && password == employee.employee_password)
            { return true; }
            return false;
        }



    }
}
