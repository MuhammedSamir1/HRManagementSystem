using FluentValidation;

namespace HRManagementSystem.Features.ShiftManagement.DeleteShift
{
    public sealed record DeleteShiftViewModel(int Id);



    public sealed class DeleteShiftViewModelValidator : AbstractValidator<DeleteShiftViewModel>
    {
        public DeleteShiftViewModelValidator()
        {
            RuleFor(d => d.Id)
                .NotEmpty().WithMessage("Id is required.")
                .GreaterThan(0).WithMessage("Id must be greater than 0");
        }
    }
}

