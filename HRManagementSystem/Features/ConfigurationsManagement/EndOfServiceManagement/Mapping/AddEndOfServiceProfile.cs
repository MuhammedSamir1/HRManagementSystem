using HRManagementSystem.Data.Models.ConfigurationsModels;
using HRManagementSystem.Features.ConfigurationsManagement.EndOfServiceManagement.AddEndOfService;
using HRManagementSystem.Features.ConfigurationsManagement.EndOfServiceManagement.AddEndOfService.Commands;

namespace HRManagementSystem.Features.ConfigurationsManagement.EndOfServiceManagement.Mapping
{
    public class AddEndOfServiceProfile : Profile
    {
        public AddEndOfServiceProfile()
        {
            CreateMap<AddEndOfServiceViewModel, AddEndOfServiceCommand>();
            CreateMap<AddEndOfServiceCommand, EndOfService>();
        }
    }
}
