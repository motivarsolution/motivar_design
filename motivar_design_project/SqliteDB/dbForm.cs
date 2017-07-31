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
using SqliteDB.Controller;
using Microsoft.Identity.Client;
using System.Collections.ObjectModel;
using SqliteDB.Utility;
using BarcodeGen;
using InvoiceForm;

namespace SqliteDB
{
    public partial class dbForm : Form
    {
        private List<AccountModel> AcList = new List<AccountModel>();
        private SQLiteConnection sql_con;
        private SQLiteCommand sql_cmd;
        private BackgroundWorker InsertBackground = new BackgroundWorker();
        private BackgroundWorker TransactionWorking = new BackgroundWorker();
        private QueueTransaction tsAccountQueue = new QueueTransaction();

        private static string ClientId = "aca6f1e2-1962-46b9-afb5-e04da8eb4065";
        public static PublicClientApplication PublicClientApp = new PublicClientApplication(ClientId);

        private enum tsStatus
        {
            PREPAIR,
            COMPLETE,
            INQUEUE,
            REJECT,
            QUEUE_ERROR,
            DB_ERROR,
            BG_ERROR
        };

        public dbForm()
        {        

            InitializeComponent();

            DefineBackgroundWorker();
            SetProperties();
            dbReadToList();
            Grid.DataSource = AcList;

            StoreTransactionAccount.LoadLastTransaction();

            tsAccountQueue.Enqueued += RunningQueues;
        }


