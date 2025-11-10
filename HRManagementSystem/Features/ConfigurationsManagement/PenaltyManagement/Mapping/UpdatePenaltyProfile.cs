using HRManagementSystem.Data.Models.ConfigurationsModels;
using HRManagementSystem.Features.ConfigurationsManagement.PenaltyManagement.UpdatePenalty;
using HRManagementSystem.Features.ConfigurationsManagement.PenaltyManagement.UpdatePenalty.Commands;

namespace HRManagementSystem.Features.ConfigurationsManagement.PenaltyManagement.Mapping
{
    public class UpdatePenaltyProfile : Profile
    {
        public UpdatePenaltyProfile()
        {
            CreateMap<UpdatePenaltyViewModel, UpdatePenaltyCommand>();
            CreateMap<UpdatePenaltyCommand, Penalty>();
        }
    }
}
