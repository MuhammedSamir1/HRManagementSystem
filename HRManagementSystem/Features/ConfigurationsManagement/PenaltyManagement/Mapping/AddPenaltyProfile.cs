using HRManagementSystem.Data.Models.ConfigurationsModels;
using HRManagementSystem.Features.ConfigurationsManagement.PenaltyManagement.AddPenalty;
using HRManagementSystem.Features.ConfigurationsManagement.PenaltyManagement.AddPenalty.Commands;

namespace HRManagementSystem.Features.ConfigurationsManagement.PenaltyManagement.Mapping
{
    public class AddPenaltyProfile : Profile
    {
        public AddPenaltyProfile()
        {
            CreateMap<AddPenaltyViewModel, AddPenaltyCommand>();
            CreateMap<AddPenaltyCommand, Penalty>();
        }
    }
}
