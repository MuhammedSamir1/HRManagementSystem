using FluentValidation;

namespace HRManagementSystem.Features.ContractManagement.GetAllContracts
{
    public record GetAllContractsRequestViewModel();

    public class GetAllContractsRequestViewModelValidator : AbstractValidator<GetAllContractsRequestViewModel>
    {
        public GetAllContractsRequestViewModelValidator()
        {
        }
    }
}

