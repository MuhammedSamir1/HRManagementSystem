using HRManagementSystem.Data.Models.ConfigurationsModels;
using HRManagementSystem.Data.Models.Scopes;
using HRManagementSystem.Features.Common.AssignationManagement.AddAssignation.Orchestrator;
using HRManagementSystem.Features.Common.Dtos;

namespace HRManagementSystem.Features.Common.AssignationManagement.Mapping;

public class AddAssignationProfile : Profile
{
    public AddAssignationProfile()
    {
        CreateMap<AddAssignationOrchestratorCommand<ShiftScope>, ShiftScope>()
           // .ForMember(d => d.Id, opt => opt.Ignore())
            .ForMember(dest => dest.ShiftId, opt => opt.MapFrom(src => src.configId))
            .ForMember(dest => dest.ScopeId, opt => opt.MapFrom(src => src.scopeId));
        CreateMap<ShiftScope, CreatedIdDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
    }
}
