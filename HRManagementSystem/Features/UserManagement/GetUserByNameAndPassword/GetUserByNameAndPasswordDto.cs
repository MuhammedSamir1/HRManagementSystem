namespace HRManagementSystem.Features.UserManagement.GetUserByNameAndPassword
{
    public class GetUserByNameAndPasswordDto
    {
        public Guid userId { get; set; }
        public string Username { get; set; } = null!;
        public Guid RoleId { get; set; }
        public string RoleName { get; set; } = null!;
    }
}
