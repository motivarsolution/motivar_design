using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqliteDB.Model
{
    public static class dbconnect
    {
        public static void dbCreate()
        {
            SQLiteConnection.CreateFile("MyDatabaseSQLITE.sqlite");
        }
    }
}
