using FluentValidation;

namespace HRManagementSystem.Features.ConfigurationsManagement.SalaryItemManagement.DeleteSalaryItem
{
    public sealed record DeleteSalaryItemViewModel(Guid Id);

    public sealed class DeleteSalaryItemViewModelValidator : AbstractValidator<DeleteSalaryItemViewModel>
    {
        public DeleteSalaryItemViewModelValidator()
        {
            RuleFor(x => x.Id)
                .NotEqual(Guid.Empty).WithMessage("Id must be greater than 0.");
        }
    }
}



