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
using System.Windows.Navigation;
using MOTIVAR.pages;
using System.Diagnostics;

namespace MOTIVAR.pages
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void SubmitGrid_MouseEnter(object sender, MouseEventArgs e)
        {
            SubmitButtonImage.Opacity = 1;
        }

        private void SubmitGrid_MouseLeave(object sender, MouseEventArgs e)
        {
            SubmitButtonImage.Opacity = 0.7;
        }

        private void SubmitGrid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            SubmitText.Foreground = Brushes.DarkGray;
        }

        private void SubmitGrid_MouseUp(object sender, MouseButtonEventArgs e)//Click Login
        {
            SubmitText.Foreground = Brushes.Black;
            LoginSubmitted();
        }

        private void UsernameTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) PasswordTextBox.Focus();
        }

        private void PasswordTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) LoginSubmitted();
        }

        public void LoginSubmitted()
        {
            Debug.WriteLine("Login Submitted!");
        }
    }
}
