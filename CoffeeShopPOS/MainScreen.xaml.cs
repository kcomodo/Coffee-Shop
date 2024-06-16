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
using POS_Folders.Repository;
using POS_Folders.Services;
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
            CoffeeMenu.Visibility = Visibility.Visible;
            SnacksMenu.Visibility = Visibility.Visible;
            SandwichMenu.Visibility = Visibility.Visible;
            SettingMenu.Visibility = Visibility.Collapsed;
        }
        private void CoffeeButton_Click(object sender, RoutedEventArgs e)
        {
            CoffeeMenu.Visibility = Visibility.Visible;
            SnacksMenu.Visibility = Visibility.Collapsed;
            SandwichMenu.Visibility = Visibility.Collapsed;
            SettingMenu.Visibility = Visibility.Collapsed;
        }
        private void SnacksButton_Click(object sender, RoutedEventArgs e)
        {
            SnacksMenu.Visibility = Visibility.Visible;
            CoffeeMenu.Visibility = Visibility.Collapsed;
            SandwichMenu.Visibility = Visibility.Collapsed;
            SettingMenu.Visibility = Visibility.Collapsed;
        }
        private void SandwichButton_Click(object sender, RoutedEventArgs e)
        {
            SnacksMenu.Visibility = Visibility.Collapsed;
            CoffeeMenu.Visibility = Visibility.Collapsed;
            SandwichMenu.Visibility = Visibility.Visible;
            SettingMenu.Visibility = Visibility.Collapsed;
        }
        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonClose.Visibility = Visibility.Visible;
            ButtonOpen.Visibility = Visibility.Collapsed;
        }
        private void settingsButton_Click(object sender, RoutedEventArgs e)
        {
            SnacksMenu.Visibility = Visibility.Collapsed;
            CoffeeMenu.Visibility = Visibility.Collapsed;
            SandwichMenu.Visibility = Visibility.Collapsed;
            SettingMenu.Visibility = Visibility.Visible;

        }
        private void LatteClicked(object sender, RoutedEventArgs e)
        {
            AddToCart("Latte", 3.99m, 1);
        }
        private void CappuccinoClicked(object sender, RoutedEventArgs e)
        {
            AddToCart("Cappuccino", 4.99m, 1);
        }
        private void macchiatoClicked(object sender, RoutedEventArgs e)
        {
            AddToCart("Macchiato", 5.99m, 1);
        }
        private void string_cheeseClicked(object sender, RoutedEventArgs e)
        {
            AddToCart("String Cheese", 1.99m, 1);
        }
        private void shortbreadClicked(object sender, RoutedEventArgs e)
        {
            AddToCart("Shortbread", 2.99m, 1);
        }
        private void madeleineClicked(object sender, RoutedEventArgs e)
        {
            AddToCart("Madeleine", 3.99m, 1);
        }
        private void clubSandwichClicked(object sender, RoutedEventArgs e)
        {
            AddToCart("Club Sandwich", 6.99m, 1);
        }
        private void eggSandwichClicked(object sender, RoutedEventArgs e)
        {
            AddToCart("Egg Sandwich", 5.99m, 1);
        }
        private void submarineSandwichClicked(object sender, RoutedEventArgs e)
        {
            AddToCart("Submarine Sandwich", 7.99m, 1);
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonClose.Visibility = Visibility.Collapsed;
            ButtonOpen.Visibility = Visibility.Visible;
        }
        private void updateEmployeeInformation(object sender, RoutedEventArgs e)
        {
            IEmployeeRepository employeeRepository = new EmployeeRepository();
            string firstname = firstNameTextBox.Text;
            string lastName = lastNameTextBox.Text;
            string email = emailTextBox.Text;
            string password = passwordTextBox.Text;
            employeeRepository.updateEmployee(firstname, lastName, email, password);
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
