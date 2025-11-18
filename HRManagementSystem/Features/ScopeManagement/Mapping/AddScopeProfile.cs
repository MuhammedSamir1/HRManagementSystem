using HRManagementSystem.Data.Models.Scopes;
using HRManagementSystem.Features.ScopeManagement.AddScope;
using HRManagementSystem.Features.ScopeManagement.AddScope.Commands;

namespace HRManagementSystem.Features.ScopeManagement.Mapping
{
    public class AddScopeProfile : Profile
    {
        public AddScopeProfile()
        {
            CreateMap<AddScopeViewModel, AddScopeCommand>();
            CreateMap<AddScopeCommand, Scope>();
        }
    }
}

