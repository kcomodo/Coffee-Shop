using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Folders.Models
{
    public class OrderModel
    {
        public int orderItem_id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string State { get; set; }
        public string Phone { get; set; }
        public int item_id { get; set; }
        public int quantity { get; set; }
        public double unitPrice { get; set; }
        public double totalPrice { get; set; }
    }
}
