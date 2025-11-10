using HRManagementSystem.Data.Models.ConfigurationsModels;
using HRManagementSystem.Features.RequestTypeManagement.GetAllRequestTypes;

namespace HRManagementSystem.Features.RequestTypeManagement.Mapping
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

