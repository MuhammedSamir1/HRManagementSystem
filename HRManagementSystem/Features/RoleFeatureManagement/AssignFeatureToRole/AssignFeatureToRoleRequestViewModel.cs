using FluentValidation;

namespace HRManagementSystem.Features.RoleFeatureManagement.AssignFeatureToRole
{
    public record AssignFeatureToRoleRequestViewModel(
        Guid RoleId,
        Feature Feature
        );

    public class AssignFeatureToRoleRequestViewModelValidator : AbstractValidator<AssignFeatureToRoleRequestViewModel>
    {
        public AssignFeatureToRoleRequestViewModelValidator()
        {
        }
    }

}
