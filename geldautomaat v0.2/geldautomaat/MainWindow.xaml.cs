using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace geldautomaat
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        loginRegistration login = new loginRegistration();
        bankAccounts accounts = new bankAccounts();
        int maximumTries;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void logIn(object sender, RoutedEventArgs e)
        {
            try
            {
                bool check = accounts.loginAccount(Convert.ToInt32(txbNumber.Text), pwbPin.Password);
                accounts.checkLogin(Convert.ToInt32(txbNumber.Text), pwbPin.Password);

                if (accounts.blocked == false)
                {
                    if (check == true)
                    {
                        dashboard window = new dashboard(accounts.id);
                        window.Show();
                        this.Close();
                    }
                    else
                    {
                        if (maximumTries == 3)
                        {
                            accounts.accountBlocked(Convert.ToInt32(txbNumber.Text), true);
                            MessageBox.Show("bank rekening is geblokkeerd");
                            maximumTries = 0;
                        }
                        else
                        {
                            maximumTries++;
                            MessageBox.Show("wachtwoord of username fout je hebt nog " + maximumTries + " kansen van de 3");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("deze rekening is geblokkeerd");
                }
            }
            catch (Exception)
            {

                MessageBox.Show("rekening bestaat niet");
            }

        }
    }
}