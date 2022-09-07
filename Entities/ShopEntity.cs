using System.Data.Linq.Mapping;

namespace ShopManager.Entities
{
    [Table(Name = "Branches")]
    public class ShopEntity
    {
        [Column(Name = "Id", IsPrimaryKey = true, IsDbGenerated = true)]
        public long Id { get; set; }

        [Column(Name = "Name")]
        public string Name { get; set; }

        [Column(Name = "OwnerId")]
        public long OwnerId { get; set; }

        [Column(Name = "LocationId")]
        public long LocationId { get; set; }

        [Association(Name="Branch_Owner", ThisKey="OwnerId", IsForeignKey=true)]
        public EmployeeEntity Owner { get; set; }

        [Association(Name="Branch_Address", ThisKey="LocationId", IsForeignKey=true)]
        public AddressEntity Location { get; set; }
    }
}
