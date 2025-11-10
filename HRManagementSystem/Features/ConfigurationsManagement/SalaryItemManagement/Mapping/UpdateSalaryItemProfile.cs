using HRManagementSystem.Data.Models.ConfigurationsModels;
using HRManagementSystem.Features.ConfigurationsManagement.SalaryItemManagement.UpdateSalaryItem;
using HRManagementSystem.Features.ConfigurationsManagement.SalaryItemManagement.UpdateSalaryItem.Commands;

namespace HRManagementSystem.Features.ConfigurationsManagement.SalaryItemManagement.Mapping
{
    public class UpdateSalaryItemProfile : Profile
    {
        public UpdateSalaryItemProfile()
        {
            CreateMap<UpdateSalaryItemViewModel, UpdateSalaryItemCommand>();
            CreateMap<UpdateSalaryItemCommand, SalaryItem>();
        }
    }
}
