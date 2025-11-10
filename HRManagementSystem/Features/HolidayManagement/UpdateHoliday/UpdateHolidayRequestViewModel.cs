using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace HRManagementSystem.Features.HolidayManagement.UpdateHoliday
{
    public record UpdateHolidayRequestViewModel(
     [Required] int Id, // مفتاح التعديل
     [Required] string Name,
     [Required] DateTime StartDate,
     [Required] DateTime EndDate,
     [Required] bool IsMandatory,
     [Required] HolidayType Type,
     int? CompanyId);
    public class UpdateHolidayRequestViewModelValidator : AbstractValidator<UpdateHolidayRequestViewModel>
    {
        public UpdateHolidayRequestViewModelValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("Holiday ID is required.");
            RuleFor(x => x.Name).NotEmpty().MaximumLength(150);
            RuleFor(x => x.StartDate).NotEmpty();
            RuleFor(x => x.EndDate).NotEmpty()
                .GreaterThanOrEqualTo(x => x.StartDate)
                .WithMessage("End date must be greater than or equal to the start date.");
        }
    }
}
