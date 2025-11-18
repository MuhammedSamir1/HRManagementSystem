using HRManagementSystem.Data.Models.Scopes;
using HRManagementSystem.Features.ScopeManagement.GetAllScopes;
using HRManagementSystem.Features.ScopeManagement.GetAllScopes.Queries;

namespace HRManagementSystem.Features.ScopeManagement.Mapping
{
    public class GetAllScopesProfile : Profile
    {
        public GetAllScopesProfile()
        {
            CreateMap<GetAllScopesViewModel, GetAllScopesQuery>();
            CreateMap<Scope, ViewScopeDto>();
            CreateMap<ViewScopeDto, ViewScopeViewModel>();
        }
    }
}

