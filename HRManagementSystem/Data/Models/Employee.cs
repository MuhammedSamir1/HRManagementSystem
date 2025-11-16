namespace HRManagementSystem.Data.Models
{
    public class Employee : BaseModel<Guid>
    {
        public string Name { get; set; } = null!;
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Position { get; set; }
        public DateTime? HireDate { get; set; }
    }
}
