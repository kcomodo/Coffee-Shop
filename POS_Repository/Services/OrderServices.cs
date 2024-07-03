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
        public void CustomerAddOrder(string FirstName, string LastName, string Address, string State, string Phone, int item_id, int quantity, double unitPrice, double totalPrice)
        {
            _orderRepository.addOrder(FirstName, LastName,Address,State,Phone,item_id, quantity, unitPrice, totalPrice);
        }
        public void orderChange(int id, string Address, string State, string Phone, int quantity, double unitPrice, double totalPrice)
        {
            _orderRepository.updateOrder(id, Address, State, Phone, quantity, unitPrice, totalPrice);
        }
    }
}
