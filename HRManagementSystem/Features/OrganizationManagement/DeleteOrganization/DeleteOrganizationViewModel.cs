using FluentValidation;

namespace HRManagementSystem.Features.OrganizationManagement.DeleteOrganization
{
    public sealed record DeleteOrganizationViewModel(int Id);



    public sealed class DeleteOrganizationViewModelValidator : AbstractValidator<DeleteOrganizationViewModel>
    {
        public DeleteOrganizationViewModelValidator()
        {
            RuleFor(d => d.Id)
                .NotEmpty().WithMessage("Id is required.")
                .GreaterThan(0).WithMessage("Id must be greater than 0");
        }
    }
}
