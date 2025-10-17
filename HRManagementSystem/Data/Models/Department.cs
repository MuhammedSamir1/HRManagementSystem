namespace HRManagementSystem.Data.Models
{
    public class Department : BaseModel<int>
    {
        public string Name { get; set; } = default!;
        public string Code { get; set; } = default!;
        public string? Description { get; set; }
        public int BranchId { get; set; }
        public Branch Branch { get; set; } = null!;

        public ICollection<Team> Teams { get; set; } = new HashSet<Team>();

    }
}
