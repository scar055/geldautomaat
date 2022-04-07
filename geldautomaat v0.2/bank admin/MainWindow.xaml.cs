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
using ClassLibrary;

namespace bank_admin
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        loginRegistration login = new loginRegistration();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void logIn(object sender, RoutedEventArgs e)
        {
            bool check = login.loginBankAdmin(txbUsername.Text, hash.getHashSha256(pwbPassword.Password));
            if (check == true)
            {
                bankUsers window = new bankUsers();
                window.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("wachtwoord of username fout");
            }
        }
    }
}
