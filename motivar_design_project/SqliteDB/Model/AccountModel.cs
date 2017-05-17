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
        private static AccountModel instance;

        private AccountModel() { }

        public static AccountModel Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new AccountModel();
                }
                return instance;
            }
        }
        //---------------------------------------
    }
}
