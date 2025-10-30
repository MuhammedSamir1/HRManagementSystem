namespace HRManagementSystem.Data.Models
{
    public class Employee : BaseModel<Guid>
    {
        public string Name { get; set; } = null!;
    }
}
