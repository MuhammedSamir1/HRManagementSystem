
using HRManagementSystem.Features.RoleManagement.AddRole.Commands;

namespace HRManagementSystem.Features.RoleManagement.AddRole.Mapping
{
    public class AddRoleProfile : Profile
    {
        public AddRoleProfile()
        {
            CreateMap<AddRoleCommand, Role>();
        }
    }
}
