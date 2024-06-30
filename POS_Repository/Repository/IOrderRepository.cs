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
    }
}
