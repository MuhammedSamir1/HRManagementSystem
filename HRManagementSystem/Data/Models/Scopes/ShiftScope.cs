using HRManagementSystem.Data.Models.ConfigurationsModels;

namespace HRManagementSystem.Data.Models.Scopes
{
    public class ShiftScope : BaseModel<Guid>
    {
        public Guid ShiftId { get; set; }
        public Guid ScopeId { get; set; }

        public Shift Shift { get; set; } = null!;
        public Scope Scope { get; set; } = null!;
    }
}

