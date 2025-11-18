using HRManagementSystem.Data.Models.Scopes;
using HRManagementSystem.Features.ScopeManagement.GetScopeById;
using HRManagementSystem.Features.ScopeManagement.GetScopeById.Queries;

namespace HRManagementSystem.Features.ScopeManagement.Mapping
{
    public class GetScopeByIdProfile : Profile
    {
        public GetScopeByIdProfile()
        {
            CreateMap<GetScopeByIdViewModel, GetScopeByIdQuery>();
            CreateMap<Scope, ViewScopeByIdDto>();
            CreateMap<ViewScopeByIdDto, ViewScopeByIdViewModel>();
        }
    }
}

