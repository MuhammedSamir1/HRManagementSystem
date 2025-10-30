namespace HRManagementSystem.Data.Models
{
    public class RoleFeature : BaseModel<Guid>
    {
        public Guid RoleId { get; set; }
        public Role? Role { get; set; }

        public Feature Feature { get; set; }
    }
}
