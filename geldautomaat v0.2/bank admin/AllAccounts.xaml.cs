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
using ClassLibrary;

namespace bank_admin
{
    /// <summary>
    /// Interaction logic for AllAccounts.xaml
    /// </summary>
    public partial class AllAccounts : Window
    {
        bankAccounts bankaccounts = new bankAccounts();
        public AllAccounts()
        {
            InitializeComponent();

            dgUserBankAccounts.DataContext = bankaccounts.getAllAccounts();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            bankUsers bankusers = new bankUsers();
            bankusers.Show();
            this.Close();
        }

        private void btnSortAccounts_Click(object sender, RoutedEventArgs e)
        {
            if (txbSort.Text == string.Empty)
            {
                dgUserBankAccounts.DataContext = bankaccounts.getAllAccounts();
            }
            else
            {
                dgUserBankAccounts.DataContext = bankaccounts.getAllAccounts(txbSort.Text);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                object item = dgUserBankAccounts.SelectedItem;
                int userNumber = int.Parse((dgUserBankAccounts.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text);
                if (bankaccounts.delete(userNumber) == true)
                {
                    dgUserBankAccounts.DataContext = bankaccounts.getAllAccounts();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            object item = dgUserBankAccounts.SelectedItem;
            int bankAccount_id = int.Parse((dgUserBankAccounts.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text);

            addAccount addUser = new addAccount(bankAccount_id, true);
            addUser.Show();
            this.Close();
        }
    }
}
