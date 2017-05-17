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
        public static SQLiteConnection dbCon;

        public static void dbCreate()
        {
            SQLiteConnection.CreateFile("MyDatabaseSQLITE.sqlite");
        }
        
        public static void dbConnection()
        {
            
            dbCon = new SQLiteConnection("Data Source=MyDatabaseSQLITE.sqlite;Version=3;");
            dbCon.Open();
        }

        public static void dbCreateTable()
        {
            string sql = "CREATE TABLE highscores (name VARCHAR(20), score INT)";
            SQLiteCommand command = new SQLiteCommand(sql, dbCon);
            command.ExecuteNonQuery();
        }

    }
}
