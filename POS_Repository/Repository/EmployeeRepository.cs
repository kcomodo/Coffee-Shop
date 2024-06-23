using MySql.Data.MySqlClient;
using POS_Folders.Models;
namespace POS_Folders.Repository
{
    //Handles data access
    //Main Repository Folder, has an interface using IEmployeeRepository
    //Repository Layer, Contains the implementation of the CRUD operations
    //Create, Read, Update, Delete for Employee

    public class EmployeeRepository : IEmployeeRepository
    {
        //create connection for MySql
        public MySqlConnection _connection;
        //public class will connect to the server, will move it onto azure later
        //use localhost for now on myphpadmin
        //if no password check for port
        public EmployeeRepository()
        {
            string connectionString = "server=127.0.0.1;database=coffeeshop;userid=root;port=3307";
            _connection = new MySqlConnection(connectionString);
            _connection.Open();
            
        }
        //Make a destructor class to close the connection when employee repository is no longer in use
        ~EmployeeRepository()
        {
            _connection.Close();
        }
        //create a list for EmployeeModel to store the employees information
        private readonly List<EmployeeModel> _employees = new List<EmployeeModel>();
        //Grab the employee information using the id
        //CRUD Operation, Create, Read, Update, Delete
        public EmployeeModel getEmployeeId(int id)
        {
            //Create query statement to get the employee information
            string query = "SELECT * FROM employee WHERE employee_id = @employee_id";
            //Pass the query statement to the MySqlCommand and the connection
            MySqlCommand cmd = new MySqlCommand(query, _connection);
            //Add only the id to the query statement
            cmd.Parameters.AddWithValue("@employee_id", id);
            //Read and execute the query statement
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                //Create a new object to store the information
                EmployeeModel employee = new EmployeeModel();
                employee.employee_id = reader.GetInt32("employee_id");
                employee.employee_firstname = reader.GetString("first_name");
                employee.employee_lastname = reader.GetString("last_name");
                employee.employee_email = reader.GetString("employee_email");
                employee.employee_password = reader.GetString("employee_password");
                //Return object as soon as it's done
                return employee;
            }
            //If no information is found, return null
            return null;
        }
        public void deleteEmployeebyEmail(string email)
        {
            //Create query statement to delete the employee information
            string query = "DELETE FROM employee WHERE employee_email = @employee_email";
            //Pass the query statement to the MySqlCommand and the connection
            MySqlCommand cmd = new MySqlCommand(query, _connection);
            //Add only the email to the query statement
            cmd.Parameters.AddWithValue("@employee_email", email);
            //Execute the query statement
            cmd.ExecuteNonQuery();
        }
        public EmployeeModel getEmployeeByEmail(string email)
        {
            string query = "SELECT * FROM employee WHERE employee_email = @employee_email";
            MySqlCommand cmd = new MySqlCommand(query, _connection);
            cmd.Parameters.AddWithValue("@employee_email", email);
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                EmployeeModel employee = new EmployeeModel();
                employee.employee_email = reader.GetString("employee_email");
                employee.employee_password = reader.GetString("employee_password");
                return employee;
            }
            return null;
        }

        //Create operation
        public void addEmployee(string firstname, string lastname, string email, string password)
        {
            //adjust this later
            string query = "INSERT INTO employee (first_name, last_name ,employee_email, employee_password) VALUES (@first_name, @last_name, @employee_email, @employee_password)";
            MySqlCommand cmd = new MySqlCommand(query, _connection);
            cmd.Parameters.AddWithValue("@first_name", firstname);
            cmd.Parameters.AddWithValue("@last_name", lastname);
            cmd.Parameters.AddWithValue("@employee_email", email);
            cmd.Parameters.AddWithValue("@employee_password", password);
            cmd.ExecuteNonQuery();
        }
        //Update operation
        public void updateEmployee(string firstname, string lastname,string email, string password, string target)
        {
            //adjust this later
            string query = "UPDATE employee SET first_name = @first_name, last_name = @last_name, employee_email = @employee_email, employee_password = @employee_password WHERE employee_email = @target_email";
            MySqlCommand cmd  = new MySqlCommand(query, _connection);
            cmd.Parameters.AddWithValue("@first_name", firstname);
            cmd.Parameters.AddWithValue("@last_name", lastname);
            cmd.Parameters.AddWithValue("@employee_email", email);
            cmd.Parameters.AddWithValue("@employee_password", password);
            cmd.Parameters.AddWithValue("@target_email", target);
            cmd.ExecuteNonQuery();
        }
        //Delete operation
        public void deleteEmployee(string email)
        {
            //adjust this later
            string query = "DELETE FROM employee WHERE employee_email = @employee_email";
            MySqlCommand cmd = new MySqlCommand(query, _connection);
            cmd.Parameters.AddWithValue("@employee_email", email);
            cmd.ExecuteNonQuery();
        }

    }
}
