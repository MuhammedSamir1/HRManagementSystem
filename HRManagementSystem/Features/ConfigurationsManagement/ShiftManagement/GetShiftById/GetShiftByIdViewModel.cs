using FluentValidation;

namespace HRManagementSystem.Features.ConfigurationsManagement.ShiftManagement.GetShiftById
{
    public sealed record GetShiftByIdViewModel(Guid Id);


    public sealed class GetShiftByIdViewModelValidator : AbstractValidator<GetShiftByIdViewModel>
    {
        public GetShiftByIdViewModelValidator()
        {
            RuleFor(d => d.Id)
              .NotEmpty().WithMessage("Id is required.")
              .NotEqual(Guid.Empty).WithMessage("Id must be greater than 0");
        }
    }
}



