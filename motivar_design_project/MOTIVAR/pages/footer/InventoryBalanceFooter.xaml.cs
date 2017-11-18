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
using MOTIVAR.pages.footer;
using MOTIVAR.pages;
using MOTIVAR.pages.submenu;
using MOTIVAR.controller;

namespace MOTIVAR.pages.footer
{
    /// <summary>
    /// Interaction logic for InventoryBalanceFooter.xaml
    /// </summary>
    public partial class InventoryBalanceFooter : UserControl
    {
        public InventoryBalanceFooter()
        {
            InitializeComponent();
        }

        private void NewProductFooterButton_Click(object sender, RoutedEventArgs e)
        {
            NewProduct _NewProdcut = new NewProduct();
            if (!GlobalVariables.isNewProductWindowShow)
            {
                GlobalVariables.isNewProductWindowShow = true;
                _NewProdcut.Show();

                GlobalFunction.DebugMessage("NewProductWindows Show");
            }
 
        }
    }
}
