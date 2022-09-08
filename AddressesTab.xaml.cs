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

namespace ShopManager
{
    public partial class AddressesTab : Page
    {
        public AddressesTab() =>
            InitializeComponent();

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            // itemGrid.ItemsSource = Employees;
            LoadData();
        }

        private void itemGrid_PreviewCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {

        }

        private void AddNewAddress_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Reload_Click(object sender, RoutedEventArgs e) => LoadData();

        private void Save_Click(object sender, RoutedEventArgs e) => Save();

        private void LoadData()
        {

        }

        private void Save()
        {

        }
    }
}
