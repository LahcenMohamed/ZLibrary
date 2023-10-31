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
using ZLibrary.View.ViewModels;

namespace ZLibrary.View.Views
{
    /// <summary>
    /// Interaction logic for Add_EditBooks.xaml
    /// </summary>
    public partial class Add_EditBooks : Window
    {
        private BookVM bookvm;

        public Add_EditBooks(BookVM bookVM)
        {
            InitializeComponent();
            bookvm = bookVM;
            DataContext = bookvm;
            string? categoryName = bookvm.CategoryName;
            com.SelectedItem = categoryName;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            bookvm.CategoryName = com.SelectedItem.ToString();
        }
    }
}
