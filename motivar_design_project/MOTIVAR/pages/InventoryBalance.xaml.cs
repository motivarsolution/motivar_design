using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MOTIVAR.model;
using MOTIVAR.pages.submenu;

namespace MOTIVAR.pages
{
    /// <summary>
    /// Interaction logic for InventoryBalance.xaml
    /// </summary>
    public partial class InventoryBalance : UserControl
    {
        public InventoryBalance()
        {
            InitializeComponent();

            List<DataTest> testList = new List<DataTest>();
            testList.Add(new DataTest() { Id = "001", Name = "TEST001", Username = "TEST001USER", Pass = "000001" });
            testList.Add(new DataTest() { Id = "002", Name = "TEST002", Username = "TEST002USER", Pass = "000002" });
            testList.Add(new DataTest() { Id = "003", Name = "TEST003", Username = "TEST003USER", Pass = "000003" });
            testList.Add(new DataTest() { Id = "004", Name = "TEST004", Username = "TEST004USER", Pass = "000004" });
            testList.Add(new DataTest() { Id = "005", Name = "TEST005", Username = "TEST005USER", Pass = "000005" });
            testList.Add(new DataTest() { Id = "006", Name = "TEST006", Username = "TEST006USER", Pass = "000006" });

            MainDataGrid.ItemsSource = testList;

        }

        private void EditProductInventoryBalanceButton_Click(object sender, RoutedEventArgs e)
        {
            EditProduct editProduct = new EditProduct();
            editProduct.Show();
        }

        private void NewProductInventoryBalanceButton_Click(object sender, RoutedEventArgs e)
        {
            NewProduct newProduct = new NewProduct();
            newProduct.Show();
        }
    }

    public class DataTest
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Username { get; set; }

        public string Pass { get; set; }

    }
}
