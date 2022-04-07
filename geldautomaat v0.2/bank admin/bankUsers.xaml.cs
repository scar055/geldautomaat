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
    public partial class bankUsers : Window
    {
        user user = new user();
        public bankUsers()
        {
            InitializeComponent();

            dgBankaccounts.DataContext = user.getdata();
        }
        private void register(object sender, RoutedEventArgs e)
        {
            register window = new register();
            window.Show();
            this.Close();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                object item = dgBankaccounts.SelectedItem;
                int userNumber = int.Parse((dgBankaccounts.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text);
                if (user.delete(userNumber) == true)
                {
                    dgBankaccounts.DataContext = user.getdata();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void btnLogOut_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            window.Show();
            this.Close();
        }

        private void add_user_Click(object sender, RoutedEventArgs e)
        {
            addUser addUser = new addUser();
            addUser.Show();
            this.Close();
        }

        private void btnAddAccount_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                object item = dgBankaccounts.SelectedItem;
                int user_id = int.Parse((dgBankaccounts.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text);

                userBankAccounts bankaccounts = new userBankAccounts(user_id);
                bankaccounts.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void btnUserEdit_Click(object sender, RoutedEventArgs e)
        {
            object item = dgBankaccounts.SelectedItem;
            int user_id = int.Parse((dgBankaccounts.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text);

            addUser addUser = new addUser(user_id);
            addUser.Show();
            this.Close();
        }

        private void btnSearchUser_Click(object sender, RoutedEventArgs e)
        {
            if (txbSearch.Text == string.Empty && txbSearchAdress.Text == string.Empty)
            {
                dgBankaccounts.DataContext = user.getdata();
            }
            else
            {
                dgBankaccounts.DataContext = user.getdata(txbSearch.Text, txbSearchAdress.Text);
            }
        }

        private void btnShowAllAccounts_Click(object sender, RoutedEventArgs e)
        {
            AllAccounts window = new AllAccounts();
            window.Show();
            this.Close();
        }
    }
}