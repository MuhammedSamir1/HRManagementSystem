using FluentValidation;

namespace HRManagementSystem.Features.ConfigurationsManagement.SalaryItemManagement.GetSalaryItemById
{
    public sealed record GetSalaryItemByIdViewModel(int Id);

    public sealed class GetSalaryItemByIdViewModelValidator : AbstractValidator<GetSalaryItemByIdViewModel>
    {
        public GetSalaryItemByIdViewModelValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0.");
        }
    }
}

