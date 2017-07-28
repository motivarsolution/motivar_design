using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqliteDB.Model;

namespace SqliteDB.Controller
{
    public static class StoreTransactionAccount
    {
        private static SQLiteCommand sql_cmd;
        public static List<TransactionAccountModel> tsAccountList = new List<TransactionAccountModel>();
        public static List<TransactionAccountModel> LastTransactionList = new List<TransactionAccountModel>();

        public static void LoadFromDatabase() //Not Acc because should doing transaction
        {
            DatabaseConnection.SetConnection();
            DatabaseConnection.sql_con.Open();
            sql_cmd = DatabaseConnection.sql_con.CreateCommand();
            string CommandText = "SELECT * " +
                                 "FROM TransactionAccount";

            using (SQLiteCommand cmd = new SQLiteCommand(CommandText, DatabaseConnection.sql_con))
            {
                using (SQLiteDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        tsAccountList.Add(new TransactionAccountModel
                        {
                            TransactionID = rdr["TransactionID"].ToString(),

                            IndexLine = rdr["IndexLine"].ToString(),

                            Type = rdr["Type"].ToString(),

                            AccountID = rdr["AccountID"].ToString()
                                                      ,
                            Username = rdr["Username"].ToString()
                                                      ,
                            Password = rdr["Password"].ToString()
                                                      ,
                            DisplayName = rdr["DisplayName"].ToString()
                                                      ,
                            Roles = rdr["Roles"].ToString()
                        });
                    }
                }
            }

            DatabaseConnection.sql_con.Close();
        }


        public static void LoadLastTransaction() //Not Acc because should doing transaction
        {
            DatabaseConnection.SetConnection();
            DatabaseConnection.sql_con.Open();
            sql_cmd = DatabaseConnection.sql_con.CreateCommand();
            string CommandText = "SELECT * " +
                                 "FROM TransactionAccount " +
                                 "ORDER BY TransactionID DESC " +
                                 "LIMIT 1 ";

            using (SQLiteCommand cmd = new SQLiteCommand(CommandText, DatabaseConnection.sql_con))
            {
                using (SQLiteDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        LastTransactionList.Add(new TransactionAccountModel
                        {
                            TransactionID = rdr["TransactionID"].ToString(),

                            IndexLine = rdr["IndexLine"].ToString(),

                            Type = rdr["Type"].ToString(),

                            AccountID = rdr["AccountID"].ToString()
                                                      ,
                            Username = rdr["Username"].ToString()
                                                      ,
                            Password = rdr["Password"].ToString()
                                                      ,
                            DisplayName = rdr["DisplayName"].ToString()
                                                      ,
                            Roles = rdr["Roles"].ToString()
                        });
                    }
                }
            }

            DatabaseConnection.sql_con.Close();
        }
    }
}
