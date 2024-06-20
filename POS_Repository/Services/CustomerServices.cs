using POS_Folders.Models;
using POS_Folders.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Folders.Services
{
    public class CustomerServices : ICustomerServices
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerServices(ICustomerRepository customerRepository)
        {
            //If employeeRepository object is null, throw an exception
            _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
        }
        public bool validateCustomerLogin(string email, string password)
        {
            //get employee email list first then check if email and password match
            //employee object will store the employee information as a list
            CustomerModel customer = _customerRepository.getCustomerByEmail(email);
            //If the email and passwrod that the user enter matches with the database then send true, else false
            if (email == customer.customer_email && password == customer.customer_password)
            { return true; }
            return false;
        }
    }

}
