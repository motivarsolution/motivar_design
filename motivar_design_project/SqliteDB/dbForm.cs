using SqliteDB.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
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
        private List<AccountModel> EntryList = new List<AccountModel>();
        private SQLiteConnection sql_con;
        private SQLiteCommand sql_cmd;
        private SQLiteDataAdapter DB;
        private SQLiteDataReader RD;
        private DataSet DS = new DataSet("SqliteDataSet");
        private DataTable DT = new DataTable("Account");

        //public void dbconn()
        //{
        //    SetConnection();
        //    sql_con.Open();

        //    sql_cmd = sql_con.CreateCommand();
        //    string CommandText = "select * from Account";
        //    DB = new SQLiteDataAdapter(CommandText, sql_con);
        //    DS.Reset();
        //    DB.Fill(DS);
        //    DT = DS.Tables[0];
        //    Grid.DataSource = DT;
        //    sql_con.Close();
            
        //}

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

        private void RefreshDataSet()
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
                        AcList.Add(new AccountModel
                        {
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

            sql_con.Close();
        }

        public void SetConnection()
        {
            if(Environment.MachineName == "DESKTOP-P3P3RQJ")
            {
                sql_con = new SQLiteConnection(@"Data Source=E:\OneDrive\MOTIVAR\Database_Prototype.db;Version=3;");
            }
            else
            {
                sql_con = new SQLiteConnection(@"Data Source=C:\Users\motivar\OneDrive\MOTIVAR\Database_Prototype.db;Version=3;");
            }

        }


        public dbForm()
        {
            InitializeComponent();

            SetProperties();

            dbReadToList();
            ListToDataSet();

            //ConnectGoogleDrive.Connect();

        }

        private void SetProperties()
        {
            this.Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.Grid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
        }

        private void Grid_SelectionChanged(object sender, EventArgs e)
        {
            //SelectedTextbox.Text = Grid.CurrentCell.Value.ToString() + " ||   "
            //    + Grid.CurrentCell.ColumnIndex.ToString() + " : " + Grid.CurrentCell.RowIndex.ToString();
            string RowSelectedText = "";

            if (Grid.SelectedRows.Count > 0)
            {
                RowSelectedText = Grid.CurrentRow.Cells["AccountID"].Value.ToString() + " "
                                + Grid.CurrentRow.Cells["Username"].Value.ToString() + " "
                                + Grid.CurrentRow.Cells["Password"].Value.ToString() + " "
                                + Grid.CurrentRow.Cells["DisplayName"].Value.ToString() + " "
                                + Grid.CurrentRow.Cells["Roles"].Value.ToString() + " ";

                AccountIDTextbox.Text = Grid.CurrentRow.Cells["AccountID"].Value.ToString();
                UsernameTextbox.Text = Grid.CurrentRow.Cells["Username"].Value.ToString();
                PasswordTextbox.Text = Grid.CurrentRow.Cells["Password"].Value.ToString();
                DisplayNameTextbox.Text = Grid.CurrentRow.Cells["DisplayName"].Value.ToString();
                RolesTextbox.Text = Grid.CurrentRow.Cells["Roles"].Value.ToString();


            }
            SelectedTextbox.Text = RowSelectedText;


            Debug.WriteLine(SelectedTextbox.Text);

        }

        private void InsertDatabase(List<AccountModel> _EntryList)//Should not List beccause Input each 1 data set
        {
            SetConnection();
            sql_con.Open();
            SQLiteCommand CommandText = new SQLiteCommand("INSERT INTO Account (AccountID , Username , Password , DisplayName , Roles) VALUES ('"+ _EntryList.First().AccountID + "','" + _EntryList.First().Username + "','" + _EntryList.First().Password + "','" + _EntryList.First().DisplayName + "','" + _EntryList.First().Roles + "')", sql_con);

            CommandText.ExecuteNonQuery();

            sql_con.Close();

            AcList.Add(_EntryList.First());


        }

        private void NewButton_Click(object sender, EventArgs e)
        {

            EntryList.Add(new AccountModel()
            {
                AccountID = AccountIDTextbox.Text
                                            ,
                Username = UsernameTextbox.Text
                                            ,
                Password = AES.AESController.EncryptText(PasswordTextbox.Text, "MOTIVAR")
                                            ,
                DisplayName = DisplayNameTextbox.Text
                                            ,
                Roles = RolesTextbox.Text
            });

            InsertDatabase(EntryList);


        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            AccountIDTextbox.Text = "";
            UsernameTextbox.Text = "";
            PasswordTextbox.Text = "";
            DisplayNameTextbox.Text = "";
            RolesTextbox.Text = "";
        }
    }
}
