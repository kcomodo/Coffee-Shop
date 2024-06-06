using POS_Repository;
using System.Text;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }
        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            string email = UserNameTxt.Text;
            string password = PasswordTxt.Text;
            Class1 class1 = new Class1();
            bool login = class1.validateEmployeeLogin(email, password);
            if (login)
            {
                MessageBox.Show("Login Successful");
                this.Hide();
                Window1 window1 = new Window1();
                window1.Show();
            }
            else
            {
                MessageBox.Show("Login Failed");
            }


        }
    }
}