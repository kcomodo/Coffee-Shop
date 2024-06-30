using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Folders.Services
{
    public interface IOrderServices
    {
        void addOrder(int customer_id, int product_id, int quantity, string status);
        void orderChange(int id,int quantity);
    }
}
