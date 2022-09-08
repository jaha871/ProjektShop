using System.Data.Linq;
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

        [Column(Name = "BranchId", CanBeNull = true)]
        public long? BranchId { get; set; }

        [Column(Name = "AddressId", CanBeNull = true)]
        public long? AddressId { get; set; }

        internal EntityRef<ShopEntity> _branch;
        [Association(Name="Employee_Branch", ThisKey="BranchId", Storage = "_branch", IsForeignKey=true)]
        public ShopEntity Branch {
            get { return _branch.Entity; }
            internal set {
                if (value == null) return;
                _branch.Entity = value;
                BranchId = value.Id;
            }
        }

        internal EntityRef<AddressEntity> _address;
        [Association(Name="Employee_Address", ThisKey="AddressId", Storage = "_address", IsForeignKey=true)]
        public AddressEntity Address {
            get { return _address.Entity; }
            internal set {
                if (value == null) return;
                _address.Entity = value;
                AddressId = value.Id;
            }
        }

        public string FullAddress {
            set { }
            get {
                if (Address == null) return string.Empty;
                return $"{Address.Street}, {Address.City}\n{Address.ZipCode} {Address.Country}";
            }
        }
    }
}
