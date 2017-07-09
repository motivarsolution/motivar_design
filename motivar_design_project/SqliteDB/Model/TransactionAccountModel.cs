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

        public AccountModel TransactionAccount { get; set; }

        public string Index { get; set; }

        public string Type { get; set; }

    }
}
