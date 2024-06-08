using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace POS_Folders.Models
{
    //Domain Layer, Contains getter and setter for Employee
    //Architecture: Layered Architecture
    //WPF and Asp.Net will be the presentation layer
    //EmployeeModel is the Domain Layer
    //EmployeeRepository is the data access layer
    //EmployeeServices is the business logic layer
    //Use interfaces for the data and business layers: represent a contract for the class
    //Only use the interface, since loose coupling.
    public class EmployeeModel
    {
        public int employee_id { get; set; }
        public string employee_firstname { get; set; }
        public string employee_lastname { get; set; }
        public string employee_email { get; set; }
        public string employee_password { get; set; }
    }

}
