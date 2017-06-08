using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqliteDB.Model
{
    public class AccountModel
    {
        //----------------Singleton-----------------
        //private static AccountModel instance;

        //private AccountModel() { }

        //public static AccountModel Instance
        //{
        //    get
        //    {
        //        if(instance == null)
        //        {
        //            instance = new AccountModel();
        //        }
        //        return instance;
        //    }
        //}
        //---------------------------------------
        //TEST GITHUB
        //RESEND

        public string AccountID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string DisplayName { get; set; }
        public string Roles { get; set; }
    }
}