        private void dbForm_Load(object sender, EventArgs e)
        {
            if (!DatabaseVersionCheck.Checked()) //Database Version Checking
            {
                MessageBox.Show("Database is Not Latest Version.", "Database Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                CloseApp();
            }
        }

        private void DefineBackgroundWorker()
        {
            InsertBackground.DoWork += InsertDatabaseBackgroundWorker_DoWork;
            InsertBackground.ProgressChanged += InsertDatabaseBackgroundWorker_ProgressChanged;
            InsertBackground.RunWorkerCompleted += InsertDatabaseBackgroundWorker_Complete;

            TransactionWorking.DoWork += TransactionWorking_DoWork;
            TransactionWorking.ProgressChanged += TransactionWorking_ProgressChanged;
            TransactionWorking.RunWorkerCompleted += TransactionWorking_Complete;
        }

        private void dbReadToList() //Important
        {
            SetConnection();
            sql_con.Open();
            sql_cmd = sql_con.CreateCommand();
            string CommandText = "SELECT * " +
                                 "FROM Account";

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

        private void ListToDataSet() //Unnessesory
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

        private void RefreshDataGridView()
        {
            Grid.DataSource = typeof(AccountModel); 
            Grid.DataSource = AcList;

            AcList.OrderBy(x => x.AccountID); // sort by ascending

            Grid.FirstDisplayedScrollingRowIndex = Grid.RowCount - 1; // scroll to bottom row
        }

        private void SetProperties()
        {
            this.Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.Grid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
        }

        private void Grid_SelectionChanged(object sender, EventArgs e)
        {
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

        private void NewButton_Click(object sender, EventArgs e)
        {
            List<AccountModel> EntryList = new List<AccountModel>();
            TransactionAccountModel EntryTransaction = new TransactionAccountModel();

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

            EntryTransaction = CreateTransaction(EntryList, "I");
            AddTransactionIntoQueues(EntryTransaction);

            //InsertDatabase(EntryList);//Normal
            //InsertBackground.RunWorkerAsync(EntryList);//BackgroundWorker Process

        }

        private void InsertDatabaseTS(TransactionAccountModel _InsertTS)
        {
            DatabaseConnection.SetConnection();
            DatabaseConnection.sql_con.Open();

            try
            {
                SQLiteCommand CommandText = new SQLiteCommand("INSERT " +
                                                              "INTO Account (AccountID , Username , Password , DisplayName , Roles) " +
                                                              "VALUES (@AccountID,@Username,@Password,@DisplayName,@Roles)", DatabaseConnection.sql_con);

                CommandText.CommandType = CommandType.Text;

                CommandText.Parameters.Add(new SQLiteParameter("@AccountID", _InsertTS.AccountID));
                CommandText.Parameters.Add(new SQLiteParameter("@Username", _InsertTS.Username));
                CommandText.Parameters.Add(new SQLiteParameter("@Password", _InsertTS.Password));
                CommandText.Parameters.Add(new SQLiteParameter("@DisplayName", _InsertTS.DisplayName));
                CommandText.Parameters.Add(new SQLiteParameter("@Roles", _InsertTS.Roles));

                CommandText.ExecuteNonQuery();

                DatabaseConnection.sql_con.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Username Existing");
                return;
            }
            
        }

        private void InsertDatabase(List<AccountModel> _EntryList)//Should not List beccause Input each 1 data set
        {
            SetConnection();
            sql_con.Open();

            if(_EntryList.Count == 1)
            {
                try
                {
                    SQLiteCommand CommandText = new SQLiteCommand("INSERT " +
                                                                  "INTO Account (AccountID , Username , Password , DisplayName , Roles) " +
                                                                  "VALUES (@AccountID,@Username,@Password,@DisplayName,@Roles)", sql_con);

                    CommandText.CommandType = CommandType.Text;

                    CommandText.Parameters.Add(new SQLiteParameter("@AccountID", _EntryList.First().AccountID));
                    CommandText.Parameters.Add(new SQLiteParameter("@Username", _EntryList.First().Username));
                    CommandText.Parameters.Add(new SQLiteParameter("@Password", _EntryList.First().Password));
                    CommandText.Parameters.Add(new SQLiteParameter("@DisplayName", _EntryList.First().DisplayName));
                    CommandText.Parameters.Add(new SQLiteParameter("@Roles", _EntryList.First().Roles));

                    CommandText.ExecuteNonQuery();


                    //ListToDataSet();
                }
                catch (Exception)
                {

                    throw;
                }
                

            }
            else
            {
                //foreach (var item in _EntryList)
                //{
                //    SQLiteCommand CommandText = new SQLiteCommand("INSERT INTO Account (AccountID , Username , Password , DisplayName , Roles) VALUES (@AccountID,@Username,@Password,@DisplayName,@Roles)", sql_con);

                //    CommandText.CommandType = CommandType.Text;

                //    CommandText.Parameters.Add(new SQLiteParameter("@AccountID", item.AccountID));
                //    CommandText.Parameters.Add(new SQLiteParameter("@Username", item.Username));
                //    CommandText.Parameters.Add(new SQLiteParameter("@Password", item.Password));
                //    CommandText.Parameters.Add(new SQLiteParameter("@DisplayName", item.DisplayName));
                //    CommandText.Parameters.Add(new SQLiteParameter("@Roles", item.Roles));
                //    AcList.Add(_EntryList.First());
                //}

                //ListToDataSet();
            }
          
            sql_con.Close();
            //_EntryList.Clear();


        }

        private void InsertDatabaseBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            List<AccountModel> _EntryList = e.Argument as List<AccountModel>;

            SetConnection();
            sql_con.Open();

            SQLiteCommand CommandText = new SQLiteCommand("INSERT " +
                                                          "INTO Account (AccountID , Username , Password , DisplayName , Roles) " +
                                                          "VALUES (@AccountID,@Username,@Password,@DisplayName,@Roles)", sql_con);

            CommandText.CommandType = CommandType.Text;

            CommandText.Parameters.Add(new SQLiteParameter("@AccountID", _EntryList.First().AccountID));
            CommandText.Parameters.Add(new SQLiteParameter("@Username", _EntryList.First().Username));
            CommandText.Parameters.Add(new SQLiteParameter("@Password", _EntryList.First().Password));
            CommandText.Parameters.Add(new SQLiteParameter("@DisplayName", _EntryList.First().DisplayName));
            CommandText.Parameters.Add(new SQLiteParameter("@Roles", _EntryList.First().Roles));

            CommandText.ExecuteNonQuery();


            sql_con.Close();

            e.Result = _EntryList;
        }

        private void InsertDatabaseBackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void InsertDatabaseBackgroundWorker_Complete(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                List<AccountModel> _EntryList = e.Result as List<AccountModel>;
                AcList.Add(_EntryList.First());
                AccountIDTextbox.Enabled = false;

                RefreshDataGridView();

            }
            
        }

        //--------------------------TRANSACTION USING & QUEUES-------------------------------

        private TransactionAccountModel CreateTransaction(List<AccountModel> _EntryList, string _Type, string _IndexLine = "0" , tsStatus _Status = tsStatus.PREPAIR)
        {
            TransactionAccountModel tsAcc = new TransactionAccountModel();

            tsAcc.TransactionID = (int.Parse(StoreTransactionAccount.LastTransaction.TransactionID) + 1).ToString();
            tsAcc.IndexLine = _IndexLine;
            tsAcc.Type = _Type;
            tsAcc.AccountID = _EntryList.FirstOrDefault().AccountID;
            tsAcc.Username = _EntryList.FirstOrDefault().Username;
            tsAcc.Password = _EntryList.FirstOrDefault().Password;
            tsAcc.DisplayName = _EntryList.FirstOrDefault().DisplayName;
            tsAcc.Roles = _EntryList.FirstOrDefault().Roles;
            tsAcc.Status = _Status.ToString();

            if(_Type == "I")
            {
                tsAcc.CreatedBy = GlobalConstant.USERNAME;
                tsAcc.CreatedDateTime = DateTime.Now.ToString();
            }
            else //U D
            {
                tsAcc.ChangedBy = GlobalConstant.USERNAME;
                tsAcc.ChangedDateTime = DateTime.Now.ToString();
            }

            StoreTransactionAccount.LastTransaction = tsAcc;
            return tsAcc;

        }

        
                //>>>>>>>>>>>>> QUEUE >>>>>>>>>>>>>>
        private void AddTransactionIntoQueues(TransactionAccountModel _tsAcc)
        {
            tsAccountQueue.Enqueue(_tsAcc);
        }
            
        private void RunningQueues(object sender, EventArgs e)
        {
            TransactionWorking.RunWorkerAsync(tsAccountQueue);
        }

        private void ReleaseQueues(int count)
        {
            for (int i = 0; i < count; i++)
            {

                tsAccountQueue.Dequeue();
            }
            

        }
        //>>>>>>>>>>>>> QUEUE END >>>>>>>>>>>>>>

        private void TransactionWorking_DoWork(object sender, DoWorkEventArgs e)
        {
            List<TransactionAccountModel> TransactionQueue = tsAccountQueue.GetQueueItemList();

            foreach (var item in TransactionQueue)
            {
                switch (item.Type)
                {
                    case "I":
                        {
                            //Insert Database
                            InsertDatabaseTS(item);
                            break;
                        }
                    case "U":
                        {
                            UpdateDatabaseTS(item);
                            break;
                        }
                    case "D":
                        {
                            DeleteDatabaseTS(item);
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
            }

            e.Result = TransactionQueue;

        }
        private void TransactionWorking_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }
        private void TransactionWorking_Complete(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                List<TransactionAccountModel> ResultList = e.Result as List<TransactionAccountModel>;

                foreach (var item in ResultList)
                {
                    switch (item.Type)
                    {
                        case "I":
                            {
                                AcList.Add(new AccountModel
                                {
                                    AccountID = item.AccountID,
                                    Username = item.Username,
                                    Password = item.Password,
                                    DisplayName = item.DisplayName,
                                    Roles = item.Roles
                                });

                                AccountIDTextbox.Enabled = false;
                                RefreshDataGridView();
                                item.Status = tsStatus.COMPLETE.ToString();
                                break;
                            }
                        case "U":
                            {
                                AcList[Int16.Parse(item.IndexLine)].AccountID = item.AccountID;
                                AcList[Int16.Parse(item.IndexLine)].Username = item.Username;
                                AcList[Int16.Parse(item.IndexLine)].Password = item.Password;
                                AcList[Int16.Parse(item.IndexLine)].DisplayName = item.DisplayName;
                                AcList[Int16.Parse(item.IndexLine)].Roles = item.Roles;

                                AccountIDTextbox.Enabled = false;
                                RefreshDataGridView();
                                item.Status = tsStatus.COMPLETE.ToString();
                                break;
                            }
                        case "D":
                            {
                                AcList.RemoveAt(Int16.Parse(item.IndexLine));

                                AccountIDTextbox.Enabled = false;
                                RefreshDataGridView();
                                item.Status = tsStatus.COMPLETE.ToString();
                                break;
                            }
                        default:
                            {
                                break;
                            }
                    }

                    TransactionDatabase(item);
                }
            }


            ReleaseQueues(tsAccountQueue.Count);
            
        }

        private void TransactionDatabase(TransactionAccountModel _TS)
        {
            DatabaseConnection.SetConnection();
            DatabaseConnection.sql_con.Open();

            SQLiteCommand CommandText = new SQLiteCommand("INSERT " +
                                                              "INTO TransactionAccount (TransactionID , IndexLine , Type , AccountID , Username , Password , DisplayName , Roles , Status , " +
                                                              "CreatedBy , ChangedBy , CreatedDateTime , ChangedDateTime) " +
                                                              "VALUES (@TransactionID,@IndexLine,@Type,@AccountID,@Username,@Password,@DisplayName,@Roles,@Status," +
                                                              "@CreatedBy,@ChangedBy,@CreatedDateTime,@ChangedDateTime)", DatabaseConnection.sql_con);

            CommandText.CommandType = CommandType.Text;
            CommandText.Parameters.Add(new SQLiteParameter("@TransactionID", _TS.TransactionID));
            CommandText.Parameters.Add(new SQLiteParameter("@IndexLine", _TS.IndexLine));
            CommandText.Parameters.Add(new SQLiteParameter("@Type", _TS.Type));
            CommandText.Parameters.Add(new SQLiteParameter("@AccountID", _TS.AccountID));
            CommandText.Parameters.Add(new SQLiteParameter("@Username", _TS.Username));
            CommandText.Parameters.Add(new SQLiteParameter("@Password", _TS.Password));
            CommandText.Parameters.Add(new SQLiteParameter("@DisplayName", _TS.DisplayName));
            CommandText.Parameters.Add(new SQLiteParameter("@Roles", _TS.Roles));
            CommandText.Parameters.Add(new SQLiteParameter("@Status", _TS.Status));
            CommandText.Parameters.Add(new SQLiteParameter("@CreatedBy", _TS.CreatedBy));
            CommandText.Parameters.Add(new SQLiteParameter("@ChangedBy", _TS.ChangedBy));
            CommandText.Parameters.Add(new SQLiteParameter("@CreatedDateTime", _TS.CreatedDateTime));
            CommandText.Parameters.Add(new SQLiteParameter("@ChangedDateTime", _TS.ChangedDateTime));

            CommandText.ExecuteNonQuery();

            DatabaseConnection.sql_con.Close();


            try
            {
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }


        //-------------------------END USING TRANSACTION----------------------------

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
            List<AccountModel> UpdateList = new List<AccountModel>();
            TransactionAccountModel UpdateTransaction = new TransactionAccountModel();
            IEnumerable<AccountModel> query_linq = AcList.Where(x => x.AccountID == Grid.CurrentRow.Cells["AccountID"].Value.ToString());
            List<string> UpdateKeyList = new List<string>();
            int index = AcList.FindIndex(a => a.AccountID == Grid.CurrentRow.Cells["AccountID"].Value.ToString()); //find index was changed

            if (query_linq.ToList().Count() > 0)
            {
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

            UpdateTransaction = CreateTransaction(UpdateList, "U" , index.ToString());
            AddTransactionIntoQueues(UpdateTransaction);

            //UpdateKeyList.Add(UpdateList.FirstOrDefault().AccountID);
            //UpdateDatabase(UpdateList , UpdateKeyList);

            //AcList[index] = UpdateList.FirstOrDefault();
            //RefreshDataGridView();
        }

        private void UpdateDatabaseTS(TransactionAccountModel _UpdateTS)
        {
            DatabaseConnection.SetConnection();
            DatabaseConnection.sql_con.Open();
            SQLiteCommand CommandText = new SQLiteCommand("UPDATE Account " +
                                                          "SET AccountID = @AccountID , Username = @Username, Password = @Password, DisplayName = @DisplayName, Roles = @Roles " +
                                                          "WHERE AccountID = @UpdateKey", DatabaseConnection.sql_con);

            CommandText.CommandType = CommandType.Text;

            CommandText.Parameters.Add(new SQLiteParameter("@AccountID", _UpdateTS.AccountID));
            CommandText.Parameters.Add(new SQLiteParameter("@Username", _UpdateTS.Username));
            CommandText.Parameters.Add(new SQLiteParameter("@Password", _UpdateTS.Password));
            CommandText.Parameters.Add(new SQLiteParameter("@DisplayName", _UpdateTS.DisplayName));
            CommandText.Parameters.Add(new SQLiteParameter("@Roles", _UpdateTS.Roles));
            CommandText.Parameters.Add(new SQLiteParameter("@UpdateKey", _UpdateTS.AccountID));

            CommandText.ExecuteNonQuery();


            DatabaseConnection.sql_con.Close();
        }

        private void UpdateDatabase(List<AccountModel> _UpdateList ,List<string> _UpdateKeyList) //multiple Update
        {
            SetConnection();
            sql_con.Open();

            SQLiteCommand CommandText = new SQLiteCommand("UPDATE Account " +
                                                          "SET AccountID = @AccountID , Username = @Username, Password = @Password, DisplayName = @DisplayName, Roles = @Roles " +
                                                          "WHERE AccountID = @UpdateKey", sql_con);

            CommandText.CommandType = CommandType.Text;

            CommandText.Parameters.Add(new SQLiteParameter("@AccountID", _UpdateList.First().AccountID));
            CommandText.Parameters.Add(new SQLiteParameter("@Username", _UpdateList.First().Username));
            CommandText.Parameters.Add(new SQLiteParameter("@Password", _UpdateList.First().Password));
            CommandText.Parameters.Add(new SQLiteParameter("@DisplayName", _UpdateList.First().DisplayName));
            CommandText.Parameters.Add(new SQLiteParameter("@Roles", _UpdateList.First().Roles));
            CommandText.Parameters.Add(new SQLiteParameter("@UpdateKey", _UpdateKeyList.First()));

            CommandText.ExecuteNonQuery();


            sql_con.Close();

        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to delete.", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question , MessageBoxDefaultButton.Button1);
            TransactionAccountModel DeleteTransaction = new TransactionAccountModel();
            List<AccountModel> DeleteList = new List<AccountModel>();
            IEnumerable<AccountModel> query_linq = AcList.Where(x => x.AccountID == Grid.CurrentRow.Cells["AccountID"].Value.ToString());
            List<string> DeleteKeyList = new List<string>();
            int index = AcList.FindIndex(a => a.AccountID == Grid.CurrentRow.Cells["AccountID"].Value.ToString()); //find index was changed

            if (result == DialogResult.OK)
            {
                
                if (query_linq.ToList().Count() > 0)
                {
                    DeleteList.Add(new AccountModel
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

                DeleteTransaction = CreateTransaction(DeleteList, "D", index.ToString());
                AddTransactionIntoQueues(DeleteTransaction);

                //DeleteKeyList.Add(DeleteList.FirstOrDefault().AccountID);
                //DeleteDatabase(DeleteList, DeleteKeyList);

                //AcList.RemoveAt(index);
                //RefreshDataGridView();
            }

        }

        private void DeleteDatabaseTS(TransactionAccountModel _DeleteTS)
        {
            DatabaseConnection.SetConnection();
            DatabaseConnection.sql_con.Open();
            SQLiteCommand CommandText = new SQLiteCommand("DELETE " +
                                                          "FROM Account " +
                                                          "WHERE AccountID = @DeleteKey", DatabaseConnection.sql_con);

            CommandText.CommandType = CommandType.Text;

            CommandText.Parameters.Add(new SQLiteParameter("@AccountID", _DeleteTS.AccountID));
            CommandText.Parameters.Add(new SQLiteParameter("@Username", _DeleteTS.Username));
            CommandText.Parameters.Add(new SQLiteParameter("@Password", _DeleteTS.Password));
            CommandText.Parameters.Add(new SQLiteParameter("@DisplayName", _DeleteTS.DisplayName));
            CommandText.Parameters.Add(new SQLiteParameter("@Roles", _DeleteTS.Roles));
            CommandText.Parameters.Add(new SQLiteParameter("@DeleteKey", _DeleteTS.AccountID));

            CommandText.ExecuteNonQuery();


            DatabaseConnection.sql_con.Close();
        }

        private void DeleteDatabase(List<AccountModel> _DeleteList, List<string> _DeleteKeyList)
        {
            SetConnection();
            sql_con.Open();
            
            SQLiteCommand CommandText = new SQLiteCommand("DELETE " +
                                                          "FROM Account " +
                                                          "WHERE AccountID = @DeleteKey", sql_con);

            CommandText.CommandType = CommandType.Text;

            CommandText.Parameters.Add(new SQLiteParameter("@AccountID", _DeleteList.First().AccountID));
            CommandText.Parameters.Add(new SQLiteParameter("@Username", _DeleteList.First().Username));
            CommandText.Parameters.Add(new SQLiteParameter("@Password", _DeleteList.First().Password));
            CommandText.Parameters.Add(new SQLiteParameter("@DisplayName", _DeleteList.First().DisplayName));
            CommandText.Parameters.Add(new SQLiteParameter("@Roles", _DeleteList.First().Roles));
            CommandText.Parameters.Add(new SQLiteParameter("@DeleteKey", _DeleteKeyList.First()));

            CommandText.ExecuteNonQuery();


            sql_con.Close();
        }

        private void CloseApp()
        {
            Application.Exit();
            Debug.WriteLine("Application Close");
        }

        private void bcGenButton_Click(object sender, EventArgs e)
        {
            var fitSize = bcPictureBox.ClientSize;
            Bitmap BarcodeBitmap = new Bitmap(BarcodeGenerate.BarcodeGen(Grid.CurrentRow.Cells["DisplayName"].Value.ToString()));
            bcPictureBox.Image = BarcodeBitmap;
            bcPictureBox.SizeMode = BarcodeBitmap.Width > fitSize.Width || BarcodeBitmap.Height > fitSize.Height ? PictureBoxSizeMode.Zoom : PictureBoxSizeMode.CenterImage;

        }

        private void CreateFormButton_Click(object sender, EventArgs e)
        {
            FormPDF.CreateFile();
        }
    }
}
