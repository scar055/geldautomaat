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
    /// Interaction logic for addUser.xaml
    /// </summary>
    public partial class addUser : Window
    {
        user user = new user();
        int userId;
        public addUser()
        {
            InitializeComponent();

            btnAddUser.Click += btnAddUser_Click;
        }

        public addUser(Int32 id)
        {
            InitializeComponent();

            userId = id;

            btnAddUser.Content = "edit user";
            user.read(id);

            txbFirstname.Text = user.firstname;
            txbLastname.Text = user.lastname;
            txbEmail.Text = user.email;
            txbHomeAdress.Text = user.home_adress;
            txbPostcode.Text = user.postcode;
            txbWoonplaats.Text = user.woonplaats;

            btnAddUser.Click += btnEditUser_Click;

        }
        private void btnEditUser_Click(object sender, RoutedEventArgs e)
        {
            user.update(userId, txbFirstname.Text, txbLastname.Text, txbEmail.Text, txbHomeAdress.Text, txbPostcode.Text, txbWoonplaats.Text);

            bankUsers window = new bankUsers();
            window.Show();
            this.Close();
        }

        private void btnAddUser_Click(object sender, RoutedEventArgs e)
        {
            user.create(txbFirstname.Text, txbLastname.Text, txbEmail.Text, txbHomeAdress.Text, txbPostcode.Text, txbWoonplaats.Text);
            
            bankUsers window = new bankUsers();
            window.Show();
            this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            bankUsers window = new bankUsers();
            window.Show();
            this.Close();
        }
    }
}
