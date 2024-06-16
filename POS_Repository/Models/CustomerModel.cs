using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Folders.Models
{
    public class CustomerModel
    {
        public int customer_id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string customer_email { get; set; }
        public int phone_number { get; set; }
        public string reward_points { get; set; }
        public int orderItem_id { get; set; }
        public string customer_password { get; set; }

    }
}
