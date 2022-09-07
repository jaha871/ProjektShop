using System.Data.Linq.Mapping;

namespace ShopManager.Entities
{
    [Table(Name = "Addresses")]
    public class AddressEntity
    {
        [Column(Name = "Id", IsPrimaryKey = true, IsDbGenerated = true)]
        public long Id { get; set; }

        [Column(Name = "Street")]
        public string Street { get; set; }

        [Column(Name = "City")]
        public string City { get; set; }

        [Column(Name = "Country")]
        public string Country { get; set; }
        [Column(Name = "Zip_Code")]
        public string ZipCode {get; set; }
    }
}
