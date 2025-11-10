using HRManagementSystem.Data.Models.ConfigurationsModels;
using HRManagementSystem.Features.ConfigurationsManagement.EndOfServiceManagement.GetEndOfServiceById;
using HRManagementSystem.Features.ConfigurationsManagement.EndOfServiceManagement.GetEndOfServiceById.Queries;

namespace HRManagementSystem.Features.ConfigurationsManagement.EndOfServiceManagement.Mapping
{
    public class GetEndOfServiceByIdProfile : Profile
    {
        public GetEndOfServiceByIdProfile()
        {
            CreateMap<GetEndOfServiceByIdViewModel, GetEndOfServiceByIdQuery>();
            CreateMap<EndOfService, ViewEndOfServiceByIdDto>();
            CreateMap<ViewEndOfServiceByIdDto, ViewEndOfServiceByIdViewModel>();
        }
    }
}
