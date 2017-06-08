using SqliteDB.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SqliteDB
{
    public partial class dbForm : Form
    {
        private List<AccountModel> AcList = new List<AccountModel>();
        private SQLiteConnection sql_con;
        private SQLiteCommand sql_cmd;
        private SQLiteDataAdapter DB;
        private SQLiteDataReader RD;
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
            DT = DS.Tables[0];
            Grid.DataSource = DT;
            sql_con.Close();
            
        }

        private void dbReadToList()
        {
            SetConnection();
            sql_con.Open();
            sql_cmd = sql_con.CreateCommand();
            string CommandText = "select * from Account";

            using (SQLiteCommand cmd = new SQLiteCommand(CommandText, sql_con))
            {
                using (SQLiteDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        AcList.Add(new AccountModel { AccountID = rdr["AccountID"].ToString()
                                                      ,Username = rdr["Username"].ToString()
                                                      ,Password = rdr["Password"].ToString()
                                                      ,DisplayName = rdr["DisplayName"].ToString()
                                                      ,Roles = rdr["Roles"].ToString()});
                    }
                }
            }
            
            sql_con.Close();

        }

        private void ListToDataSet()
        {
            DataTable dt = new DataTable("AccountTable");
            Type t = typeof(AccountModel);
            PropertyInfo[] pia = t.GetProperties();

            //Inspect the properties and create the columns in the DataTable
            foreach (PropertyInfo pi in pia)
            {
                Type ColumnType = pi.PropertyType;
                if ((ColumnType.IsGenericType))
                {
                    ColumnType = ColumnType.GetGenericArguments()[0];
                }
                dt.Columns.Add(pi.Name, ColumnType);
            }

            //Populate the data table
            foreach (AccountModel item in AcList)
            {
                DataRow dr = dt.NewRow();
                dr.BeginEdit();
                foreach (PropertyInfo pi in pia)
                {
                    if (pi.GetValue(item, null) != null)
                    {
                        dr[pi.Name] = pi.GetValue(item, null);
                    }
                }
                dr.EndEdit();
                dt.Rows.Add(dr);
            }
            Grid.DataSource = dt;
        }

        public void SetConnection()
        {
            sql_con = new SQLiteConnection(@"Data Source=C:\Users\motivar\OneDrive\MOTIVAR\Database_Prototype.db;Version=3;");
        }

        //public DataTable ToDataTable<AccountModel>(this IEnumerable<AccountModel> collection)
        //{
        //    DataTable dt = new DataTable("DataTable");
        //    Type t = typeof(AccountModel);
        //    PropertyInfo[] pia = t.GetProperties();

        //    //Inspect the properties and create the columns in the DataTable
        //    foreach (PropertyInfo pi in pia)
        //    {
        //        Type ColumnType = pi.PropertyType;
        //        if ((ColumnType.IsGenericType))
        //        {
        //            ColumnType = ColumnType.GetGenericArguments()[0];
        //        }
        //        dt.Columns.Add(pi.Name, ColumnType);
        //    }

        //    //Populate the data table
        //    foreach (T item in collection)
        //    {
        //        DataRow dr = dt.NewRow();
        //        dr.BeginEdit();
        //        foreach (PropertyInfo pi in pia)
        //        {
        //            if (pi.GetValue(item, null) != null)
        //            {
        //                dr[pi.Name] = pi.GetValue(item, null);
        //            }
        //        }
        //        dr.EndEdit();
        //        dt.Rows.Add(dr);
        //    }
        //    return dt;
        //}

        public dbForm()
        {
            InitializeComponent();

            /*dbconnect.dbCreate();
            dbconnect.dbConnection();
            dbconnect.dbCreateTable();*/

            //dbconn();
            dbReadToList();
            ListToDataSet();

            //ConnectGoogleDrive.Connect();

        }
    }
}
