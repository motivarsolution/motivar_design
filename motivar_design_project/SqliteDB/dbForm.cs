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
        private List<AccountModel> UpdateList = new List<AccountModel>();
        private SQLiteConnection sql_con;
        private SQLiteCommand sql_cmd;

        private void dbReadToList()
        {
            SetConnection();
            sql_con.Open();
            sql_cmd = sql_con.CreateCommand();
            string CommandText = "SELECT * FROM Account";

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
            //ListToDataSet();

            Grid.DataSource = AcList;

            
            
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

            if(_EntryList.Count == 1)
            {

                SQLiteCommand CommandText = new SQLiteCommand("INSERT INTO Account (AccountID , Username , Password , DisplayName , Roles) VALUES (@AccountID,@Username,@Password,@DisplayName,@Roles)", sql_con);

                CommandText.CommandType = CommandType.Text;

                CommandText.Parameters.Add(new SQLiteParameter("@AccountID", _EntryList.First().AccountID));
                CommandText.Parameters.Add(new SQLiteParameter("@Username", _EntryList.First().Username));
                CommandText.Parameters.Add(new SQLiteParameter("@Password", _EntryList.First().Password));
                CommandText.Parameters.Add(new SQLiteParameter("@DisplayName", _EntryList.First().DisplayName));
                CommandText.Parameters.Add(new SQLiteParameter("@Roles", _EntryList.First().Roles));

                CommandText.ExecuteNonQuery();

                AcList.Add(_EntryList.First());
                //ListToDataSet();

            }
            else
            {
                foreach (var item in _EntryList)
                {
                    SQLiteCommand CommandText = new SQLiteCommand("INSERT INTO Account (AccountID , Username , Password , DisplayName , Roles) VALUES (@AccountID,@Username,@Password,@DisplayName,@Roles)", sql_con);

                    CommandText.CommandType = CommandType.Text;

                    CommandText.Parameters.Add(new SQLiteParameter("@AccountID", item.AccountID));
                    CommandText.Parameters.Add(new SQLiteParameter("@Username", item.Username));
                    CommandText.Parameters.Add(new SQLiteParameter("@Password", item.Password));
                    CommandText.Parameters.Add(new SQLiteParameter("@DisplayName", item.DisplayName));
                    CommandText.Parameters.Add(new SQLiteParameter("@Roles", item.Roles));
                    AcList.Add(_EntryList.First());
                }

                //ListToDataSet();
            }
          
            sql_con.Close();
            _EntryList.Clear();


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

            AccountIDTextbox.Enabled = false;

        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            AccountIDTextbox.Enabled = true;
            AccountIDTextbox.Text = "";
            UsernameTextbox.Text = "";
            PasswordTextbox.Text = "";
            DisplayNameTextbox.Text = "";
            RolesTextbox.Text = "";
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            var query = AcList.Where(x => x.AccountID == Grid.CurrentRow.Cells["AccountID"].Value.ToString());

            if (query.ToList().Count() > 0)
            {
                MessageBox.Show("Query Result found. :" + query.ToList().Count().ToString());

                UpdateList.Add(new AccountModel
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
            }


            
        }
    }
}
