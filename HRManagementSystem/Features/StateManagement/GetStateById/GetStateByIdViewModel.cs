using FluentValidation;

namespace HRManagementSystem.Features.StateManagement.GetStateById
{
    public sealed record GetStateByIdViewModel(int Id);
    public sealed class GetStateByIdViewModelValidator : AbstractValidator<GetStateByIdViewModel>
    {
        public GetStateByIdViewModelValidator()
        {
            RuleFor(d => d.Id)
                .NotEmpty().WithMessage("Id is required.")
                .GreaterThan(0).WithMessage("Id must be greater than 0");
        }
    }
}
