using HRManagementSystem.Data.Models.ConfigurationsModels;
using HRManagementSystem.Features.ConfigurationsManagement.ContractManagement.GetAllContracts;

namespace HRManagementSystem.Features.ConfigurationsManagement.ContractManagement.Mapping
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

