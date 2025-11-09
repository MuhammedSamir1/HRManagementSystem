using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace HRManagementSystem.Features.PayrollManagement.PayrollItemManagement.DeletePayrollItem.ViewModels
{
    public sealed record DeletePayrollItemViewModel(
       [Required] int Id);
    public class DeletePayrollItemViewModelValidator : AbstractValidator<DeletePayrollItemViewModel>
    {
        public DeletePayrollItemViewModelValidator()
        {
           
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Payroll Item ID is required for deletion.")
                .GreaterThan(0).WithMessage("Payroll Item ID must be a positive integer.");
        }
    }
}
