using MySql.Data.MySqlClient;
using POS_Folders.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Folders.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly MySqlConnection _connection;

        public OrderRepository()
        {
            string connectionString = "server=127.0.0.1;database=coffeeshop;userid=root;port=3307";
            _connection = new MySqlConnection(connectionString);
            _connection.Open();
        }

        ~OrderRepository()
        {
            _connection.Close();
        }
        public List<OrderModel> _orders = new List<OrderModel>();
        public OrderModel GetOrder(int id)
        {
            string query = "SELECT * FROM orderitem WHERE orderItem_id = @orderItem_id";
            MySqlCommand cmd = new MySqlCommand(query, _connection);
            cmd.Parameters.AddWithValue("@orderItem_id", id);
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                OrderModel order = new OrderModel
                {
                    orderItem_id = reader.GetInt32("orderItem_id"),
                    FirstName = reader.GetString("FirstName"),
                    LastName = reader.GetString("LastName"),
                    Address = reader.GetString("Address"),
                    State = reader.GetString("State"),
                    Phone = reader.GetString("Phone"),
                    item_id = reader.GetInt32("item_id"),
                    quantity = reader.GetInt32("quantity"),
                    unitPrice = reader.GetDouble("unitPrice"),
                    totalPrice = reader.GetDouble("totalPrice")
                };
                return order;
            }
            return null;
        }
        public void deleteOrder(int id)
        {
            string query = "DELETE FROM orderitem WHERE orderItem_id = @orderItem_id";
            MySqlCommand cmd = new MySqlCommand(query, _connection);
            cmd.Parameters.AddWithValue("@orderItem_id", id);
            cmd.ExecuteNonQuery();
        }
        public void addOrder(string FirstName, string LastName, string Address, string State, string Phone, int item_id, int quantity, double unitPrice, double totalPrice)
        {
            string query = "INSERT INTO orderitem (FirstName, LastName, Address, State, Phone, item_id, quantity, unitPrice, totalPrice) VALUES (@FirstName, @LastName, @Address, @State, @Phone, @item_id, @quantity, @unitPrice, @totalPrice)";
            MySqlCommand cmd = new MySqlCommand(query, _connection);
            cmd.Parameters.AddWithValue("@FirstName", FirstName);
            cmd.Parameters.AddWithValue("@LastName", LastName);
            cmd.Parameters.AddWithValue("@Address", Address);
            cmd.Parameters.AddWithValue("@State", State);
            cmd.Parameters.AddWithValue("@Phone", Phone);
            cmd.Parameters.AddWithValue("@item_id", item_id);
            cmd.Parameters.AddWithValue("@quantity", quantity);
            cmd.Parameters.AddWithValue("@unitPrice", unitPrice);
            cmd.Parameters.AddWithValue("@totalPrice", totalPrice);
            cmd.ExecuteNonQuery();
        }
        public void updateOrder(int id, string Address, string State, string Phone, int quantity, double unitPrice, double totalPrice)
        {
            string query = "UPDATE orderitem SET quantity = @quantity WHERE orderItem_id = @orderItem_id";
            MySqlCommand cmd = new MySqlCommand(query, _connection);
            cmd.Parameters.AddWithValue("@orderItem_id", id);
            cmd.Parameters.AddWithValue("@Address", Address);
            cmd.Parameters.AddWithValue("@State", State);
            cmd.Parameters.AddWithValue("@Phone", Phone);
            cmd.Parameters.AddWithValue("@quantity", quantity);
            cmd.Parameters.AddWithValue("@unitPrice", unitPrice);
            cmd.Parameters.AddWithValue("@totalPrice", totalPrice);
            cmd.ExecuteNonQuery();
        }
    }
}
