using HRManagementSystem.Features.RequestTypeManagement.GetRequestTypeById;

namespace HRManagementSystem.Features.RequestTypeManagement.Mapping
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

