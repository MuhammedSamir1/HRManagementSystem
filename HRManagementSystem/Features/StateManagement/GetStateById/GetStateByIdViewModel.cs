using FluentValidation;

namespace HRManagementSystem.Features.StateManagement.GetStateById
{
    public sealed record GetStateByIdViewModel(Guid Id);
    public sealed class GetStateByIdViewModelValidator : AbstractValidator<GetStateByIdViewModel>
    {
        public GetStateByIdViewModelValidator()
        {
            RuleFor(d => d.Id)
                .NotEmpty().WithMessage("Id is required.")
                .NotEqual(Guid.Empty).WithMessage("Id must be greater than 0");
        }
    }
}


