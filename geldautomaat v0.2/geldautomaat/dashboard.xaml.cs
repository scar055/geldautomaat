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

namespace geldautomaat
{
    /// <summary>
    /// Interaction logic for dashboard.xaml
    /// </summary>
    public partial class dashboard : Window
    {
        bankAccounts accounts = new bankAccounts();
        transactions transaction = new transactions();
        SQL sql = new SQL();

        int idAccount;
        public dashboard(Int32 id)
        {
            InitializeComponent();

            accounts.read(id);
            lblSaldo.Content = accounts.saldo;
            idAccount = id;
            dgTransactions.DataContext = transaction.getTransactions(accounts.number);
        }

        private void btnTakeMoney_Click(object sender, RoutedEventArgs e)
        {
            if (accounts.saldo <= 0)
            {
                MessageBox.Show("Je saldo is te laag om te pinnen");
            }
            else
            {
                if (transaction.checkTransactions(accounts.number) == true)
                {
                    AddMoneyInAccount window = new AddMoneyInAccount(idAccount, accounts.saldo, false);
                    window.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Je hebt vandaag al 3 keer gepinned");
                }
            }
        }

        private void btnGiveMoney_Click(object sender, RoutedEventArgs e)
        {
            AddMoneyInAccount window = new AddMoneyInAccount(idAccount, accounts.saldo, true);
            window.Show();
            this.Close();
        }
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            window.Show();
            this.Close();
        }
    }  
}