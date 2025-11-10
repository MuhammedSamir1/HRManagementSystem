using HRManagementSystem.Data.Models.ConfigurationsModels;
using HRManagementSystem.Features.ConfigurationsManagement.SalaryItemManagement.GetSalaryItemById;
using HRManagementSystem.Features.ConfigurationsManagement.SalaryItemManagement.GetSalaryItemById.Queries;

namespace HRManagementSystem.Features.ConfigurationsManagement.SalaryItemManagement.Mapping
{
    public class GetSalaryItemByIdProfile : Profile
    {
        public GetSalaryItemByIdProfile()
        {
            CreateMap<GetSalaryItemByIdViewModel, GetSalaryItemByIdQuery>();
            CreateMap<SalaryItem, ViewSalaryItemByIdDto>();
            CreateMap<ViewSalaryItemByIdDto, ViewSalaryItemByIdViewModel>();
        }
    }
}
