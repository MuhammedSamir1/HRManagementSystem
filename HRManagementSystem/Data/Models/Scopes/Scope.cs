using System.Collections.ObjectModel;

namespace HRManagementSystem.Data.Models.Scopes
{
    public class Scope : BaseModel<Guid>
    {
        public Guid OrganizationId { get; set; }
        public Guid CompanyId { get; set; }
        public Guid? BranchId { get; set; }
        public Guid? DepartmentId { get; set; }
        public Guid? TeamId { get; set; }

        public ICollection<ShiftScope> ShiftScopes { get; set; } = new Collection<ShiftScope>();
    }
}

