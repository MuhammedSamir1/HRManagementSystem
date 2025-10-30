namespace HRManagementSystem.Data.Models
{
    public class User : BaseModel<Guid>
    {
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public Guid RoleId { get; set; }
        public Role? Role { get; set; }
    }
}
