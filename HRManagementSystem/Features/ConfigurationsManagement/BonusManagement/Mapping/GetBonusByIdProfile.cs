using HRManagementSystem.Data.Models.ConfigurationsModels;
using HRManagementSystem.Features.ConfigurationsManagement.BonusManagement.GetBonusById;
using HRManagementSystem.Features.ConfigurationsManagement.BonusManagement.GetBonusById.Queries;

namespace HRManagementSystem.Features.ConfigurationsManagement.BonusManagement.Mapping
{
    public class GetBonusByIdProfile : Profile
    {
        public GetBonusByIdProfile()
        {
            CreateMap<GetBonusByIdViewModel, GetBonusByIdQuery>();
            CreateMap<Bonus, ViewBonusByIdDto>();
            CreateMap<ViewBonusByIdDto, ViewBonusByIdViewModel>();
        }
    }
}
