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
            string query = "SELECT * FROM employee WHERE employee_id = @employee_id";
            MySqlCommand cmd = new MySqlCommand(query, _connection);
            cmd.Parameters.AddWithValue("@employee_id", id);
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                EmployeeModel employee = new EmployeeModel();
                employee.employee_id = reader.GetInt32("employee_id");
                employee.employee_firstname = reader.GetString("employee_firstname");
                employee.employee_lastname = reader.GetString("employee_lastname");
                employee.employee_email = reader.GetString("employee_email");
                employee.employee_password = reader.GetString("employee_password");
                return employee;
            }
            return null;
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
        public void addEmployee(string firstname, string lastname, string email, string password)
        {
            //adjust this later
            string query = "INSERT INTO employee (employee_fistname, employee_lastname ,employee_email, employee_password) VALUES (@employee_email, @employee_password)";
            MySqlCommand cmd = new MySqlCommand(query, _connection);
            cmd.Parameters.AddWithValue("@employee_fistname", firstname);
            cmd.Parameters.AddWithValue("@employee_lastname", lastname);
            cmd.Parameters.AddWithValue("@employee_email", email);
            cmd.Parameters.AddWithValue("@employee_password", password);
            cmd.ExecuteNonQuery();
        }
        public void updateEmployee(string firstname, string lastname,string email, string password)
        {
            //adjust this later
            string query = "UPDATE employee SET employee_firstname = @employee_firstname, employee_lastname = @employee_lastname, employee_email = @employee_email, employee_password = @employee_password WHERE employee_email = @employee_email";
            MySqlCommand cmd = new MySqlCommand(query, _connection);
            cmd.Parameters.AddWithValue("@employee_firstname", firstname);
            cmd.Parameters.AddWithValue("@employee_lastname", lastname);
            cmd.Parameters.AddWithValue("@employee_email", email);
            cmd.Parameters.AddWithValue("@employee_password", password);
            cmd.ExecuteNonQuery();
        }
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
