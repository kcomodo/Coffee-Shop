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
using POS_Folders.Repository;
namespace CoffeeShopPOS
{
    /// <summary>
    /// Interaction logic for RegisterScreen.xaml
    /// </summary>
    public partial class RegisterScreen : Window
    {
        string defaultFirst = "First Name";
        string defaultLast = "Last Name";
        string defaultEmail = "Email@address.com";
        public RegisterScreen()
        {
            InitializeComponent();
            
            FirstNameTxt.Text = defaultFirst;
            LastNameTxt.Text = defaultLast;
            EmailTxt.Text = defaultEmail;
            
        }
        private void FirstName_GotFocus(object sender, RoutedEventArgs e)
        {
            if (FirstNameTxt.Text == defaultFirst)
            {
                FirstNameTxt.Text = "";
            }
        }
        private void FirstName_LostFocus(object sender, RoutedEventArgs e)
        {
            if (FirstNameTxt.Text == "")
            {
                FirstNameTxt.Text = defaultFirst;
            }
        }
        private void LastName_GotFocus(object sender, RoutedEventArgs e)
        {
            if (LastNameTxt.Text == defaultLast)
            {
                LastNameTxt.Text = "";
            }
        }
        private void LastName_LostFocus(object sender, RoutedEventArgs e)
        {
            if (LastNameTxt.Text == "")
            {
                LastNameTxt.Text = defaultLast;
            }
        }
        private void Email_GotFocus(object sender, RoutedEventArgs e)
        {
            if (EmailTxt.Text == defaultEmail)
            {
                EmailTxt.Text = "";
            }
        }
        private void Email_LostFocus(object sender, RoutedEventArgs e)
        {
            if (EmailTxt.Text == "")
            {
                EmailTxt.Text = defaultEmail;
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

        private void PasswordTxt_PasswordChanged2(object sender, RoutedEventArgs e)
        {

            PlaceholderTxt2.Visibility = string.IsNullOrWhiteSpace(ConfirmPasswordTxt.Password) ? Visibility.Visible : Visibility.Collapsed;
        }

        private void PlaceholderTxt_GotFocus2(object sender, RoutedEventArgs e)
        {

            PlaceholderTxt2.Visibility = Visibility.Collapsed;
            ConfirmPasswordTxt.Focus();
        }

        private void PlaceholderTxt_LostFocus2(object sender, RoutedEventArgs e)
        {

            if (string.IsNullOrWhiteSpace(ConfirmPasswordTxt.Password))
            {
                PlaceholderTxt2.Visibility = Visibility.Visible;
            }
        }
        private void registerAccountBtn_Click(object sender, RoutedEventArgs e)
        {
            IEmployeeRepository employeeRepository = new EmployeeRepository();
            string firstName = FirstNameTxt.Text;
            string lastName = LastNameTxt.Text;
            string email = EmailTxt.Text;
            //change textbox to passwordbox
            string password = PasswordTxt.Password;
            string confirmPassword = ConfirmPasswordTxt.Password;
            if (password == confirmPassword)
            {
                employeeRepository.addEmployee(firstName, lastName, email, password);
                this.Hide();
                Login login = new Login();
                login.Show();
            }
            else
            {
                MessageBox.Show("Passwords do not match");
            }
        }
    }
}
