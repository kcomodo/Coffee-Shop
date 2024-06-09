using POS_Folders.Repository;
using POS_Folders.Services;
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
            EmailTxt.Foreground = Brushes.Black;
            //PasswordTxt.Password = defaultPassword;
            PasswordTxt.Foreground = Brushes.Black;

        }
        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            email = EmailTxt.Text;
            password = PasswordTxt.Password;
            //Create an object for employee repository and services
            //EmployeeServices needs an object of IEmployeeRepository
            //Now use the interface in IEmployeeService to check the login
            IEmployeeRepository employeeRepository = new EmployeeRepository();
            IEmployeeServices employeeServices = new EmployeeServices(employeeRepository);
            bool login = employeeServices.validateEmployeeLogin(email, password);
            if (login)
            {
                MessageBox.Show("Login Successful");
                this.Hide();
                MainScreen mainscreen = new MainScreen();
                mainscreen.Show();
            }
            else
            {
                MessageBox.Show("Login Failed");
            }
        }
        private void RegisterBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            RegisterScreen register = new RegisterScreen();
            register.Show();
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