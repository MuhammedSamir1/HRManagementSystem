using HRManagementSystem.Data.Models.ConfigurationsModels;
using HRManagementSystem.Features.ConfigurationsManagement.BonusManagement.GetAllBonuses;
using HRManagementSystem.Features.ConfigurationsManagement.BonusManagement.GetAllBonuses.Queries;

namespace HRManagementSystem.Features.ConfigurationsManagement.BonusManagement.Mapping
{
    public class GetAllBonusesProfile : Profile
    {
        public GetAllBonusesProfile()
        {
            CreateMap<GetAllBonusesViewModel, GetAllBonusesQuery>();
            CreateMap<Bonus, ViewBonusDto>();
            CreateMap<ViewBonusDto, ViewBonusViewModel>();
        }
    }
}
