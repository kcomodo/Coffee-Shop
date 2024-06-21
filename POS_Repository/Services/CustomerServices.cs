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

            _customerRepository = customerRepository;
        }
        public bool validateCustomerLogin(string email, string password)
        {
 
            CustomerModel customer = _customerRepository.getCustomerByEmail(email);

            if (email == customer.customer_email && password == customer.customer_password)
            { 
                return true; 
            }
            return false;
        }
    }

}
