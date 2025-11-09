using HRManagementSystem.Features.BankManagement.AddBank.Commands;
using HRManagementSystem.Features.Common.Dtos;

namespace HRManagementSystem.Features.BankManagement.Mapping
{
    public sealed class AddBankProfile : Profile
    {
        public AddBankProfile()
        {
            CreateMap<AddBankCommand, Bank>()
                .ForMember(d => d.Name, o => o.MapFrom(s => s.Name.Trim()))
                .ForMember(d => d.Code, o => o.MapFrom(s => s.Code.Trim()))
                .ForMember(d => d.Address, o => o.MapFrom(s => s.Address.Trim()));

            CreateMap<Bank, CreatedIdDto>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.Id));
        }
    }
}

