using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Dynamic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using POS_Folders.Models;
using ZstdSharp.Unsafe;
namespace CoffeeShopPOS
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class MainScreen : Window
    {
        public ItemModel ItemModel { get; set; }
        public MainScreen()
        {
            InitializeComponent();
            ItemModel = new ItemModel();
            this.DataContext = ItemModel;
        }
        private void DisplayMessage(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Clicked.");
            this.Hide();
        }
        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
           
        }
        private void CoffeeButton_Click(object sender, RoutedEventArgs e)
        {
 
        }
        private void LatteClicked(object sender, RoutedEventArgs e)
        {
            AddToCart("Latte", 3.99m, 1);
        }
        private void SnacksButton_Click(object sender, RoutedEventArgs e)
        {
           
        }
        private void SandwichButton_Click(object sender, RoutedEventArgs e)
        {
            
        }
        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonClose.Visibility = Visibility.Visible;
            ButtonOpen.Visibility = Visibility.Collapsed;
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonClose.Visibility = Visibility.Collapsed;
            ButtonOpen.Visibility = Visibility.Visible;
        }

        public void AddToCart(string itemName, decimal price, int quantity)
        { 
            var newItem = new DataGridItem
            {
                Name = itemName,
                Price = price.ToString("C"), // Currency format
                Quantity = quantity.ToString()
            };

            ItemModel.DataGridItems.Add(newItem);
            this.DataContext = ItemModel;
        }

    }
}
