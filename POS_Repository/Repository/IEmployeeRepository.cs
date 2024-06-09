using POS_Folders.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Folders.Repository
{
    public interface IEmployeeRepository
    {
        /*
           Keep these in repository interface for employee CRUD operations
           public void addEmployee(string firstname, string lastname, string email, string password)
           public void updateEmployee(string firstname, string lastname,string email, string password)
           public void deleteEmployee(string email)
           public EmployeeModel getEmployeeByEmail(string email)
           
       */
        EmployeeModel getEmployeeId(int id);
        void addEmployee(string firstname, string lastname, string email, string password);
        EmployeeModel getEmployeeByEmail(string email);
        void updateEmployee(string firstname, string lastname, string email, string password);
        void deleteEmployee(string email);
    }
}
