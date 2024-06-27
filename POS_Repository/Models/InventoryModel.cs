using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Folders.Models
{
    public class InventoryModel
    {
        public int item_id { get; set; }
        public string itemName { get; set; }
        public string category { get; set; }
        public int quantity { get; set; }
        public int cost { get; set; }
    }
}
