using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ClassLibrary
{
    public class employee
    {
        private int _id;
        private string _username;
        private string _password;
        private string _date;

        public int id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string username
        {
            get { return _username; }
            set { _username = value; }
        }
        public string password
        {
            get { return _password; }
            set { _password = value; }
        }
        public string date
        {
            get { return _date; }
            set { _date = value; }
        }

        SQL sql = new SQL();
        public DataSet getdata()
        {
            string SQL = "SELECT id, username, password, date FROM employee";
            return sql.getDataSet(SQL);
        }
        public void create(string username, string password)
        {
            string SQL = string.Format("INSERT INTO geldautomaat.employee (username, password) VALUE('{0}', '{1}')", username, password);
            sql.ExecuteNonQuery(SQL);
        }
        public void read(string username, string password)
        {
            string SQL = string.Format("SELECT id, username, password, date FROM geldautomaat.employee WHERE username = '{0}' and '{1}'", username, password);
            DataTable dataTable = sql.getDataTable(SQL);
            _id = Convert.ToInt32(dataTable.Rows[0]["id"].ToString());
            _username = dataTable.Rows[0]["username"].ToString();
            _password = dataTable.Rows[0]["password"].ToString();
            _date = dataTable.Rows[0]["date"].ToString();
        }
        public void update(Int32 employeeNr, string username, string password)
        {
            string SQL = string.Format("UPDATE geldautomaat.employee " +
                                        "SET `username`   ='{0}' " +
                                        "`password`       ='{1}' " +
                                        "WHERE `id`       ={2}", username,
                                                                 password,
                                                                 employeeNr);
            sql.ExecuteNonQuery(SQL);
        }
        public bool delete(Int32 employeeNr)
        {
            bool isDeleted = false;
            if (MessageBox.Show("Moet ik gegevens verwijderen?", "Vraag", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                string SQL = string.Format("DELETE FROM geldautomaat.employee WHERE id = {0};", employeeNr);
                sql.ExecuteNonQuery(SQL);
                isDeleted = true;
            }
            return isDeleted;
        }

    }
}
