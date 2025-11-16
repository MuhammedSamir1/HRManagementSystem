using FluentValidation;

namespace HRManagementSystem.Features.ConfigurationsManagement.ShiftManagement.DeleteShift
{
    public sealed record DeleteShiftViewModel(Guid Id);



    public sealed class DeleteShiftViewModelValidator : AbstractValidator<DeleteShiftViewModel>
    {
        public DeleteShiftViewModelValidator()
        {
            RuleFor(d => d.Id)
                .NotEmpty().WithMessage("Id is required.")
                .NotEqual(Guid.Empty).WithMessage("Id must be greater than 0");
        }
    }
}



