using FluentValidation;

namespace HRManagementSystem.Features.ConfigurationsManagement.SalaryItemManagement.GetSalaryItemById
{
    public sealed record GetSalaryItemByIdViewModel(Guid Id);

    public sealed class GetSalaryItemByIdViewModelValidator : AbstractValidator<GetSalaryItemByIdViewModel>
    {
        public GetSalaryItemByIdViewModelValidator()
        {
            RuleFor(x => x.Id)
                .NotEqual(Guid.Empty).WithMessage("Id must be greater than 0.");
        }
    }
}



