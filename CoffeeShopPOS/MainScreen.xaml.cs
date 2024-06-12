using System;
using System.Collections.Generic;
using System.Linq;
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

namespace CoffeeShopPOS
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class MainScreen : Window
    {
        public MainScreen()
        {
            InitializeComponent();
        }
        private void DisplayMessage(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Clicked.");
            this.Hide();
        }
        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new HomePage());
        }
        private void CoffeeButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new CoffeePage());
        }
        private void SnacksButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new SnacksPage());
        }
        private void SandwichButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new SandwichPage());
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


    }
}
