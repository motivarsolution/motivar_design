using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using TEST.View;

namespace TEST
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void DBConnect()
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=e:\my documents\visual studio 2017\Projects\TEST\TEST\myDB.mdf;Integrated Security=True;Connect Timeout=30");

            string query = "SELECT * FROM Account WHERE Username = '" + UsernameTextbox.Text.Trim() + "' AND Password = '" + PasswordTextbox.Text.Trim() + "'";

            SqlDataAdapter sqlad = new SqlDataAdapter(query, con);

            DataTable dtb = new DataTable();
            sqlad.Fill(dtb);

            if(dtb.Rows.Count == 1)
            {
                StatusTextbox.BackColor = Color.LightGreen;
                Form2 Check = new Form2();
                Check.Show();
                Hide();
            }
            else
            {
                StatusTextbox.BackColor = Color.Red;
            }

        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            DBConnect();
        }
    }
}
