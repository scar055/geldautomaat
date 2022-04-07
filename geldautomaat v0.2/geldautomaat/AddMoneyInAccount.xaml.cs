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
using System.Windows.Shapes;
using ClassLibrary;

namespace geldautomaat
{
    /// <summary>
    /// Interaction logic for AddMoneyInAccount.xaml
    /// </summary>
    public partial class AddMoneyInAccount : Window
    {
        bankAccounts accounts = new bankAccounts();
        transactions transaction = new transactions();
        int idAccount;
        double saldoAccount;
        public AddMoneyInAccount(Int32 id, double saldo, bool WithdrawOradd)
        {
            InitializeComponent();
           
            idAccount = id;
            saldoAccount = saldo;

            btnCancel.Click += btnCancel_Click;
            
            if (WithdrawOradd == true)
            {
                btnAddMoney.Click += btnAddMoney_Click;
            }
            else
            {
                btnAddMoney.Click += btnWithdrawMoney_Click;
                btnAddMoney.Content = "Neem geld op";
            }

        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            dashboard window = new dashboard(idAccount);
            window.Show();
            this.Close();
        }
        private void btnWithdrawMoney_Click(object sender, RoutedEventArgs e)
        {
            accounts.read(idAccount);
            double addSaldo;
            double inputSaldo = Convert.ToDouble(txbSaldo.Text);

            if (inputSaldo > saldoAccount)
            {
                MessageBox.Show("wat je wilt pinnen is te hoog");
            }
            else
            {
                if (inputSaldo == 0)
                {
                    MessageBox.Show("geef aub een geldig bedrag op");
                }
                else { 
                    if (inputSaldo > 500)
                    {
                        MessageBox.Show("bedrag mag niet groter dan 500");
                    }
                    else
                    {

                        if (inputSaldo % 5 == 0)
                        {
                            addSaldo = saldoAccount - inputSaldo;
                            accounts.changeSaldo(idAccount, addSaldo);

                            inputSaldo = -inputSaldo;
                            transaction.create(accounts.number, inputSaldo);

                            MainWindow window = new MainWindow();
                            window.Show();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Het bedrag dat u wilt pinnen moet een veelvoud van 5 zijn (5, 10, 15, 20 etc)");
                            txbSaldo.Text = "0";
                        }
                    }
                }
            }
        }

        private void btnAddMoney_Click(object sender, RoutedEventArgs e)
        {
            accounts.read(idAccount);
            double addSaldo;
            double inputSaldo = Convert.ToDouble(txbSaldo.Text);

            addSaldo = inputSaldo + saldoAccount;

            accounts.changeSaldo(idAccount, addSaldo);
            transaction.create(accounts.number, inputSaldo);

            MainWindow window = new MainWindow();
            window.Show();
            this.Close();
        }

        private void TxbSaldo(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
        }
        private static readonly Regex _regex = new Regex("[^0-9.]+"); //regex that matches disallowed text
        private static bool IsTextAllowed(string text)
        {
            return !_regex.IsMatch(text);
        }
    }
}
