using ShopManager.Entities;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;


namespace ShopManager
{
    public partial class InventoryTab : Page
    {
        public ObservableCollection<ProductEntity> Products { get; set; } = new ObservableCollection<ProductEntity>();
        public ObservableCollection<ShopEntity> Shops { get; set; } = new ObservableCollection<ShopEntity>();

        public InventoryTab() =>
            InitializeComponent();

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            itemGrid.ItemsSource = Products;
            Products.Clear();

            var category = new CategoryEntity() { Id = 1, Name = "Nabiał", Description = "A" };
            var address = new AddressEntity() { Id = 1, Street = "Ulicowa 16", City = "Miasto", Country = "Polska" };
            var employee = new EmployeeEntity() { Id = 1, Name = "Andrew", Surname = "Barski", Address = address, Branch = new ShopEntity() };

            Shops.Add(new ShopEntity() { Id = 1, Name = "Carrefour Market", Owner = employee, Location = address });

            employee.Branch = Shops.First();

            Products.Add(new ProductEntity()
            {
                Id = 0,
                Name = "Piątnica Śmietana do zupy 18%",
                Category = category,
                Weight = 0.2,
                Price = 229,
                Shop = Shops.First(),
                Ean = "5900531001130"
            });

            Products.Add(new ProductEntity()
            {
                Id = 1,
                Name = "Mlekovita Twój Kubek Mleko UHT 2%",
                Category = category,
                Weight = 1,
                Price = 369,
                Shop = Shops.First(),
                Ean = "5900512320427"
            });
            Products.Add(new ProductEntity()
            {
                
               
            });
        }
    }
}
