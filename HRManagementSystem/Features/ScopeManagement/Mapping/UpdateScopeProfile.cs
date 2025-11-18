using HRManagementSystem.Features.ScopeManagement.UpdateScope;
using HRManagementSystem.Features.ScopeManagement.UpdateScope.Commands;

namespace HRManagementSystem.Features.ScopeManagement.Mapping
{
    public class UpdateScopeProfile : Profile
    {
        public UpdateScopeProfile()
        {
            CreateMap<UpdateScopeViewModel, UpdateScopeCommand>();
        }
    }
}

