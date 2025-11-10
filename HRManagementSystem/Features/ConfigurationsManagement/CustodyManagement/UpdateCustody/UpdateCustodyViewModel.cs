using FluentValidation;
using HRManagementSystem.Features.ConfigurationsManagement.CustodyManagement.UpdateCustody.Commands;
using System.ComponentModel.DataAnnotations;

namespace HRManagementSystem.Features.ConfigurationsManagement.CustodyManagement.UpdateCustody
{
    public record UpdateCustodyViewModel(
    [Required] int Id,
    string? ItemName,
    string? SerialNumber,
    int? EmployeeId,
    DateTime? HandoverDate,
    DateTime? ReturnDate,
    string? Status);

    public class UpdateCustodyCommandValidator : AbstractValidator<UpdateCustodyCommand>
    {
        public UpdateCustodyCommandValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("??? ?????? ??? ????.");

            RuleFor(x => x.ItemName)
                .MaximumLength(250).When(x => !string.IsNullOrWhiteSpace(x.ItemName));

            RuleFor(x => x.SerialNumber)
                .MaximumLength(150).When(x => !string.IsNullOrWhiteSpace(x.SerialNumber));


            RuleFor(x => x.EmployeeId)
                .GreaterThan(0).When(x => x.EmployeeId.HasValue).WithMessage("??? ????? ???? ????.");


            RuleFor(x => x.ReturnDate)
                .LessThanOrEqualTo(DateTime.Today).When(x => x.ReturnDate.HasValue).WithMessage("????? ??????? ?? ???? ?? ???? ?? ????????.");
        }
    }
}
