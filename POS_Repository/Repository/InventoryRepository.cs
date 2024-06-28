using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS_Folders.Models;
namespace POS_Folders.Repository
{
    public class InventoryRepository : IInventoryRepository
    {
        public MySqlConnection _connection;
        //public class will connect to the server, will move it onto azure later
        //use localhost for now on myphpadmin
        //if no password check for port
        public InventoryRepository()
        {
            string connectionString = "server=127.0.0.1;database=coffeeshop;userid=root;port=3307";
            _connection = new MySqlConnection(connectionString);
            _connection.Open();

        }
        //Make a destructor class to close the connection when employee repository is no longer in use
        ~InventoryRepository()
        {
            _connection.Close();
        }
        public IEnumerable<InventoryModel> GetInventoryInfo()
        {
            List<InventoryModel> inventory = new List<InventoryModel>();
            string query = "SELECT * FROM inventory";
            MySqlCommand command = new MySqlCommand(query, _connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                InventoryModel inventoryModel = new InventoryModel();
                inventoryModel.item_id = reader.GetInt32("item_id");
                inventoryModel.itemName = reader.GetString("itemName");
                inventoryModel.category = reader.GetString("category");
                inventoryModel.quantity = reader.GetInt16("quantity");
                inventoryModel.cost = reader.GetDouble("cost");
                inventory.Add(inventoryModel);
            }
            return inventory;
        }
        public void addInventory(string itemName, string category, int quantity, double cost)
        {
            string query = "INSERT INTO inventory (itemName, category, quantity, cost) VALUES (@itemName, @category, @quantity, @cost)";
            MySqlCommand command = new MySqlCommand(query, _connection);
            command.Parameters.AddWithValue("@itemName", itemName);
            command.Parameters.AddWithValue("@category", category);
            command.Parameters.AddWithValue("@quantity", quantity);
            command.Parameters.AddWithValue("@cost", cost);
            command.ExecuteNonQuery();
        }
        public void deleteInventory(int item_id)
        {
            string query = "DELETE FROM inventory WHERE item_id = @item_id";
            MySqlCommand command = new MySqlCommand(query, _connection);
            command.Parameters.AddWithValue("@item_id", item_id);
            command.ExecuteNonQuery();
        }
        public void updateInventory(string itemName, string category, int quantity, double cost, string target)
        {
            string query = "UPDATE inventory SET itemName = @itemName, category = @category, quantity = @quantity, cost = @cost WHERE itemName = @target";
            MySqlCommand command = new MySqlCommand(query, _connection);
            command.Parameters.AddWithValue("@itemName", itemName);
            command.Parameters.AddWithValue("@category", category);
            command.Parameters.AddWithValue("@quantity", quantity);
            command.Parameters.AddWithValue("@cost", cost);
            command.Parameters.AddWithValue("@target", target);
            command.ExecuteNonQuery();
        }
    }

}
