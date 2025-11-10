using HRManagementSystem.Data.Models.ConfigurationsModels;
using HRManagementSystem.Features.ConfigurationsManagement.SalaryItemManagement.GetAllSalaryItems;
using HRManagementSystem.Features.ConfigurationsManagement.SalaryItemManagement.GetAllSalaryItems.Queries;

namespace HRManagementSystem.Features.ConfigurationsManagement.SalaryItemManagement.Mapping
{
    public class GetAllSalaryItemsProfile : Profile
    {
        public GetAllSalaryItemsProfile()
        {
            CreateMap<GetAllSalaryItemsViewModel, GetAllSalaryItemsQuery>();
            CreateMap<SalaryItem, ViewSalaryItemDto>();
            CreateMap<ViewSalaryItemDto, ViewSalaryItemViewModel>();
        }
    }
}
