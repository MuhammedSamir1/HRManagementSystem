using FluentValidation;

namespace HRManagementSystem.Features.ConfigurationsManagement.EndOfServiceManagement.GetEndOfServiceById
{
    public sealed record GetEndOfServiceByIdViewModel(Guid Id);

    public sealed class GetEndOfServiceByIdViewModelValidator : AbstractValidator<GetEndOfServiceByIdViewModel>
    {
        public GetEndOfServiceByIdViewModelValidator()
        {
            RuleFor(x => x.Id)
                .NotEqual(Guid.Empty).WithMessage("Id must be greater than 0.");
        }
    }
}



