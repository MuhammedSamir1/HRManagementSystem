using FluentValidation;

namespace HRManagementSystem.Features.DepartmentManagement.GetDepartmentById
{
    public record GetDepartmentByIdRequestViewModel(int departmentId);

    public class GetDepartmentByIdRequestViewModelValidator : AbstractValidator<GetDepartmentByIdRequestViewModel>
    {
        public GetDepartmentByIdRequestViewModelValidator()
        {
            RuleFor(x => x.departmentId)
                .GreaterThan(0).WithMessage("Department Id must be greater than zero.");
        }
    }
}
