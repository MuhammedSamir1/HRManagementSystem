using HRManagementSystem.Data.Models.ConfigurationsModels;
using HRManagementSystem.Features.ConfigurationsManagement.PenaltyManagement.GetPenaltyById;
using HRManagementSystem.Features.ConfigurationsManagement.PenaltyManagement.GetPenaltyById.Queries;

namespace HRManagementSystem.Features.ConfigurationsManagement.PenaltyManagement.Mapping
{
    public class GetPenaltyByIdProfile : Profile
    {
        public GetPenaltyByIdProfile()
        {
            CreateMap<GetPenaltyByIdViewModel, GetPenaltyByIdQuery>();
            CreateMap<Penalty, ViewPenaltyByIdDto>();
            CreateMap<ViewPenaltyByIdDto, ViewPenaltyByIdViewModel>();
        }
    }
}
