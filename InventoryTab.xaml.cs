using ShopManager.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ShopManager
{
    public partial class InventoryTab : Page
    {
        public ObservableCollection<ProductEntity> Products { get; set; } = new ObservableCollection<ProductEntity>();
        public ObservableCollection<string> Categories { get; set; } = new ObservableCollection<string>();
        public ObservableCollection<string> Shops { get; set; } = new ObservableCollection<string>();

        private List<ProductEntity> _removedProducts = new List<ProductEntity>();
        private List<ProductEntity> _addedProducts = new List<ProductEntity>();
        private List<ProductEntity> _modifiedProducts = new List<ProductEntity>();

        private bool _isDataChanged = false;

        public InventoryTab() =>
            InitializeComponent();

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            itemGrid.ItemsSource = Products;
            LoadData();
        }

        private void itemGrid_PreviewCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            DataGrid grid = (DataGrid)sender;
            if (e.Command == DataGrid.DeleteCommand)
            {
                if (MessageBox.Show(String.Format("Would you like to delete {0}?", (grid.SelectedItem as ProductEntity).Name), "Confirm Delete", MessageBoxButton.OKCancel) == MessageBoxResult.OK) {
                    _removedProducts.Add(grid.SelectedItem as ProductEntity);
                    _isDataChanged = true;
                } else {
                    e.Handled = true;
                }
            }
            if (e.Command == DataGrid.BeginEditCommand)
            {
                Console.WriteLine("BeginEditCommand");
                _isDataChanged = true;
            }

            if (e.Command == DataGrid.CommitEditCommand)
            {
                Console.WriteLine("CommitEditCommand");
                _isDataChanged = true;
            }
        }

        private void AddNewProduct_Click(object sender, RoutedEventArgs e)
        {
            if (IsProductValid(Products.Last()))
            {
                Save();
                var product = new ProductEntity();
                Products.Add(product);
                _addedProducts.Add(product);
                _isDataChanged = true;
            }
        }

        private void Reload_Click(object sender, RoutedEventArgs e) => LoadData();

        private void Save_Click(object sender, RoutedEventArgs e) => Save();

        private void LoadData()
        {
            Products.Clear();
            Categories.Clear();
            Shops.Clear();

            foreach (var product in App.Products)
                Products.Add(product);

            foreach (var category in App.Categories)
                Categories.Add(category.Name);

            foreach (var shop in App.Shops)
                Shops.Add(shop.Name);
        }

        private void Save()
        {
            if (!_isDataChanged) return;
            DisableEverything();

            foreach (var product in _removedProducts) {
                var toRemove = App.Products.FirstOrDefault(p => p.Id == product.Id);
                Console.WriteLine("Removing product: " + toRemove?.Name);
                App.Products.DeleteOnSubmit(toRemove);
            }

            foreach (var product in _addedProducts) {
                if (IsProductValid(product, true)) {
                    Console.WriteLine("Adding product: " + product.Name);
                    App.Products.InsertOnSubmit(product);
                }
            }

            if(App.DataContext != null)
                App.DataContext.SubmitChanges();

            _removedProducts.Clear();
            _addedProducts.Clear();
            _modifiedProducts.Clear();

            _isDataChanged = false;
            EnableEverything();
        }

        private bool ShowError(string msg)
        {
            MessageBox.Show(msg, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            return false;
        }

        private bool IsProductValid(ProductEntity product)
        {
            return !string.IsNullOrWhiteSpace(product.Name) &&
                product.Weight > 0 &&
                product.Price > 0 &&
                product.Quantity > 0 &&
                !string.IsNullOrWhiteSpace(product.Ean) &&
                product.Category != null &&
                product.Shop != null;
        }

        private bool IsProductValid(ProductEntity product, bool showError)
        {
            if (!showError) return IsProductValid(product);

            if (string.IsNullOrWhiteSpace(product.Name))
                return ShowError("Please enter a name of the product.");
            else if (product.Weight <= 0)
                return ShowError("Please enter a weight of the product.");
            else if (product.Price <= 0)
                return ShowError("Please enter a price of the product.");
            else if (product.Quantity <= 0)
                return ShowError("Please enter a quantity of the product.");
            else if (string.IsNullOrWhiteSpace(product.Ean))
                return ShowError("Please enter an EAN of the product.");
            else if (product.Category == null)
                return ShowError("Please select a category of the product.");
            else if (product.Shop == null)
                return ShowError("Please select a shop of the product.");

            return true;
        }

        private void DisableEverything()
        {
            itemGrid.IsEnabled = false;
            addNewProduct.IsEnabled = false;
            reload.IsEnabled = false;
            save.IsEnabled = false;
        }

        private void EnableEverything()
        {
            itemGrid.IsEnabled = true;
            addNewProduct.IsEnabled = true;
            reload.IsEnabled = true;
            save.IsEnabled = true;
        }

        private void Category_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var comboBox = sender as ComboBox;
            var product = this.itemGrid.CurrentItem as ProductEntity;
            var category = comboBox.SelectedItem as string;

            if (product != null)
                product.Category = App.Categories.FirstOrDefault(c => c.Name == category);
        }

        private void Shop_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var comboBox = sender as ComboBox;
            var product = this.itemGrid.CurrentItem as ProductEntity;
            var shop = comboBox.SelectedItem as string;

            if (product != null)
                product.Shop = App.Shops.FirstOrDefault(c => c.Name == shop);
        }
    }
}
