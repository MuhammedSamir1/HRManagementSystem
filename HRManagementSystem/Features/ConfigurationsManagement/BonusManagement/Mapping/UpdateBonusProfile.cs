using HRManagementSystem.Data.Models.ConfigurationsModels;
using HRManagementSystem.Features.ConfigurationsManagement.BonusManagement.UpdateBonus;
using HRManagementSystem.Features.ConfigurationsManagement.BonusManagement.UpdateBonus.Commands;

namespace HRManagementSystem.Features.ConfigurationsManagement.BonusManagement.Mapping
{
    public class UpdateBonusProfile : Profile
    {
        public UpdateBonusProfile()
        {
            CreateMap<UpdateBonusViewModel, UpdateBonusCommand>();
            CreateMap<UpdateBonusCommand, Bonus>();
        }
    }
}
