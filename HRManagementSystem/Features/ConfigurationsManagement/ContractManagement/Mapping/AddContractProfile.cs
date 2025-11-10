using HRManagementSystem.Data.Models.ConfigurationsModels;
using HRManagementSystem.Features.Common.Dtos;
using HRManagementSystem.Features.ConfigurationsManagement.ContractManagement.AddContract.Commands;

namespace HRManagementSystem.Features.ConfigurationsManagement.ContractManagement.Mapping
{
    public sealed class AddContractProfile : Profile
    {
        public AddContractProfile()
        {
            CreateMap<AddContractCommand, Contract>()
                .ForMember(d => d.ContractNumber, o => o.MapFrom(s => s.ContractNumber.Trim()))
                .ForMember(d => d.Title, o => o.MapFrom(s => s.Title.Trim()))
                .ForMember(d => d.Description, o => o.MapFrom(s => string.IsNullOrWhiteSpace(s.Description) ? null : s.Description.Trim()))
                .ForMember(d => d.Terms, o => o.MapFrom(s => string.IsNullOrWhiteSpace(s.Terms) ? null : s.Terms.Trim()));

            CreateMap<Contract, CreatedIdDto>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.Id));
        }
    }
}

