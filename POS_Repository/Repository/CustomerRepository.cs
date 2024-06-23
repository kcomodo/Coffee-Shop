using MySql.Data.MySqlClient;
using POS_Folders.Models;
using System.Collections.Generic;

namespace POS_Folders.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly MySqlConnection _connection;

        public CustomerRepository()
        {
            string connectionString = "server=127.0.0.1;database=coffeeshop;userid=root;port=3307";
            _connection = new MySqlConnection(connectionString);
            _connection.Open();
        }

        ~CustomerRepository()
        {
            _connection.Close();
        }

        public List<CustomerModel> _customers = new List<CustomerModel>();

        public CustomerModel getCustomerByEmail(string email)
        {
            string query = "SELECT * FROM customer WHERE customer_email = @customer_email";
            MySqlCommand cmd = new MySqlCommand(query, _connection);
            cmd.Parameters.AddWithValue("@customer_email", email);
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                CustomerModel customer = new CustomerModel
                {
                    customer_id = reader.GetInt32("customer_id"),
                    first_name = reader.GetString("first_name"),
                    last_name = reader.GetString("last_name"),
                    customer_email = reader.GetString("customer_email"),
                    phone_number = reader.GetString("phone_number"),
                    customer_password = reader.GetString("customer_password")
                };
                return customer;
            }
            return null;
        }
        public void addCustomer(string firstname, string lastname,string email, string phone, string password)
        {
            string query = "INSERT INTO customer(first_name, last_name, customer_email, phone_number, customer_password) VALUES (@first_name, @last_name, @customer_email, @phone_number, @customer_password)";
            MySqlCommand cmd = new MySqlCommand(query, _connection);
            cmd.Parameters.AddWithValue("@first_name", firstname);
            cmd.Parameters.AddWithValue("@last_name", lastname);
            cmd.Parameters.AddWithValue("@customer_email", email);
            cmd.Parameters.AddWithValue("@phone_number", phone);
            cmd.Parameters.AddWithValue("@customer_password", password);
            cmd.ExecuteNonQuery();

        }
    }
}
