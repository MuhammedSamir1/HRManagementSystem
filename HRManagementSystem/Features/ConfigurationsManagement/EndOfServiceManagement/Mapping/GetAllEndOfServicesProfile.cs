using HRManagementSystem.Data.Models.ConfigurationsModels;
using HRManagementSystem.Features.ConfigurationsManagement.EndOfServiceManagement.GetAllEndOfServices;
using HRManagementSystem.Features.ConfigurationsManagement.EndOfServiceManagement.GetAllEndOfServices.Queries;

namespace HRManagementSystem.Features.ConfigurationsManagement.EndOfServiceManagement.Mapping
{
    public class GetAllEndOfServicesProfile : Profile
    {
        public GetAllEndOfServicesProfile()
        {
            CreateMap<GetAllEndOfServicesViewModel, GetAllEndOfServicesQuery>();
            CreateMap<EndOfService, ViewEndOfServiceDto>();
            CreateMap<ViewEndOfServiceDto, ViewEndOfServiceViewModel>();
        }
    }
}
