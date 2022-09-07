using System;
using ShopManager.Entities;
using System.Data.Linq;
using System.Windows;
using System.Collections.Generic;

namespace ShopManager
{
    public partial class App : Application
    {
        const string DatabaseConfig = @"Data Source=localhost;Initial Catalog=projectdb;Integrated Security=True";

        public static Table<AddressEntity> Addresses { get; private set; }
        public static Table<CategoryEntity> Categories { get; private set; }
        public static Table<EmployeeEntity> Employees { get; private set; }
        public static Table<ProductEntity> Products { get; private set; }
        public static Table<ShopEntity> Shops { get; private set; }

        public App() {
            ConnectWithDatabase();
        }

        private void ConnectWithDatabase()
        {
            using (DataContext dataContext = new DataContext(DatabaseConfig))
            {
                Addresses = dataContext.GetTable<AddressEntity>();
                Categories = dataContext.GetTable<CategoryEntity>();
                Employees = dataContext.GetTable<EmployeeEntity>();
                Products = dataContext.GetTable<ProductEntity>();
                Shops = dataContext.GetTable<ShopEntity>();

                MigrateDatabase(dataContext);

                Console.WriteLine($"Database ConnectionString: {dataContext.Connection.ConnectionString}.");
                dataContext.Dispose();
            }
        }

        private void MigrateDatabase(DataContext dataContext) {
            //  if (dataContext.DatabaseExists()) return;

            if (dataContext.DatabaseExists())
                dataContext.DeleteDatabase();

            dataContext.CreateDatabase();

            var categories = new List<CategoryEntity>() {
                new CategoryEntity() { Name = "Nabiał", Description = "Produkty mleczne" },
                new CategoryEntity() { Name = "Mięso", Description = "Produkty mięsne" },
                new CategoryEntity() { Name = "Owoce", Description = "Produkty owocowe" },
                new CategoryEntity() { Name = "Warzywa", Description = "Produkty warzywne" },
                new CategoryEntity() { Name = "Napoje", Description = "Produkty napoje" },
                new CategoryEntity() { Name = "Przyprawy", Description = "Produkty przyprawowe" },
                new CategoryEntity() { Name = "Detergenty", Description = "Produkty czystościowe" },
                new CategoryEntity() { Name = "Mrożonki", Description = "Produkty mrożone" },
                new CategoryEntity() { Name = "Pieczywo", Description = "Produkty piekarnicze" },
                new CategoryEntity() { Name = "Owoce morza", Description = "Produkty owoce morza" },
                new CategoryEntity() { Name = "Słodycze", Description = "Produkty słodkie" }
            };

            var addresses = new List<AddressEntity>() {
                new AddressEntity() { Street = "Koszykowa 1", City = "Warszawa", ZipCode = "00-001" , Country = "Poland", },
                new AddressEntity() { Street = "Kazimierza Wielkiego 22", City = "Lublin", ZipCode = "20-611", Country = "Poland" },
                new AddressEntity() { Street = "Kazimierza Deyny 61", City = "Warszawa", ZipCode = "01-471", Country = "Poland" },
                new AddressEntity() { Street = "Cybisa Jana 96", City = "Kędzierzyn-Koźle", ZipCode = "47-206", Country = "Poland" },
                new AddressEntity() { Street = "Skoczna 89", City = "Wrocław", ZipCode = "51-180", Country = "Poland" },
                new AddressEntity() { Street = "Kolejowa 94", City = "Zielona", ZipCode = "65-548", Country = "Poland" },
                new AddressEntity() { Street = "Solec 76", City = "Warszawa", ZipCode = "00-382", Country = "Poland" },
                new AddressEntity() { Street = "Solec 76", City = "Warszawa", ZipCode = "00-382", Country = "Poland" },
                new AddressEntity() { Street = "Lewicpolska 4", City = "Warszawa", ZipCode = "03-652", Country = "Poland" },
                new AddressEntity() { Street = "Centralna 101", City = "Szudziałowo", ZipCode = "16-113", Country = "Poland" },
                new AddressEntity() { Street = "Franki Iwana 81", City = "Wrocław", ZipCode = "51-348", Country = "Poland" },
                new AddressEntity() { Street = "Świętochowskiego Aleksandra 88", City = "Wrocław", ZipCode = "51-606", Country = "Poland" },
                new AddressEntity() { Street = "Lubartowska 116", City = "Lublin", ZipCode = "20-123", Country = "Poland" },
                new AddressEntity() { Street = "Uniejowska 94", City = "Łódź", ZipCode = "91-024", Country = "Poland" },
                new AddressEntity() { Street = "Klimontowska 10", City = "Warszawa", ZipCode = "04-672", Country = "Poland" },
                new AddressEntity() { Street = "Latawcowa 92", City = "Wrocław", ZipCode = "54-130", Country = "Poland" },
                new AddressEntity() { Street = "Sportowa 77", City = "Marki", ZipCode = "05-270", Country = "Poland" },
                new AddressEntity() { Street = "Ametystowa 61", City = "Poznań", ZipCode = "61-680", Country = "Poland" }
            };

            var shops = new List<ShopEntity>() {
                new ShopEntity() { Name = "Biedronka", LocationId = 1 },
                new ShopEntity() { Name = "Lidl", LocationId = 2 },
                new ShopEntity() { Name = "Auchan", LocationId = 3 },
            };

            var employess = new List<EmployeeEntity>() {
                new EmployeeEntity() { Name = "Jan", Surname = "Kowalski", AddressId = 4, BranchId = 1 },
                new EmployeeEntity() { Name = "Adam", Surname = "Januszowski", AddressId = 5, BranchId = 2 },
                new EmployeeEntity() { Name = "Mirosław", Surname = "Czerwiński", AddressId = 6, BranchId = 3 },
            };

            var products = new List<ProductEntity>() {
                new ProductEntity() { Name = "Kajzerka", Weight = 1, Price = 35, Ean = "5900531001130", CategoryId = 1, ShopId = 1 },
                new ProductEntity() { Name = "Piątnica Śmietana do zupy 18%", Weight = 0.2, Price = 229, Ean = "5900512320427", CategoryId = 9, ShopId = 1 },
                new ProductEntity() { Name = "Łaciate Mleko świeże 3,2 %", Weight = 1, Price = 379, Ean = "2345678901234", CategoryId = 1, ShopId = 2 },
                new ProductEntity() { Name = "Carrefour Classic Masło ekstra", Weight = 0.2, Price = 729, Ean = "2345678901234", CategoryId = 1, ShopId = 3 },
                new ProductEntity() { Name = "Piątnica Serek wiejski naturalny", Weight = 0.2, Price = 239, Ean = "2345678901234", CategoryId = 1, ShopId = 3 },
                new ProductEntity() { Name = "Pomidory malinowe ważone", Weight = 1, Price = 200, Ean = "2345678901234", CategoryId = 4, ShopId = 3 },
                new ProductEntity() { Name = "Simply Marchew z polskich upraw", Weight = 1, Price = 299, Ean = "2345678901234", CategoryId = 4, ShopId = 2 },
            };
            
            Categories.InsertAllOnSubmit(categories);
            Addresses.InsertAllOnSubmit(addresses);
            Shops.InsertAllOnSubmit(shops);
            Employees.InsertAllOnSubmit(employess);
            Products.InsertAllOnSubmit(products);
     
            dataContext.SubmitChanges();

            shops[0].OwnerId = 1;
            shops[1].OwnerId = 2;
            shops[2].OwnerId = 3;

            dataContext.SubmitChanges();
        }
    }
}
