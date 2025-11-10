using HRManagementSystem.Data.Models.ConfigurationsModels;
using HRManagementSystem.Features.BankManagement.UpdateBank.Commands;

namespace HRManagementSystem.Features.BankManagement.Mapping
{
    public sealed class UpdateBankProfile : Profile
    {
        public UpdateBankProfile()
        {
            CreateMap<UpdateBankCommand, Bank>()
                .ForMember(d => d.Name, o => o.MapFrom(s => s.Name.Trim()))
                .ForMember(d => d.Code, o => o.MapFrom(s => s.Code.Trim()))
                .ForMember(d => d.Address, o => o.MapFrom(s => s.Address.Trim()));
        }
    }
}

