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

        [Column(Name = "Ean")]
        public string Ean { get; set; }

        [Column(Name = "CategoryId" , CanBeNull = true)]
        public long CategoryId { get; set; }

        [Column(Name = "ShopId" , CanBeNull = true)]
        public long ShopId { get; set; }

        [Association(Name="Product_Category", ThisKey="CategoryId", IsForeignKey=true)]
        public CategoryEntity Category { get; set; }

        [Association(Name="Product_Shop", ThisKey="ShopId", IsForeignKey=true)]
        public ShopEntity Shop { get; set; }
    }
}
