﻿using MOTIVAR.pages.submenu;
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

namespace MOTIVAR.pages
{
    /// <summary>
    /// Interaction logic for Sales.xaml
    /// </summary>
    public partial class Sales : UserControl
    {
        public Sales()
        {
            InitializeComponent();
        }

        private void CalculateSalesButton_Click(object sender, RoutedEventArgs e)
        {
            Calculate calculate = new Calculate();
            calculate.Show();
        }
    }
}
