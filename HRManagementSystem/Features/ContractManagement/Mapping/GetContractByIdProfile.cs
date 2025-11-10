using HRManagementSystem.Data.Models.ConfigurationsModels;
using HRManagementSystem.Features.ContractManagement.GetContractById;

namespace HRManagementSystem.Features.ContractManagement.Mapping
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

