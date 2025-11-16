using HRManagementSystem.Data.Models.AddressEntity;

namespace HRManagementSystem.Data.Models
{
    public class Branch : BaseModel<Guid>
    {
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public Guid CompanyId { get; set; }
        public Company Company { get; set; } = default!;
        public string Code { get; set; } = default!;
        public Guid AddressId { get; set; }
        public Address Address { get; set; } = default!;
        public ICollection<Department> Departments { get; set; } = new HashSet<Department>();
    }
}
