using MySql.Data.MySqlClient;
namespace POS_Repository
{
    public class Class1
    {
        public MySqlConnection _connection;
        public Class1()
        {
            string connectionString = "server=127.0.0.1;database=coffeeshop;userid=root;port=3307";
            _connection = new MySqlConnection(connectionString);
            _connection.Open();
        }
        ~Class1()
        {
            _connection.Close();
        }
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
