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
using ZLibrary.Models;
using ZLibrary.View.ViewModels;

namespace ZLibrary.View
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        private bool _ispass = true;
        public UserVM userVM;
        public Login()
        {
            InitializeComponent();
            userVM = new UserVM(this);
            DataContext = userVM;
        }

        private void passwordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (_ispass)
            {
                TextPassordBox.Text = passwordBox.Password;
                userVM.Password = TextPassordBox.Text;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (_ispass)
            {
                TextPassordBox.Visibility = Visibility.Visible;
                passwordBox.Visibility = Visibility.Hidden;
            }
            else 
            {
                passwordBox.Visibility = Visibility.Visible;
                TextPassordBox.Visibility = Visibility.Hidden;
            }
            _ispass = !_ispass;
        }

        private void TextPassordBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!_ispass)
            {
                passwordBox.Password = TextPassordBox.Text;
                userVM.Password = TextPassordBox.Text;
            }
        }
    }
}
