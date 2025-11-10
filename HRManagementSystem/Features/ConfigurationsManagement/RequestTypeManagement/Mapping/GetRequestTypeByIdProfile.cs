using HRManagementSystem.Data.Models.ConfigurationsModels;
using HRManagementSystem.Features.ConfigurationsManagement.RequestTypeManagement.GetRequestTypeById;

namespace HRManagementSystem.Features.ConfigurationsManagement.RequestTypeManagement.Mapping
{
    public sealed class GetRequestTypeByIdProfile : Profile
    {
        public GetRequestTypeByIdProfile()
        {
            CreateMap<RequestType, GetRequestTypeByIdDto>();
            CreateMap<GetRequestTypeByIdDto, GetRequestTypeByIdResponseViewModel>();
        }
    }
}

