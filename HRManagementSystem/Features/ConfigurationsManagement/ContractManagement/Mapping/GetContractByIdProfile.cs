using HRManagementSystem.Data.Models.ConfigurationsModels;
using HRManagementSystem.Features.ConfigurationsManagement.ContractManagement.GetContractById;

namespace HRManagementSystem.Features.ConfigurationsManagement.ContractManagement.Mapping
{
    public sealed class GetContractByIdProfile : Profile
    {
        public GetContractByIdProfile()
        {
            CreateMap<Contract, GetContractByIdDto>();
            CreateMap<GetContractByIdDto, GetContractByIdResponseViewModel>();
        }
    }
}

