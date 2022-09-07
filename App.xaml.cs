using System;
using ShopManager.Entities;
using System.Data.Linq;
using System.Windows;

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
            }
        }

        private void MigrateDatabase(DataContext dataContext) {
             if (dataContext.DatabaseExists())
                dataContext.ExecuteCommand("DELETE FROM Categories");
                dataContext.ExecuteCommand("DELETE FROM Addresses");
                dataContext.ExecuteCommand("DELETE FROM Branches");
                dataContext.ExecuteCommand("DELETE FROM Employees");
      

            //dataContext.CreateDatabase();



            Categories.InsertOnSubmit(new CategoryEntity() { Name = "Nabiał", Description = "Produkty mleczne" });
            Categories.InsertOnSubmit(new CategoryEntity() { Name = "Mięso", Description = "Produkty mięsne" });
            Categories.InsertOnSubmit(new CategoryEntity() { Name = "Owoce", Description = "Produkty owocowe" });
            Categories.InsertOnSubmit(new CategoryEntity() { Name = "Warzywa", Description = "Produkty warzywne" });
            Categories.InsertOnSubmit(new CategoryEntity() { Name = "Napoje", Description = "Produkty napoje" });
            Categories.InsertOnSubmit(new CategoryEntity() { Name = "Przyprawy", Description = "Produkty przyprawowe" });
            Categories.InsertOnSubmit(new CategoryEntity() { Name = "Detergenty", Description = "Produkty czystościowe" });
            Categories.InsertOnSubmit(new CategoryEntity() { Name = "Mrożonki", Description = "Produkty mrożone" });
            Categories.InsertOnSubmit(new CategoryEntity() { Name = "Pieczywo", Description = "Produkty piekarnicze" });
            Categories.InsertOnSubmit(new CategoryEntity() { Name = "Owoce morza", Description = "Produkty owoce morza" });
            Categories.InsertOnSubmit(new CategoryEntity() { Name = "Słodycze", Description = "Produkty słodkie" });

            Addresses.InsertOnSubmit(new AddressEntity() { Street = "Koszykowa 1", City = "Warszawa", ZipCode = "00-001" , Country = "Poland", });
            Addresses.InsertOnSubmit(new AddressEntity() { Street = "Kazimierza Wielkiego 22", City = "Lublin", ZipCode = "20-611", Country = "Poland" });
            Addresses.InsertOnSubmit(new AddressEntity() { Street = "Kazimierza Deyny 61", City = "Warszawa", ZipCode = "01-471", Country = "Poland" });
            Addresses.InsertOnSubmit(new AddressEntity() { Street = "Cybisa Jana 96", City = "Kędzierzyn-Koźle", ZipCode = "47-206", Country = "Poland" });
            Addresses.InsertOnSubmit(new AddressEntity() { Street = "Skoczna 89", City = "Wrocław", ZipCode = "51-180", Country = "Poland" });
            Addresses.InsertOnSubmit(new AddressEntity() { Street = "Kolejowa 94", City = "Zielona", ZipCode = "65-548", Country = "Poland" });
            
            Addresses.InsertOnSubmit(new AddressEntity() { Street = "Solec 76", City = "Warszawa", ZipCode = "00-382", Country = "Poland" });
            Addresses.InsertOnSubmit(new AddressEntity() { Street = "Solec 76", City = "Warszawa", ZipCode = "00-382", Country = "Poland" });
            Addresses.InsertOnSubmit(new AddressEntity() { Street = "Lewicpolska 4", City = "Warszawa", ZipCode = "03-652", Country = "Poland" });
            Addresses.InsertOnSubmit(new AddressEntity() { Street = "Centralna 101", City = "Szudziałowo", ZipCode = "16-113", Country = "Poland" });
            Addresses.InsertOnSubmit(new AddressEntity() { Street = "Franki Iwana 81", City = "Wrocław", ZipCode = "51-348", Country = "Poland" });
            Addresses.InsertOnSubmit(new AddressEntity() { Street = "Świętochowskiego Aleksandra 88", City = "Wrocław", ZipCode = "51-606", Country = "Poland" });

            Addresses.InsertOnSubmit(new AddressEntity() { Street = "Lubartowska 116", City = "Lublin", ZipCode = "20-123", Country = "Poland" });
            Addresses.InsertOnSubmit(new AddressEntity() { Street = "Uniejowska 94", City = "Łódź", ZipCode = "91-024", Country = "Poland" });
            Addresses.InsertOnSubmit(new AddressEntity() { Street = "Klimontowska 10", City = "Warszawa", ZipCode = "04-672", Country = "Poland" });
            Addresses.InsertOnSubmit(new AddressEntity() { Street = "Latawcowa 92", City = "Wrocław", ZipCode = "54-130", Country = "Poland" });
            Addresses.InsertOnSubmit(new AddressEntity() { Street = "Sportowa 77", City = "Marki", ZipCode = "05-270", Country = "Poland" });
            Addresses.InsertOnSubmit(new AddressEntity() { Street = "Ametystowa 61", City = "Poznań", ZipCode = "61-680", Country = "Poland" });

            Shops.InsertOnSubmit(new ShopEntity() { Name = "Biedronka", OwnerId = 1, LocationId = 1 });

            Employees.InsertOnSubmit(new EmployeeEntity() { Name = "Jan", Surname = "Kowalski", AddressId = 1, BranchId = 1 });

            dataContext.SubmitChanges();
        }
    }
}
