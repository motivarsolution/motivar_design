using SqliteDB.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SqliteDB
{
    public partial class dbForm : Form
    {
        public dbForm()
        {
            InitializeComponent();

            dbconnect.dbCreate();
            dbconnect.dbConnection();
            dbconnect.dbCreateTable();


        }
    }
}
