﻿using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqliteDB.Controller;
using System.Data;

namespace SqliteDB.Model
{
    public class CreateDatabase
    {
        public static bool CheckExisting()
        {
            if (File.Exists(""))//Path
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }
         
        public static void Create()
        {
            if (CheckExisting())
            {
                SQLiteConnection.CreateFile("MyDatabase.sqlite");
                SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
                m_dbConnection.Open();

                string sql = "create table highscores (name varchar(20), score int)";

                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                command.ExecuteNonQuery();

                sql = "insert into highscores (name, score) values ('Me', 9001)";

                command = new SQLiteCommand(sql, m_dbConnection);
                command.ExecuteNonQuery();

                m_dbConnection.Close();
            }
            else
            {
                SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
                m_dbConnection.Open();

                string sql = "create table highscores (name varchar(20), score int)";

                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                command.ExecuteNonQuery();

                sql = "insert into highscores (name, score) values ('Me', 9001)";

                command = new SQLiteCommand(sql, m_dbConnection);
                command.ExecuteNonQuery();

                m_dbConnection.Close();
            }
           
        }

        public static void CreateAccountTable()
        {
            DatabaseConnection.SetConnection();
            DatabaseConnection.sql_con.Open();

            SQLiteCommand CommandText = new SQLiteCommand("CREATE TABLE Account " +
                                                          "AccountID VARCHAR(10) PRIMARY KEY NOT NULL UNIQUE, " +
                                                          "Username VARCHAR (20)," +
                                                          "Password VARCHAR (20)," +
                                                          "DisplayName VARCHAR (20)," +
                                                          "Roles       VARCHAR (20) "
                                                          , DatabaseConnection.sql_con);

            CommandText.ExecuteNonQuery();


            DatabaseConnection.sql_con.Close();
        }

    }
}
