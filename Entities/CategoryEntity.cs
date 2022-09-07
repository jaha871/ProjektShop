using System.Data.Linq.Mapping;

namespace ShopManager.Entities
{
    [Table(Name = "Categories")]
    public class CategoryEntity
    {
        [Column(Name = "Id", IsPrimaryKey = true, IsDbGenerated = true)]
        public long Id { get; set; }

        [Column(Name = "Name")]
        public string Name { get; set; }

        [Column(Name = "Description")]
        public string Description { get; set; }
    }
}
