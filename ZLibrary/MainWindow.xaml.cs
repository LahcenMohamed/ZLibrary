using MaterialDesignThemes.Wpf;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ZLibrary.Models;
using ZLibrary.View.ViewModels;

namespace ZLibrary.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BookVM bookVM = new BookVM();
        public bool IsDarkTheme { get; set; }

        private readonly PaletteHelper paletteHelper = new PaletteHelper();
        public MainWindow()
        {
            InitializeComponent();
            ITheme theme = paletteHelper.GetTheme();
            IsDarkTheme = true;
            theme.SetBaseTheme(Theme.Dark);
            paletteHelper.SetTheme(theme);
            DataContext = bookVM;
        }
        private void btu_Exit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
        private void btu_min_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void btu_dark_Click(object sender, RoutedEventArgs e)
        {
            ITheme theme = paletteHelper.GetTheme();
            if (IsDarkTheme = theme.GetBaseTheme() == BaseTheme.Dark)
            {
                IsDarkTheme = false;
                theme.SetBaseTheme(Theme.Light);
            }
            else
            {
                IsDarkTheme = true;
                theme.SetBaseTheme(Theme.Dark);
            }

            paletteHelper.SetTheme(theme);
        }
        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Trigger the search as the text changes
            ((BookVM)DataContext).Search = ((TextBox)sender).Text;
            data_client.ItemsSource = ((BookVM)DataContext).Books;
        }
    }
}