using POS_Folders.Models;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CoffeeShopPOS
{
    /// <summary>
    /// Interaction logic for CoffeePage.xaml
    /// </summary>
    public partial class CoffeePage : Page
    {
        ItemModel ItemModel;
        public CoffeePage(ItemModel IM)
        {
            InitializeComponent();
            this.ItemModel = IM;
        }
        public void buttonClicked(object sender, RoutedEventArgs e)
        {
            MainScreen mainScreen = new MainScreen();
            mainScreen.AddToCart("Coffee", 2.50m, 2);
           
        }

    }
}
