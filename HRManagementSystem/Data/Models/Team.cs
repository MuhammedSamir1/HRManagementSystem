namespace HRManagementSystem.Data.Models
{
    public sealed class Team : BaseModel<int>
    {
        public int DepartmentId { get; set; }
        public Department Department { get; set; } = default!;
        public string Name { get; set; } = default!;
        public string Code { get; set; } = default!;
        public string? Description { get; set; }
    }
}
