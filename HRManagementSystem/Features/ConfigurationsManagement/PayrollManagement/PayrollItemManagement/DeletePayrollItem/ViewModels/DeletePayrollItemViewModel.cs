using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace HRManagementSystem.Features.ConfigurationsManagement.PayrollManagement.PayrollItemManagement.DeletePayrollItem.ViewModels
{
    public sealed record DeletePayrollItemViewModel(
       [Required] Guid Id);
    public class DeletePayrollItemViewModelValidator : AbstractValidator<DeletePayrollItemViewModel>
    {
        public DeletePayrollItemViewModelValidator()
        {

            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Payroll Item ID is required for deletion.")
                .NotEqual(Guid.Empty).WithMessage("Payroll Item ID must be a positive integer.");
        }
    }
}


