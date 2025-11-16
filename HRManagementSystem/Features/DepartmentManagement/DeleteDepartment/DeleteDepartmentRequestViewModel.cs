using FluentValidation;

namespace HRManagementSystem.Features.DepartmentManagement.DeleteDepartment
{
    public record DeleteDepartmentRequestViewModel(Guid departmentId);
    public class DeleteDepartmentRequestViewModelValidator : AbstractValidator<DeleteDepartmentRequestViewModel>
    {
        public DeleteDepartmentRequestViewModelValidator()
        {
            RuleFor(x => x.departmentId).NotEqual(Guid.Empty).WithMessage("Department ID must be valid.");
        }
    }
}


