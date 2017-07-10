using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqliteDB.Model
{
    public class TransactionAccountModel
    {
        public string TransactionID { get; set; }

        public string Index { get; set; }

        public string Type { get; set; }

        public string AccountID { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string DisplayName { get; set; }

        public string Roles { get; set; }


    }
}
