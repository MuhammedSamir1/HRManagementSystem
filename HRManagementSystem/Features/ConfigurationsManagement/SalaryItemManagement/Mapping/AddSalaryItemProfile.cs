using HRManagementSystem.Data.Models.ConfigurationsModels;
using HRManagementSystem.Features.Common.Dtos;
using HRManagementSystem.Features.ConfigurationsManagement.SalaryItemManagement.AddSalaryItem;
using HRManagementSystem.Features.ConfigurationsManagement.SalaryItemManagement.AddSalaryItem.Commands;

namespace HRManagementSystem.Features.ConfigurationsManagement.SalaryItemManagement.Mapping
{
    public class AddSalaryItemProfile : Profile
    {
        public AddSalaryItemProfile()
        {
            CreateMap<AddSalaryItemViewModel, AddSalaryItemCommand>();
            CreateMap<AddSalaryItemCommand, SalaryItem>();
            CreateMap<SalaryItem, CreatedIdDto>();
        }
    }
}
