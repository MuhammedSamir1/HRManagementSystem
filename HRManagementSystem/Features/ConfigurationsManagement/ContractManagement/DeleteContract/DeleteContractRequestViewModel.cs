using FluentValidation;

namespace HRManagementSystem.Features.ConfigurationsManagement.ContractManagement.DeleteContract
{
    public record DeleteContractRequestViewModel(Guid Id);

    public class DeleteContractRequestViewModelValidator : AbstractValidator<DeleteContractRequestViewModel>
    {
        public DeleteContractRequestViewModelValidator()
        {
            RuleFor(x => x.Id)
                .NotEqual(Guid.Empty).WithMessage("Id must be greater than 0.");
        }
    }
}



