using FluentValidation;

namespace HRManagementSystem.Features.ConfigurationsManagement.EndOfServiceManagement.GetEndOfServiceById
{
    public sealed record GetEndOfServiceByIdViewModel(int Id);

    public sealed class GetEndOfServiceByIdViewModelValidator : AbstractValidator<GetEndOfServiceByIdViewModel>
    {
        public GetEndOfServiceByIdViewModelValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0.");
        }
    }
}

