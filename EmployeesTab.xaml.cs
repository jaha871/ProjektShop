using ShopManager.Entities;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System;
using System.Linq;

namespace ShopManager
{
    public partial class EmployeesTab : Page
    {
        public ObservableCollection<EmployeeEntity> Employees { get; set; } = new ObservableCollection<EmployeeEntity>();
        public ObservableCollection<string> Addresses { get; set; } = new ObservableCollection<string>();
        public ObservableCollection<string> Shops { get; set; } = new ObservableCollection<string>();

        private List<EmployeeEntity> _removedEmployees = new List<EmployeeEntity>();
        private List<EmployeeEntity> _addedEmployees = new List<EmployeeEntity>();
        private List<EmployeeEntity> _modifiedEmployees = new List<EmployeeEntity>();

        private bool _isDataChanged = false;

        public EmployeesTab() =>
            InitializeComponent();

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            itemGrid.ItemsSource = Employees;
            LoadData();
        }

        private void AddNewEmployee_Click(object sender, RoutedEventArgs e)
        {
            if (IsEmployeeValid(Employees.Last()))
            {
                Save();
                var employee = new EmployeeEntity();
                Employees.Add(employee);
                _addedEmployees.Add(employee);
                _isDataChanged = true;
            }
        }

        private void Reload_Click(object sender, RoutedEventArgs e) => LoadData();

        private void Save_Click(object sender, RoutedEventArgs e) => Save();

        private void LoadData()
        {
            Employees.Clear();
            Addresses.Clear();
            Shops.Clear();

            foreach (var employee in App.Employees)
                Employees.Add(employee);

            foreach (var address in App.Addresses)
                Addresses.Add($"{address.Street}, {address.City}\n{address.ZipCode} {address.Country}");

            foreach (var shop in App.Shops)
                Shops.Add(shop.Name);
        }

        private void Save()
        {
            if (!_isDataChanged) return;
            Console.WriteLine("Saving data...");
            DisableEverything();

            foreach (var employee in _addedEmployees) {
                if (IsEmployeeValid(employee, true)) {
                    Console.WriteLine("Adding employee: " + employee.Name);
                    App.Employees.InsertOnSubmit(employee);
                }
            }

            App.DataContext.SubmitChanges();

            
            _addedEmployees.Clear();
            _modifiedEmployees.Clear();

            _isDataChanged = false;
            EnableEverything();
            Console.WriteLine("Data saved.");
        }

        private bool ShowError(string msg)
        {
            MessageBox.Show(msg, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            return false;
        }

        private bool IsEmployeeValid(EmployeeEntity employee)
        {
            return !string.IsNullOrWhiteSpace(employee.Name) &&
                !string.IsNullOrWhiteSpace(employee.Surname) &&
                employee.Branch != null &&
                employee.Address != null;
        }

        private bool IsEmployeeValid(EmployeeEntity employee, bool showError)
        {
            if (!showError) return IsEmployeeValid(employee);

            if (string.IsNullOrWhiteSpace(employee.Name))
                return ShowError("Please enter a name of the employee.");
            else if (string.IsNullOrWhiteSpace(employee.Surname))
                return ShowError("Please enter a surname of the employee.");
            else if (employee.Branch == null)
                return ShowError("Please select a branch of the employee.");
            else if (employee.Address == null)
                return ShowError("Please select a address of the employee.");

            return true;
        }

        private void DisableEverything()
        {
            itemGrid.IsEnabled = false;
            addNewEmployee.IsEnabled = false;
            reload.IsEnabled = false;
            save.IsEnabled = false;
        }

        private void EnableEverything()
        {
            itemGrid.IsEnabled = true;
            addNewEmployee.IsEnabled = true;
            reload.IsEnabled = true;
            save.IsEnabled = true;
        }

        private void Branch_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var comboBox = sender as ComboBox;
            var employee = this.itemGrid.CurrentItem as EmployeeEntity;
            var branch = comboBox.SelectedItem as string;

            if (employee != null)
                employee.Branch = App.Shops.FirstOrDefault(c => c.Name == branch);
        }

        private void Address_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var comboBox = sender as ComboBox;
            var employee = this.itemGrid.CurrentItem as EmployeeEntity;
            var address = comboBox.SelectedItem as string;
            var street = address.Split(',')[0].Trim();
            var city = address.Split(',')[1].Split('\n')[0].Trim();

            if (employee != null)
                employee.Address = App.Addresses.FirstOrDefault(c => c.Street == street && c.City == city);
        }
    }
}
