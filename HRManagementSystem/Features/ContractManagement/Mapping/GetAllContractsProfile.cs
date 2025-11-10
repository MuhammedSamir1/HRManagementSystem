using HRManagementSystem.Data.Models.ConfigurationsModels;
using HRManagementSystem.Features.ContractManagement.GetAllContracts;

namespace HRManagementSystem.Features.ContractManagement.Mapping
{
    public sealed class GetAllContractsProfile : Profile
    {
        public GetAllContractsProfile()
        {
            CreateMap<Contract, GetAllContractsDto>();
            CreateMap<GetAllContractsDto, GetAllContractsResponseViewModel>();
        }
    }
}

