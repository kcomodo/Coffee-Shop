using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
namespace POS_Folders.Models
{
    public class ItemModel
    {
        public ObservableCollection<DataGridItem> DataGridItems { get; set; }

        public ItemModel()
        {
            DataGridItems = new ObservableCollection<DataGridItem>();
        }
    }

    public class DataGridItem
    {
        public string Name { get; set; }
        public string Price { get; set; }
        public string Quantity { get; set; }
    }
}
