using HRManagementSystem.Features.BankManagement.GetAllBanks;

namespace HRManagementSystem.Features.BankManagement.Mapping
{
    public sealed class GetAllBanksProfile : Profile
    {
        public GetAllBanksProfile()
        {
            CreateMap<Bank, GetAllBanksDto>();
            CreateMap<GetAllBanksDto, GetAllBanksResponseViewModel>();
        }
    }
}

