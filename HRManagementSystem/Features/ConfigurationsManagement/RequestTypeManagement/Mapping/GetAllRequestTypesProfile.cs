using HRManagementSystem.Data.Models.ConfigurationsModels;
using HRManagementSystem.Features.ConfigurationsManagement.RequestTypeManagement.GetAllRequestTypes;

namespace HRManagementSystem.Features.ConfigurationsManagement.RequestTypeManagement.Mapping
{
    public sealed class GetAllRequestTypesProfile : Profile
    {
        public GetAllRequestTypesProfile()
        {
            CreateMap<RequestType, GetAllRequestTypesDto>();
            CreateMap<GetAllRequestTypesDto, GetAllRequestTypesResponseViewModel>();
        }
    }
}

