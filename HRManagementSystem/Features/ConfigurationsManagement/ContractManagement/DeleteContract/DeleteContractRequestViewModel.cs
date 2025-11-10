using FluentValidation;

namespace HRManagementSystem.Features.ConfigurationsManagement.ContractManagement.DeleteContract
{
    public record DeleteContractRequestViewModel(int Id);

    public class DeleteContractRequestViewModelValidator : AbstractValidator<DeleteContractRequestViewModel>
    {
        public DeleteContractRequestViewModelValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0.");
        }
    }
}

