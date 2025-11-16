using FluentValidation;

namespace HRManagementSystem.Features.DepartmentManagement.GetDepartmentById
{
    public record GetDepartmentByIdRequestViewModel(Guid departmentId);

    public class GetDepartmentByIdRequestViewModelValidator : AbstractValidator<GetDepartmentByIdRequestViewModel>
    {
        public GetDepartmentByIdRequestViewModelValidator()
        {
            RuleFor(x => x.departmentId)
                .NotEqual(Guid.Empty).WithMessage("Department Id must be greater than zero.");
        }
    }
}


