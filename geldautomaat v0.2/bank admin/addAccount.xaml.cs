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
    /// Interaction logic for addAccount.xaml
    /// </summary>
    public partial class addAccount : Window
    {
        bankAccounts bankaccounts = new bankAccounts();
        int idUser;
        public addAccount(Int32 userId)
        {
            InitializeComponent();

            idUser = userId;

            btnaddBankAccount.Click += addBankAccount_Click;
        }
        public addAccount(Int32 userId , bool edit)
        {
            InitializeComponent();
            bankaccounts.read(userId);

            idUser = userId;

            btnaddBankAccount.Content = "verander rekening";
            btnaddBankAccount.Click += editBankAccount_Click;
            cbBlocked.SelectedIndex = Convert.ToInt32(bankaccounts.blocked);

            txbBankAccountNumber.Text = bankaccounts.number.ToString();
        }
        private void editBankAccount_Click(object sender, RoutedEventArgs e)
        {
            bankaccounts.update(idUser, Convert.ToInt32(txbBankAccountNumber.Text), cbBlocked.SelectedIndex.ToString());

            userBankAccounts userBankAccounts = new userBankAccounts(idUser);
            userBankAccounts.Show();
            this.Close();
        }

        private void addBankAccount_Click(object sender, RoutedEventArgs e)
        {
            bankaccounts.create(idUser, Convert.ToInt32(txbBankAccountNumber.Text), 0, bankaccounts.randomPin(),cbBlocked.SelectedIndex.ToString());

            userBankAccounts userBankAccounts = new userBankAccounts(idUser);
            userBankAccounts.Show();
            this.Close();
        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            AllAccounts allAccounts = new AllAccounts();
            allAccounts.Show();
            this.Close();
        }
    }
}
