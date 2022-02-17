using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.Models;

namespace Tests.Service
{
    public static class AccountCreator
    {
        public static string loginAccount = "0205danik@gmail.com";
        public static string passwordAccount = "w9*8cnf+#JH!sKi";

        public static Account CreateAccount()
        {
            return new Account(loginAccount, passwordAccount);
        }
    }
}
