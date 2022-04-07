using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ClassLibrary
{
    public class transactions
    {
        private int _id;
        private double _amount;
        private string _date;

        public int id
        {
            get { return _id; }
            set { _id = value; }

        }
        public double amount
        {
            get { return _amount; }
            set { _amount = value; }
        }
        public string date
        {
            get { return _date; }
            set { _date = value; }
        }
        SQL sql = new SQL();
        public DataSet getdata(int bank_account)
        {
            string SQL = $"SELECT id, amount, date FROM transactions WHERE bank_account ={bank_account}";
            return sql.getDataSet(SQL);
        }
        public void create(int bankaccount, Double amount)
        {
            string SQL = string.Format("INSERT INTO geldautomaat.transactions (bank_account, amount) VALUE('{0}', '{1}')", bankaccount, amount.ToString().Replace(",", "."));
            sql.ExecuteNonQuery(SQL);
        }
        public void read(Int32 id)
        {
            string SQL = string.Format("SELECT id, amount, date FROM geldautomaat.transactions WHERE id = {0}", id);
            DataTable dataTable = sql.getDataTable(SQL);
            _id = Convert.ToInt32(dataTable.Rows[0]["id"].ToString());
            _amount = Convert.ToInt32(dataTable.Rows[0]["amount"].ToString());
            _date = dataTable.Rows[0]["date"].ToString();
        }
        public void update(Int32 transactionNr, Double amount)
        {
            string SQL = string.Format("UPDATE geldautomaat.transactions " +
                                        "SET `amount`   ='{0}' " +
                                        "WHERE `id`     ={3}", amount,
                                                               transactionNr);
            sql.ExecuteNonQuery(SQL);
        }
        public bool delete(Int32 transactionNr)
        {
            bool isDeleted = false;
            if (MessageBox.Show("Moet ik gegevens verwijderen?", "Vraag", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                string SQL = string.Format("DELETE FROM geldautomaat.transactions WHERE id = {0};", transactionNr);
                sql.ExecuteNonQuery(SQL);
                isDeleted = true;
            }
            return isDeleted;
        }
        public DataSet getTransactions(int bankaccount)
        {
            string SQL = string.Format("SELECT * FROM `transactions` WHERE bank_account = '{0}' ORDER BY date DESC LIMIT 3", bankaccount);
            return sql.getDataSet(SQL);
        }

        public bool checkTransactions(Int32 bankaccount)
        {
            string SQL = string.Format("SELECT COUNT(*) FROM `transactions` WHERE `bank_account` = {0} AND amount < 0 AND DAY(date) = DAY(now()) AND  MONTH(date) = MONTH(now())  AND YEAR(date) = YEAR(now());", bankaccount);
            DataTable dataTable = sql.getDataTable(SQL);
            int count = Convert.ToInt32(dataTable.Rows[0]["COUNT(*)"].ToString());
            
            if (count < 3)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
