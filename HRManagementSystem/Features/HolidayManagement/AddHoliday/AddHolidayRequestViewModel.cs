using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace HRManagementSystem.Features.HolidayManagement.AddHoliday
{
    public record AddHolidayRequestViewModel(
    [Required] string Name,
    [Required] DateTime StartDate,
    [Required] DateTime EndDate,
    [Required] bool IsMandatory,
    [Required] HolidayType Type,
    int? CompanyId);
    public class AddHolidayRequestViewModelValidator : AbstractValidator<AddHolidayRequestViewModel>
    {
        public AddHolidayRequestViewModelValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(150);
            RuleFor(x => x.StartDate).NotEmpty();
            RuleFor(x => x.EndDate).NotEmpty()
                // تحقق من ان تاريخ الانتهاء يكون اكبر من او يساوي تاريخ البدء  من التاريخ
                .GreaterThanOrEqualTo(x => x.StartDate)
                .WithMessage("End date must be greater than or equal to the start date.");
        }
    }
}
