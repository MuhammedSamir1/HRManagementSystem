using HRManagementSystem.Data.Models.ConfigurationsModels;
using HRManagementSystem.Features.ConfigurationsManagement.EndOfServiceManagement.UpdateEndOfService;
using HRManagementSystem.Features.ConfigurationsManagement.EndOfServiceManagement.UpdateEndOfService.Commands;

namespace HRManagementSystem.Features.ConfigurationsManagement.EndOfServiceManagement.Mapping
{
    public class UpdateEndOfServiceProfile : Profile
    {
        public UpdateEndOfServiceProfile()
        {
            CreateMap<UpdateEndOfServiceViewModel, UpdateEndOfServiceCommand>();
            CreateMap<UpdateEndOfServiceCommand, EndOfService>();
        }
    }
}
