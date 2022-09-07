using System.Data.Linq.Mapping;

namespace ShopManager.Entities
{
    [Table(Name = "Employees")]
    public class EmployeeEntity
    {
        [Column(Name = "Id", IsPrimaryKey = true, IsDbGenerated = true)]
        public long Id { get; set; }

        [Column(Name = "Name")]
        public string Name { get; set; }

        [Column(Name = "Surname")]
        public string Surname { get; set; }

        [Column(Name = "BranchId")]
        public long BranchId { get; set; }

        [Column(Name = "AddressId")]
        public long AddressId { get; set; }

        [Association(Name="Employee_Branch", ThisKey="BranchId", IsForeignKey=true)]
        public ShopEntity Branch { get; set; }

        [Association(Name="Employee_Address", ThisKey="AddressId", IsForeignKey=true)]
        public AddressEntity Address { get; set; }
    }
}
