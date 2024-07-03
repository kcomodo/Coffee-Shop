using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Folders.Services
{
    public interface IOrderServices
    {
        void CustomerAddOrder(string FirstName, string LastName, string Address, string State, string Phone, int item_id, int quantity, double unitPrice, double totalPrice);
        void orderChange(int id, string Address, string State, string Phone, int quantity, double unitPrice, double totalPrice);

    }
}
