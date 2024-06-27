using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
