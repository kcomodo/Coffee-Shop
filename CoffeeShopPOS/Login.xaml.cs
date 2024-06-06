using POS_Repository;
using System.Runtime.InteropServices;
using System.Security;
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

    public partial class Login : Window
    {
        public static string email;
        public static string password;
        string defaultEmail = "Email@address.com";
 

        public Login()
        {
            InitializeComponent();
            EmailTxt.Text = defaultEmail;
            EmailTxt.Foreground = Brushes.Gray;
            //PasswordTxt.Password = defaultPassword;
            PasswordTxt.Foreground = Brushes.Gray;

        }
        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            email = EmailTxt.Text;
            password = PasswordTxt.Password;
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
        private void EmailTxt_GotFocus(object sender, RoutedEventArgs e)
        {
            if (EmailTxt.Text == "Email@address.com")
            {
                EmailTxt.Text = "";
            }
        }

        private void EmailTxt_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(EmailTxt.Text))
            {
                EmailTxt.Text = "Email@address.com";
            }
        }
        private void PasswordTxt_PasswordChanged(object sender, RoutedEventArgs e)
        {
          
            PlaceholderTxt.Visibility = string.IsNullOrWhiteSpace(PasswordTxt.Password) ? Visibility.Visible : Visibility.Collapsed;
        }

        private void PlaceholderTxt_GotFocus(object sender, RoutedEventArgs e)
        {
         
            PlaceholderTxt.Visibility = Visibility.Collapsed;
            PasswordTxt.Focus();
        }

        private void PlaceholderTxt_LostFocus(object sender, RoutedEventArgs e)
        {
   
            if (string.IsNullOrWhiteSpace(PasswordTxt.Password))
            {
                PlaceholderTxt.Visibility = Visibility.Visible;
            }
        }
 

    }
}