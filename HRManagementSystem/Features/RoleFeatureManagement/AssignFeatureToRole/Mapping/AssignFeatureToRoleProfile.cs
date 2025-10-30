using HRManagementSystem.Features.RoleFeatureManagement.AssignFeatureToRole.Commands;

namespace HRManagementSystem.Features.RoleFeatureManagement.AssignFeatureToRole.Mapping
{
    public class AssignFeatureToRoleProfile : Profile
    {
        public AssignFeatureToRoleProfile()
        {
            CreateMap<AssignFeatureToRoleCommand, RoleFeature>();
        }
    }
}
