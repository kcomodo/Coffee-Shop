using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS_Folders.Models;
namespace POS_Folders.Services
{
    public interface ICustomerServices
    {
        bool validateCustomerLogin(string email, string password);
        
    }
}
