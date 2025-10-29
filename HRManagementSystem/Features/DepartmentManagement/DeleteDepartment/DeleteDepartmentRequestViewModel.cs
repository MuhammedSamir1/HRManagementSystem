using FluentValidation;

namespace HRManagementSystem.Features.DepartmentManagement.DeleteDepartment
{
    public record DeleteDepartmentRequestViewModel(int departmentId);
    public class DeleteDepartmentRequestViewModelValidator : AbstractValidator<DeleteDepartmentRequestViewModel>
    {
        public DeleteDepartmentRequestViewModelValidator()
        {
            RuleFor(x => x.departmentId).GreaterThan(0).WithMessage("Department ID must be valid.");
        }
    }
}
