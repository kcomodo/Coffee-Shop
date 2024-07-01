using POS_Folders.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Folders.Services
{
    public class OrderServices : IOrderServices
    {
        private readonly IOrderRepository _orderRepository;
        public OrderServices(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public void CustomerAddOrder(int customer_id, int product_id, int quantity, string status)
        {
            _orderRepository.addOrder(customer_id, product_id, quantity, status);
        }
        public void orderChange(int id, int quantity)
        {
            _orderRepository.updateOrder(id, quantity);
        }
    }
}
