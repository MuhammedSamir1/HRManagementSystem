using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace HRManagementSystem.Features.DepartmentManagement.UpdateDepartment
{
    public record UpdateDepartmentRequestViewModel(
     [Required] int Id,
     [Required] int branchId,
     [Required] string name,
     [Required] string code,
     string? description);

    public class UpdateDepartmentRequestViewModelValidator : AbstractValidator<UpdateDepartmentRequestViewModel>
    {
        public UpdateDepartmentRequestViewModelValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("Department ID must be valid.");

            RuleFor(x => x.branchId).GreaterThan(0).WithMessage("Branch ID must be valid.");
            RuleFor(x => x.name).NotEmpty().MinimumLength(2).MaximumLength(200);
            RuleFor(x => x.code).NotEmpty().MaximumLength(50);
        }
    }
}
