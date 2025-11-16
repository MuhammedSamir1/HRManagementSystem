using HRManagementSystem.Data.Models.ConfigurationsModels;
using HRManagementSystem.Features.BankManagement.GetBankById;

namespace HRManagementSystem.Features.BankManagement.Mapping
{
    public sealed class GetBankByIdProfile : Profile
    {
        public GetBankByIdProfile()
        {
            CreateMap<Bank, GetBankByIdDto>();
            CreateMap<GetBankByIdDto, GetBankByIdResponseViewModel>();
        }
    }
}

