using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace ShopManager.Entities
{
    [Table(Name = "Products")]
    public class ProductEntity
    {
        [Column(Name = "Id", IsPrimaryKey = true, IsDbGenerated = true)]
        public long Id { get; set; }

        [Column(Name = "Name")]
        public string Name { get; set; }

        [Column(Name = "Weight")]
        public double Weight { get; set; }

        [Column(Name = "Price")]
        public int Price { get; set; }

        [Column(Name = "Quantity")]
        public int Quantity { get; set; }

        [Column(Name = "Ean")]
        public string Ean { get; set; }

        [Column(Name = "CategoryId" , CanBeNull = true)]
        public long CategoryId { get; set; }

        [Column(Name = "ShopId" , CanBeNull = true)]
        public long ShopId { get; set; }

        internal EntityRef<CategoryEntity> _category;
        [Association(Name="Product_Category", ThisKey="CategoryId", Storage = "_category", IsForeignKey=true)]
        public CategoryEntity Category {
            get { return _category.Entity; }
            internal set {
                if (value == null) return;
                _category.Entity = value;
                CategoryId = value.Id;
            }
        }

        internal EntityRef<ShopEntity> _shop;
        [Association(Name="Product_Shop", ThisKey="ShopId", Storage = "_shop", IsForeignKey=true)]
        public ShopEntity Shop {
            get { return _shop.Entity; }
            internal set {
                if (value == null) return;
                _shop.Entity = value;
                ShopId = value.Id;
            }
        }

        public override string ToString()
        {
            return $"Product {{ Name = {Name ?? "null"}, Weight = {Weight}, Price = {Price}, Quantity = {Quantity}, Ean = {Ean ?? "null"}, Category = {Category?.Name ?? "null"}, Shop = {Shop?.Name ?? "null"} }}";
        }
    }
}
