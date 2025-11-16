using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace HRManagementSystem.Features.ConfigurationsManagement.HolidayManagement.UpdateHoliday
{
    public record UpdateHolidayRequestViewModel(
     [Required] Guid Id, // ????? ???????
     [Required] string Name,
     [Required] DateTime StartDate,
     [Required] DateTime EndDate,
     [Required] bool IsMandatory,
     [Required] HolidayType Type);
    public class UpdateHolidayRequestViewModelValidator : AbstractValidator<UpdateHolidayRequestViewModel>
    {
        public UpdateHolidayRequestViewModelValidator()
        {
            RuleFor(x => x.Id).NotEqual(Guid.Empty).WithMessage("Holiday ID is required.");
            RuleFor(x => x.Name).NotEmpty().MaximumLength(150);
            RuleFor(x => x.StartDate).NotEmpty();
            RuleFor(x => x.EndDate).NotEmpty()
                .GreaterThanOrEqualTo(x => x.StartDate)
                .WithMessage("End date must be greater than or equal to the start date.");
        }
    }
}


