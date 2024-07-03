using POS_Folders.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Folders.Repository
{
    public interface IOrderRepository
    {
        OrderModel GetOrder(int id);
        void deleteOrder(int id);
        void addOrder(string FirstName, string LastName, string Address, string State, string Phone, int item_id, int quantity, double unitPrice, double totalPrice);
        void updateOrder(int id, string Address, string State, string Phone, int quantity, double unitPrice, double totalPrice);
    }
}
