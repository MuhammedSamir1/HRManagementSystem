using HRManagementSystem.Data.Models.AddressEntity;

namespace HRManagementSystem.Data.Models
{
    public class Branch : BaseModel<int>
    {
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; } = default!;
        public string Code { get; set; } = default!;
        public Address Adress { get; set; } = default!;
        public ICollection<Department> Departments { get; set; } = new HashSet<Department>();
    }
}
