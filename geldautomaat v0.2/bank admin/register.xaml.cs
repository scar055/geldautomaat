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
using ClassLibrary;

namespace bank_admin
{
    /// <summary>
    /// Interaction logic for register.xaml
    /// </summary>
    public partial class register : Window
    {
        loginRegistration registration = new loginRegistration();
        public register()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            if (txbRegisterPassword.Password == txbRepeatPassword.Password)
            {
               registration.registration(txbUsernameRegister.Text, txbRegisterPassword.Password);

                bankUsers window = new bankUsers();
                window.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Password is repeated wrong");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bankUsers window = new bankUsers();
            window.Show();
            this.Close();
        }
    }
}
