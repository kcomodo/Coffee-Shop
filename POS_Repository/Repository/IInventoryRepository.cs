using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Org.BouncyCastle.Asn1.BC;
using POS_Folders.Models;
namespace POS_Folders.Repository
{
    public interface IInventoryRepository
    {
        IEnumerable<InventoryModel> GetInventoryInfo();
        public void addInventory(string itemName, string category, int quantity, double cost);
        public void deleteInventory(int itemName);
        public void updateInventory(string itemName, string category, int quantity, double cost, string target);
    }
}
