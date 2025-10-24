using FluentValidation;

namespace HRManagementSystem.Features.DepartmentManagement.GetAllDepartments
{
    public record GetAllDepartmentsRequestViewModel();

    public class GetAllDepartmentsRequestViewModelValidator : AbstractValidator<GetAllDepartmentsRequestViewModel>
    {
        public GetAllDepartmentsRequestViewModelValidator()
        {
        }
    }

}
