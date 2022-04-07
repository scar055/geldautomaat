using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ClassLibrary
{
    public class bankAccounts
    {
        private int _id;
        private int _number;
        private double _saldo;
        private string _pin;
        private string _date;
        private bool _blocked;

        public int id
        {
            get { return _id; }
            set { _id = value; }
        }
        public int number
        {
            get { return _number; }
            set { _number = value; }
        }
        public double saldo
        {
            get { return _saldo; }
            set { _saldo = value; }
        }
        public string pin
        {
            get { return _pin; }
            set { _pin = value; }
        }
        public string date
        {
            get { return _date; }
            set { _date = value; }
        }
        public bool blocked
        {
            get { return _blocked; }
            set { _blocked = value; }
        }
        SQL sql = new SQL();

        public DataSet getdata(int id_user, string account = null)
        {
            if (account == null)
            {
                string SQL = $"SELECT id, number, saldo, pin, date, blocked FROM bank_accounts WHERE id_user = {id_user}";
                return sql.getDataSet(SQL);
            }
            else
            {
                string SQL = $"SELECT id, number, saldo, pin, date, blocked FROM bank_accounts WHERE (`id_user` = '{id_user}' AND `number` = '{account}')";
                return sql.getDataSet(SQL);
            }
        }
        public DataSet getAllAccounts(string account = null)
        {
            if (account == null)
            {
                string SQL = $"SELECT id, number, saldo, pin, date, blocked FROM bank_accounts";
                return sql.getDataSet(SQL);
            }
            else
            {
                string SQL = $"SELECT id, number, saldo, pin, date, blocked FROM bank_accounts WHERE (`number` = '{account}')";
                return sql.getDataSet(SQL);
            }
        }
        public void create(Int32 id_user, Int32 number, double saldo, Int32 pin, string blocked)
        {
            string SQL = string.Format("INSERT INTO geldautomaat.bank_accounts (id_user, number, saldo, pin, blocked) VALUE('{0}', '{1}', '{2}', '{3}', '{4}')",
               id_user, number, saldo, pin, blocked);
            sql.ExecuteNonQuery(SQL);
        }
        public void read(Int32 id)
        {
            string SQL = string.Format("SELECT id, number, saldo, pin, date, blocked FROM geldautomaat.bank_accounts WHERE id = '{0}'", id);
            DataTable dataTable = sql.getDataTable(SQL);
            _id = Convert.ToInt32(dataTable.Rows[0]["id"].ToString());
            _number = Convert.ToInt32(dataTable.Rows[0]["number"].ToString());
            _saldo = Convert.ToDouble(dataTable.Rows[0]["saldo"].ToString());
            _pin = dataTable.Rows[0]["pin"].ToString();
            _date = dataTable.Rows[0]["date"].ToString();
            _blocked = Convert.ToBoolean(dataTable.Rows[0]["blocked"].ToString());
        }
        public void checkLogin(Int32 number, string pin)
        {
            string SQL = string.Format("SELECT id, number, saldo, pin, date, blocked FROM geldautomaat.bank_accounts WHERE number = '{0}' AND '{1}'", number, pin);
            DataTable dataTable = sql.getDataTable(SQL);
            _id = Convert.ToInt32(dataTable.Rows[0]["id"].ToString());
            _number = Convert.ToInt32(dataTable.Rows[0]["number"].ToString());
            _pin = dataTable.Rows[0]["pin"].ToString();
            _blocked = Convert.ToBoolean(dataTable.Rows[0]["blocked"].ToString());
        }
        public void update(Int32 accountNr, Int32 number , string blocked)
        {
            string SQL = string.Format("UPDATE geldautomaat.bank_accounts " +
                                        "SET `number`  ='{0}' " +
                                        "`blocked`    ='{1}', " +
                                        "WHERE `id`   ={2}", number,
                                                             blocked,
                                                             accountNr);
            sql.ExecuteNonQuery(SQL);
        }
        public void changeSaldo(Int32 id, double saldo)
        {
            string SQL = string.Format("UPDATE geldautomaat.bank_accounts " +
                                        "SET saldo = {0} " +
                                        "WHERE id   =  {1}", saldo.ToString().Replace(",","."),
                                                               id);
            sql.ExecuteNonQuery(SQL);
        }
        public bool delete(Int32 accountNr)
        {
            bool isDeleted = false;
            if (MessageBox.Show("Moet ik gegevens verwijderen?", "Vraag", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                string SQL = string.Format("DELETE FROM geldautomaat.bank_accounts WHERE id = {0};", accountNr);
                sql.ExecuteNonQuery(SQL);
                isDeleted = true;
            }
            return isDeleted;
        }
        public void accountBlocked(Int32 number, bool blocked)
        {
            string SQL = string.Format("UPDATE geldautomaat.bank_accounts " +
                                        "SET `blocked`  =  {0} " +
                                        "WHERE `number`   ={1}", blocked,
                                                                 number);
            sql.ExecuteNonQuery(SQL);
        }
        public int randomPin()
        {
            Random random = new Random();
            int number = random.Next(1000, 9999);
            return number;
        }
        public bool loginAccount(int accountNumber, string pin)
        {
            checkLogin(accountNumber, pin);
            if (_blocked == false)
            {
                if (accountNumber == _number)
                {
                    if (pin == _pin)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
