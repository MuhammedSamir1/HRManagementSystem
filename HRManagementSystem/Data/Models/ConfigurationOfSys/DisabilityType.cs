namespace HRManagementSystem.Data.Models.ConfigurationOfSys
{
    public class DisabilityType : BaseModel<int>
    {
        public required string Name { get; set; }
        public string? Description { get; set; }
        public string? Code { get; set; }

        // Navigation property for employees (if needed)
        public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
}
