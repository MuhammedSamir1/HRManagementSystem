using HRManagementSystem.Data.Models.ConfigurationsModels;
using HRManagementSystem.Features.ConfigurationsManagement.BonusManagement.AddBonus;
using HRManagementSystem.Features.ConfigurationsManagement.BonusManagement.AddBonus.Commands;

namespace HRManagementSystem.Features.ConfigurationsManagement.BonusManagement.Mapping
{
    public class AddBonusProfile : Profile
    {
        public AddBonusProfile()
        {
            CreateMap<AddBonusViewModel, AddBonusCommand>();
            CreateMap<AddBonusCommand, Bonus>();
        }
    }
}
