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
using MOTIVAR.pages;
using System.Diagnostics;

namespace MOTIVAR.pages
{
    /// <summary>
    /// Interaction logic for Main.xaml
    /// </summary>
    public partial class Main : Window
    {
        InventoryBalance _InventoryBalance = new InventoryBalance();
        Sales _Sales = new Sales();

        public Main()
        {   
            InitializeComponent();
            SetUserControlMenu(_InventoryBalance);



        }

        private void MainWindows_Loaded(object sender, RoutedEventArgs e)
        {
            TextTestWidth.Text = "W : " + UserControlGrid.ActualWidth.ToString();
            TextTestHeight.Text = "H : " + UserControlGrid.ActualHeight.ToString();
        }

        private void InventoryBalanceMenu_Selected(object sender, RoutedEventArgs e) => SetUserControlMenu(_InventoryBalance);

        private void SalesMenu_Selected(object sender, RoutedEventArgs e) => SetUserControlMenu(_Sales);

        private void SetUserControlMenu(UserControl _UserControlSelected)
        {
            ClearUserControlGrid();
            UserControlGrid.Children.Add(_UserControlSelected);
        }

        private void ClearUserControlGrid()
        {
            UserControlGrid.Children.Clear();
        }


    }


}
