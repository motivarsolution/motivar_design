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

        public string IndexLine { get; set; }

        public string Type { get; set; }

        public string AccountID { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string DisplayName { get; set; }

        public string Roles { get; set; }

        public string Status { get; set; }

        public string CreatedBy { get; set; }

        public string ChangedBy { get; set; }

        public string CreatedDateTime { get; set; }

        public string ChangedDateTime { get; set; }


    }
}
