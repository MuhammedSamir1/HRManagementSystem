using FluentValidation;

namespace HRManagementSystem.Features.HolidayManagement.DeleteHoliday
{
    public record DeleteHolidayViewModel(int Id);
    public class DeleteHolidayViewModelValidator : AbstractValidator<DeleteHolidayViewModel>
    {
        public DeleteHolidayViewModelValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("Holiday ID is required for deletion.");
        }
    }
}
