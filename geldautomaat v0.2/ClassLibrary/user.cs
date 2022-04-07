using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ClassLibrary
{
    public class user
    {
        private int _id;
        private string _firstname;
        private string _lastname;
        private string _email;
        private string _homeAdress;
        private string _postcode;
        private string _woonplaats;
        private string _date;

        public int id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string firstname
        {
            get { return _firstname; }
            set { _firstname = value; }
        }
        public string lastname
        {
            get { return _lastname; }
            set { _lastname = value; }
        }
        public string email
        {
            get { return _email; }
            set { _email = value; }
        }
        public string home_adress
        {
            get { return _homeAdress; }
            set { _homeAdress = value; }
        }
        public string postcode
        {
            get { return _postcode; }
            set { _postcode = value; }
        }
        public string woonplaats
        {
            get { return _woonplaats; }
            set { _woonplaats = value; }
        }
        public string date
        {
            get { return _date; }
            set { _date = value; }
        }
        SQL sql = new SQL();
        public DataSet getdata(string username = null, string adress = null)
        {
            if (username == null)
            {
                string SQL = "SELECT id, firstname, lastname, email, home_adress, postcode, woonplaats, date FROM user";
                return sql.getDataSet(SQL);
            }
            else
            {
                string SQL = $"SELECT `id`, `firstname`, `lastname`, `email`, `home_adress`, `postcode`, `woonplaats`, `date`  FROM user WHERE (`firstname` = '{username}' OR `lastname` = '{username}' OR `home_adress` LIKE '%{adress}%')";
                return sql.getDataSet(SQL);
            }
            
        }
        public void create(string firstname, string lastname, string email, string homeAdress, string postcode, string woonplaats)
        {
            string SQL = string.Format("INSERT INTO geldautomaat.user (firstname, lastname, email, home_adress, postcode, woonplaats) VALUE('{0}', '{1}', '{2}', '{3}', '{4}', '{5}')", firstname, lastname, email, homeAdress, postcode, woonplaats);
            sql.ExecuteNonQuery(SQL);
        }
        public void read(Int32 id)
        {
            string SQL = string.Format("SELECT id, firstname, lastname, email, home_adress, postcode, woonplaats, date FROM geldautomaat.user WHERE id = {0}", id);
            DataTable dataTable = sql.getDataTable(SQL);
            _id = Convert.ToInt32(dataTable.Rows[0]["id"].ToString());
            _firstname = dataTable.Rows[0]["firstname"].ToString();
            _lastname = dataTable.Rows[0]["lastname"].ToString();
            _email = dataTable.Rows[0]["email"].ToString();
            _homeAdress = dataTable.Rows[0]["home_adress"].ToString();
            _postcode = dataTable.Rows[0]["postcode"].ToString();
            _woonplaats = dataTable.Rows[0]["woonplaats"].ToString();
            _date = dataTable.Rows[0]["date"].ToString();
        }
        public void update(Int32 userNr, string firstname, string lastname, string email, string homeAdress, string poscode, string woonplaats)
        {
            string SQL = string.Format("UPDATE geldautomaat.user " +
                                        "SET `firstname`  ='{0}', " +
                                        "`lastname`       ='{1}', " +
                                        "`email`          ='{2}', " +
                                        "`home_adress`    ='{3}' " +
                                        "`postcode`       ='{4}' " +
                                        "`woonplaats`     ='{5}' " +
                                        "WHERE `id`       = {6}", firstname,
                                                                 lastname,
                                                                 email,
                                                                 homeAdress,
                                                                 postcode,
                                                                 woonplaats,
                                                                 userNr);
            sql.ExecuteNonQuery(SQL);
        }
        public bool delete(Int32 userNr)
        {
            bool isDeleted = false;
            if (MessageBox.Show("Moet ik gegevens verwijderen?", "Vraag", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                string SQL = string.Format("DELETE FROM geldautomaat.user WHERE id = {0};", userNr);
                sql.ExecuteNonQuery(SQL);
                isDeleted = true;
            }
            return isDeleted;
        }
    }
}
