using FluentValidation;

namespace HRManagementSystem.Features.ConfigurationsManagement.ContractManagement.GetAllContracts
{
    public record GetAllContractsRequestViewModel();

    public class GetAllContractsRequestViewModelValidator : AbstractValidator<GetAllContractsRequestViewModel>
    {
        public GetAllContractsRequestViewModelValidator()
        {
        }
    }
}

