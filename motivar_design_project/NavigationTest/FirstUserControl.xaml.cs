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

namespace NavigationTest
{
    /// <summary>
    /// Interaction logic for FirstUserControl.xaml
    /// </summary>
    public partial class FirstUserControl : UserControl
    {
        public FirstUserControl()
        {
            InitializeComponent();

            UCGrid.Children.Add(new TextBlock{Text = "TEST Text User Control" ,
                                              HorizontalAlignment = HorizontalAlignment.Center,
                                              VerticalAlignment = VerticalAlignment.Center,
                                              FontSize = 28
                                });
        }
    }
}
