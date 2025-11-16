using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace HRManagementSystem.Features.DepartmentManagement.UpdateDepartment
{
    public record UpdateDepartmentRequestViewModel(
     [Required] Guid Id,
     [Required] Guid branchId,
     [Required] string name,
     [Required] string code,
     string? description);

    public class UpdateDepartmentRequestViewModelValidator : AbstractValidator<UpdateDepartmentRequestViewModel>
    {
        public UpdateDepartmentRequestViewModelValidator()
        {
            RuleFor(x => x.Id).NotEqual(Guid.Empty).WithMessage("Department ID must be valid.");

            RuleFor(x => x.branchId).NotEqual(Guid.Empty).WithMessage("Branch ID must be valid.");
            RuleFor(x => x.name).NotEmpty().MinimumLength(2).MaximumLength(200);
            RuleFor(x => x.code).NotEmpty().MaximumLength(50);
        }
    }
}


