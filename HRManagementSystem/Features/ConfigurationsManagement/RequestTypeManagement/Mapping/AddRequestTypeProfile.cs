using HRManagementSystem.Data.Models.ConfigurationsModels;
using HRManagementSystem.Features.Common.Dtos;
using HRManagementSystem.Features.ConfigurationsManagement.RequestTypeManagement.AddRequestType.Commands;

namespace HRManagementSystem.Features.ConfigurationsManagement.RequestTypeManagement.Mapping
{
    public sealed class AddRequestTypeProfile : Profile
    {
        public AddRequestTypeProfile()
        {
            CreateMap<AddRequestTypeCommand, RequestType>()
                .ForMember(d => d.Name, o => o.MapFrom(s => s.Name.Trim()))
                .ForMember(d => d.Description, o => o.MapFrom(s => string.IsNullOrWhiteSpace(s.Description) ? null : s.Description.Trim()));

            CreateMap<RequestType, CreatedIdDto>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.Id));
        }
    }
}

