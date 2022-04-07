using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ClassLibrary
{
    public class loginRegistration
    {
        employee employee = new employee();
        bankAccounts accounts = new bankAccounts();

        public void registration(string username, string password)
        {
            string passwordhash = password;
            employee.create(username, hash.getHashSha256(passwordhash));
        }
        public bool loginBankAdmin(string username, string password)
        {
            employee.read(username, password);
            if (username == employee.username)
            {
                if (password == employee.password)
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
    }
}
