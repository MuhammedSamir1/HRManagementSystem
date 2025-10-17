namespace HRManagementSystem.Data.Models
{
    public sealed class Company : BaseModel<int>
    {
        public int OrganizationId { get; set; }
        public Organization Organization { get; set; } = null!;
        public string Name { get; set; } = default!;
        public string Code { get; set; } = default!;
        public string? Description { get; set; }

        public ICollection<Branch> Branches { get; set; } = new HashSet<Branch>();
    }
}
