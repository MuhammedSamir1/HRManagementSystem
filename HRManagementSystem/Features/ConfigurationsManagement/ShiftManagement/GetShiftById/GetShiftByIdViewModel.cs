using FluentValidation;

namespace HRManagementSystem.Features.ConfigurationsManagement.ShiftManagement.GetShiftById
{
    public sealed record GetShiftByIdViewModel(int Id);


    public sealed class GetShiftByIdViewModelValidator : AbstractValidator<GetShiftByIdViewModel>
    {
        public GetShiftByIdViewModelValidator()
        {
            RuleFor(d => d.Id)
              .NotEmpty().WithMessage("Id is required.")
              .GreaterThan(0).WithMessage("Id must be greater than 0");
        }
    }
}

