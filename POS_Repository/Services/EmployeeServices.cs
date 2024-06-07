using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS_Folders.Repository;
namespace POS_Folders.Services
{
    internal class EmployeeServices
    {
    }
    /*
public bool validateEmployeeLogin(string email, string password)
{

    string query = "Select employee_email, employee_password from employee";
    MySqlCommand cmd = new MySqlCommand(query, _connection);
    var results = cmd.ExecuteReader();
    while (results.Read())
    {
        if (results.GetString(0) == email && results.GetString(1) == password)
        {
            return true;
        }
    }
    results.Close();
    return false;
}
*/
}
