using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS_Folders.Models;
namespace POS_Folders.Repository
{
    public interface ICustomerRepository
    {
        /*
           Keep these in repository interface for customer CRUD operations
           public void addCustomer(string firstname, string lastname, string email, string password)
           public void updateCustomer(string firstname, string lastname,string email, string password)
           public void deleteCustomer(string email)
           public CustomerModel getCustomerByEmail(string email)
           
       */
        CustomerModel getCustomerByEmail(string email);
        void addCustomer(string firstname, string lastname, string email, string phone, string password);
        void deleteCustomerByEmail(string email);
    }
}
