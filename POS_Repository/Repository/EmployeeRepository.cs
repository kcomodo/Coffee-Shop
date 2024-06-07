using MySql.Data.MySqlClient;
using POS_Folders.Models;
namespace POS_Folders.Repository
{
    public class EmployeeRepository
    {
        public MySqlConnection _connection;
        public EmployeeRepository()
        {
            string connectionString = "server=127.0.0.1;database=coffeeshop;userid=root;port=3307";
            _connection = new MySqlConnection(connectionString);
            _connection.Open();
        }
        ~EmployeeRepository()
        {
            _connection.Close();
        }
        /*
        Keep these in repository for employee CRUD operations
        public void addEmployee(string email, string password)
        public void updateEmployee(string firstname, string lastname,string email, string password)
        public void deleteEmployee(string email)

        */
        //Put this into EmployeeServices.cs
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
    }
}
