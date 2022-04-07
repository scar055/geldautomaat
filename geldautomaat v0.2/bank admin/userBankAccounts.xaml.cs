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
    /// Interaction logic for bankAccounts.xaml
    /// </summary>
    public partial class userBankAccounts : Window
    {
        bankAccounts bankaccounts = new bankAccounts();
        int userId;
        public userBankAccounts(Int32 User_id)
        {
            InitializeComponent();

            userId = User_id;

            dgUserBankAccounts.DataContext = bankaccounts.getdata(userId);
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                object item = dgUserBankAccounts.SelectedItem;
                int userNumber = int.Parse((dgUserBankAccounts.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text);
                if (bankaccounts.delete(userNumber) == true)
                {
                    dgUserBankAccounts.DataContext = bankaccounts.getdata(userId);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void btnAddAccount_Click(object sender, RoutedEventArgs e)
        {
            addAccount addaccount = new addAccount(userId);
            addaccount.Show();
            this.Close();
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
                dgUserBankAccounts.DataContext = bankaccounts.getdata(userId);
            }
            else
            {
                dgUserBankAccounts.DataContext = bankaccounts.getdata(userId, txbSort.Text);
            }
        }
    }
}
