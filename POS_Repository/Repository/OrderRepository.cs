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
            string query = "SELECT * FROM orders WHERE order_id = @order_id";
            MySqlCommand cmd = new MySqlCommand(query, _connection);
            cmd.Parameters.AddWithValue("@order_id", id);
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                OrderModel order = new OrderModel
                {
                    orderItem_id = reader.GetInt32("orderItem_id"),
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
            string query = "DELETE FROM orders WHERE orderItem_id = @orderItem_id";
            MySqlCommand cmd = new MySqlCommand(query, _connection);
            cmd.Parameters.AddWithValue("@orderItem_id", id);
            cmd.ExecuteNonQuery();
        }
        public void addOrder(int customer_id, int product_id, int quantity, string status)
        {
            string query = "INSERT INTO orders(customer_id, product_id, quantity, status) VALUES (@customer_id, @product_id, @quantity, @status)";
            MySqlCommand cmd = new MySqlCommand(query, _connection);
            cmd.Parameters.AddWithValue("@customer_id", customer_id);
            cmd.Parameters.AddWithValue("@product_id", product_id);
            cmd.Parameters.AddWithValue("@quantity", quantity);
            cmd.Parameters.AddWithValue("@status", status);
            cmd.ExecuteNonQuery();
        }
        public void updateOrder(int id, int quantity)
        {
            string query = "UPDATE orders SET quantity = @quantity WHERE order_id = @order_id";
            MySqlCommand cmd = new MySqlCommand(query, _connection);
            cmd.Parameters.AddWithValue("@quantity", quantity);
            cmd.Parameters.AddWithValue("@order_id", id);
            cmd.ExecuteNonQuery();
        }
    }
}
