using FluentValidation;

namespace HRManagementSystem.Features.ConfigurationsManagement.SalaryItemManagement.DeleteSalaryItem
{
    public sealed record DeleteSalaryItemViewModel(int Id);

    public sealed class DeleteSalaryItemViewModelValidator : AbstractValidator<DeleteSalaryItemViewModel>
    {
        public DeleteSalaryItemViewModelValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0.");
        }
    }
}

