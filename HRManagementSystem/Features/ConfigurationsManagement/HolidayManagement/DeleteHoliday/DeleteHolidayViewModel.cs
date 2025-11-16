using FluentValidation;

namespace HRManagementSystem.Features.ConfigurationsManagement.HolidayManagement.DeleteHoliday
{
    public record DeleteHolidayViewModel(Guid Id);
    public class DeleteHolidayViewModelValidator : AbstractValidator<DeleteHolidayViewModel>
    {
        public DeleteHolidayViewModelValidator()
        {
            RuleFor(x => x.Id).NotEqual(Guid.Empty).WithMessage("Holiday ID is required for deletion.");
        }
    }
}


