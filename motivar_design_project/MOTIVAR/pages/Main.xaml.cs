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
using MOTIVAR.controller;
using MOTIVAR.pages.footer;
using System.Drawing;

namespace MOTIVAR.pages
{
    /// <summary>
    /// Interaction logic for Main.xaml
    /// </summary>
    public partial class Main : Window
    {
        public InventoryBalance _InventoryBalance = new InventoryBalance();
        public Sales _Sales = new Sales();
        public Profile _Profile = new Profile();
        public Settings _Settings = new Settings();
        public MainFooter _MainFooterFooter = new MainFooter();

        public Main()
        {   
            InitializeComponent();
            
        }
        #region Startup
        
        private void Startup()
        {
            TextTestWidth.Text = "W : " + UserControlGrid.ActualWidth.ToString();
            TextTestHeight.Text = "H : " + UserControlGrid.ActualHeight.ToString();

            InventoryBalanceMenu_Selected(this, null);

            SetUserControlMenu(_InventoryBalance);
            GlobalVariables.CurrentPage = 0;
            GlobalFunction.DebugMessage("Current Page : " + GlobalVariables.CurrentPage);
            GlobalFunction.DebugMessage("Footer Height -> " + FooterGrid.ActualHeight);
            GlobalFunction.DebugMessage("Footer Width -> " + FooterGrid.ActualWidth);

            SetUserControlFooter(_MainFooterFooter);
        }

        private void SetFont()
        {
            //
        }

        #endregion

        #region Windows Event

        private void MainWindows_Loaded(object sender, RoutedEventArgs e)
        {
            Startup();   
        }

        private void MainWindows_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            GlobalFunction.DebugMessage("Footer Height -> " + FooterGrid.ActualHeight);
            GlobalFunction.DebugMessage("Footer Width -> " + FooterGrid.ActualWidth);
        }

        #endregion

        #region UserControl Selected/Unselected Event

        private void InventoryBalanceMenu_Selected(object sender, RoutedEventArgs e)
        {
            SetUserControlMenu(_InventoryBalance);
            SetUserControlFooter(_MainFooterFooter);
            InventoryBalanceMenuSelectedCheck.Visibility = Visibility.Visible;
            GlobalVariables.CurrentPage = 0;
            GlobalFunction.DebugMessage("Current Page : " + GlobalVariables.CurrentPage);
        }

        private void SalesMenu_Selected(object sender, RoutedEventArgs e)
        {
            SetUserControlMenu(_Sales);
            SalesMenuSelectedCheck.Visibility = Visibility.Visible;
            HiddenInventoryBalanceMenuSelectedCheck();
            GlobalVariables.CurrentPage = 1;
            GlobalFunction.DebugMessage("Current Page : " + GlobalVariables.CurrentPage);
        }

        private void ProfileMenu_Selected(object sender, RoutedEventArgs e)
        {
            SetUserControlMenu(_Profile);
            ProfileMenuSelectedCheck.Visibility = Visibility.Visible;
            HiddenInventoryBalanceMenuSelectedCheck();
            GlobalVariables.CurrentPage = 2;
            GlobalFunction.DebugMessage("Current Page : " + GlobalVariables.CurrentPage);
        }

        private void SettingsMenu_Selected(object sender, RoutedEventArgs e)
        {
            SetUserControlMenu(_Settings);
            SettingsMenuSelectedCheck.Visibility = Visibility.Visible;
            HiddenInventoryBalanceMenuSelectedCheck();
            GlobalVariables.CurrentPage = 3;
            GlobalFunction.DebugMessage("Current Page : " + GlobalVariables.CurrentPage);
        }

        private void InventoryBalanceMenu_Unselected(object sender, RoutedEventArgs e)
        {
            HiddenInventoryBalanceMenuSelectedCheck();
        }

        private void SalesMenu_Unselected(object sender, RoutedEventArgs e)
        {
            SalesMenuSelectedCheck.Visibility = Visibility.Hidden;
        }

        private void ProfileMenu_Unselected(object sender, RoutedEventArgs e)
        {
            ProfileMenuSelectedCheck.Visibility = Visibility.Hidden;
        }

        private void SettingsMenu_Unselected(object sender, RoutedEventArgs e)
        {
            SettingsMenuSelectedCheck.Visibility = Visibility.Hidden;
        }

        private void HiddenInventoryBalanceMenuSelectedCheck()
        {
            InventoryBalanceMenuSelectedCheck.Visibility = Visibility.Hidden;
        }

        #endregion

        #region Reactive UserControl


        #endregion

        #region UserControl Menu/Footer
        private void SetUserControlMenu(UserControl _UserControlSelected)
        {
            ClearUserControlGrid();
            UserControlGrid.Children.Add(_UserControlSelected);
        }

        private void ClearUserControlGrid()
        {
            UserControlGrid.Children.Clear();
        }

        private void SetUserControlFooter(UserControl _UserControlSelected)
        {
            ClearUserControlGridFooter();
            UserControlGridFooter.Children.Add(_UserControlSelected);
        }

        private void ClearUserControlGridFooter()
        {
            UserControlGridFooter.Children.Clear();
        }
        #endregion

    }


}
