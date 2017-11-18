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
using System.Windows.Shapes;
using MOTIVAR.model;
using MOTIVAR.controller;
using System.IO;
using System.Reflection;

namespace MOTIVAR.pages.submenu
{
    /// <summary>
    /// Interaction logic for NewProduct.xaml
    /// </summary>
    public partial class NewProduct : Window
    {
        List<TextListModelTest> _test = new List<TextListModelTest>();
        List<String> _combo = new List<string>();
        public NewProduct()
        {
            InitializeComponent();
            _test.Add(new TextListModelTest() { details1 = "combo1", details2 = "combo2" , details3 = "combo3"});
            _combo.Add("combo1");
            _combo.Add("combo2");
            _combo.Add("combo3");

            ProductTypeComboBox.ItemsSource = _combo;

            NewProductImage.Source = new BitmapImage(new Uri(@"\resource\images\Warehouse.png", UriKind.Relative));

        }

        private void NewProductWindow_Unloaded(object sender, RoutedEventArgs e)
        {
            GlobalVariables.isNewProductWindowShow = false;
            GlobalFunction.DebugMessage("NewProductWindows Close");
            this.Close();
        }

        private void NewProductImageBrowseButton_Click(object sender, RoutedEventArgs e)
        {
            // Create OpenFileDialog 
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            // Set filter for file extension and default file extension 
            dlg.DefaultExt = ".png";
            dlg.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";

            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = dlg.ShowDialog();

            // Get the selected file name and display in a TextBox 
            if (result == true)
            {
                // Open document 
                string filename = dlg.FileName;
                NewProductImageBrowseTextBlock.Text = filename;
                NewProductImage.Source = new BitmapImage(new Uri(filename, UriKind.RelativeOrAbsolute));
            }

            
        }

        private void NewProductCancelButton_Click(object sender, RoutedEventArgs e)
        {
            GlobalVariables.isNewProductWindowShow = false;
            GlobalFunction.DebugMessage("NewProductWindows Close");
            this.Close();
        }
    }
}
