using HRManagementSystem.Data.Models.ConfigurationsModels;
using HRManagementSystem.Features.ContractManagement.UpdateContract.Commands;

namespace HRManagementSystem.Features.ContractManagement.Mapping
{
    public sealed class UpdateContractProfile : Profile
    {
        public UpdateContractProfile()
        {
            CreateMap<UpdateContractCommand, Contract>()
                .ForMember(d => d.ContractNumber, o => o.MapFrom(s => s.ContractNumber.Trim()))
                .ForMember(d => d.Title, o => o.MapFrom(s => s.Title.Trim()))
                .ForMember(d => d.Description, o => o.MapFrom(s => string.IsNullOrWhiteSpace(s.Description) ? null : s.Description.Trim()))
                .ForMember(d => d.Terms, o => o.MapFrom(s => string.IsNullOrWhiteSpace(s.Terms) ? null : s.Terms.Trim()));
        }
    }
}

