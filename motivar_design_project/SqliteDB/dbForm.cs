using SqliteDB.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SqliteDB
{
    public partial class dbForm : Form
    {
        private SQLiteConnection sql_con;
        private SQLiteCommand sql_cmd;
        private SQLiteDataAdapter DB;
        private DataSet DS = new DataSet("SqliteDataSet");
        private DataTable DT = new DataTable("Account");

        public void dbconn()
        {
            SetConnection();
            sql_con.Open();

            sql_cmd = sql_con.CreateCommand();
            string CommandText = "select * from Account";
            DB = new SQLiteDataAdapter(CommandText, sql_con);
            DS.Reset();
            DB.Fill(DS);
            DT.TableName = "Account";
            DT = DS.Tables[0];
            Grid.DataSource = DT;
            sql_con.Close();
            
        }

        public void SetConnection()
        {
            sql_con = new SQLiteConnection(@"Data Source=C:\Users\motivar\Desktop\Database\Database_Prototype.db;Version=3;");
        }

        public dbForm()
        {
            InitializeComponent();

            /*dbconnect.dbCreate();
            dbconnect.dbConnection();
            dbconnect.dbCreateTable();*/

            dbconn();


        }
    }
}
