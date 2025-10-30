namespace HRManagementSystem.Data.Models
{
    public class Role : BaseModel<Guid>
    {
        public string Name { get; set; } = null!;
    }
}
