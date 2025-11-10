using HRManagementSystem.Data.Models.ConfigurationsModels;
using HRManagementSystem.Features.ConfigurationsManagement.PenaltyManagement.GetAllPenalties;
using HRManagementSystem.Features.ConfigurationsManagement.PenaltyManagement.GetAllPenalties.Queries;

namespace HRManagementSystem.Features.ConfigurationsManagement.PenaltyManagement.Mapping
{
    public class GetAllPenaltiesProfile : Profile
    {
        public GetAllPenaltiesProfile()
        {
            CreateMap<GetAllPenaltiesViewModel, GetAllPenaltiesQuery>();
            CreateMap<Penalty, ViewPenaltyDto>();
            CreateMap<ViewPenaltyDto, ViewPenaltyViewModel>();
        }
    }
}
