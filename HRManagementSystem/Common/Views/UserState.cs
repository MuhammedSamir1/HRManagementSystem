namespace HRManagementSystem.Common.Views
{
    public class UserState
    {
        public Guid UserId { get; set; }
        public string Name { get; set; } = null!;
        public Guid RoleId { get; set; }
    }
}
