using HRManagementSystem.Data.Models.ConfigurationsModels;
using HRManagementSystem.Features.ConfigurationsManagement.RequestTypeManagement.UpdateRequestType.Commands;

namespace HRManagementSystem.Features.ConfigurationsManagement.RequestTypeManagement.Mapping
{
    public sealed class UpdateRequestTypeProfile : Profile
    {
        public UpdateRequestTypeProfile()
        {
            CreateMap<UpdateRequestTypeCommand, RequestType>()
                .ForMember(d => d.Name, o => o.MapFrom(s => s.Name.Trim()))
                .ForMember(d => d.Description, o => o.MapFrom(s => string.IsNullOrWhiteSpace(s.Description) ? null : s.Description.Trim()));
        }
    }
}

