using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqliteDB.Model;
using SqliteDB.Utility;
using System.Diagnostics;

namespace SqliteDB.Controller
{
    public static class DatabaseVersionCheck
    {
        private static SQLiteCommand sql_cmd;
        private static DatabaseVersionModel DatabaseVersion = new DatabaseVersionModel();

        public static void QueryDatabaseVersion() //Not Acc because should doing transaction
        {
            DatabaseConnection.SetConnection();
            DatabaseConnection.sql_con.Open();
            sql_cmd = DatabaseConnection.sql_con.CreateCommand();
            string CommandText = "SELECT * " +
                                 "FROM DatabaseVersion";

            using (SQLiteCommand cmd = new SQLiteCommand(CommandText, DatabaseConnection.sql_con))
            {
                using (SQLiteDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        DatabaseVersion.Version = double.Parse(rdr["Version"].ToString());

                        DatabaseVersion.CreatedBy = rdr["CreatedBy"].ToString();
                    }
                }
            }

            DatabaseConnection.sql_con.Close();
        }

        public static bool Checked()
        {
            QueryDatabaseVersion();

            if (DatabaseVersion.Version == GlobalConstant.DB_VERSION)
            {
                Debug.WriteLine("-----------------------------------------------");
                Debug.WriteLine("   Database Version ===> " + DatabaseVersion.Version);
                Debug.WriteLine("   Database CreatedBy ===> " + DatabaseVersion.CreatedBy);
                Debug.WriteLine("-----------------------------------------------");
                return true;
            }
            else
            {
                Debug.WriteLine(" Database Error! Please Update Database to latest version ");
                return false;
            }
        }

    }
}
