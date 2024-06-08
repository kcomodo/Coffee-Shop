using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Folders.Services
{
    //Interface for Employee Services
    public interface IEmployeeServices
    {
        bool validateEmployeeLogin(string email, string password);
    }
}
