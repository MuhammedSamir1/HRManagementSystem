using FluentValidation;

namespace HRManagementSystem.Features.OrganizationManagement.DeleteOrganization
{
    public sealed record DeleteOrganizationViewModel(Guid Id);



    public sealed class DeleteOrganizationViewModelValidator : AbstractValidator<DeleteOrganizationViewModel>
    {
        public DeleteOrganizationViewModelValidator()
        {
            RuleFor(d => d.Id)
                .NotEmpty().WithMessage("Id is required.")
                .NotEqual(Guid.Empty).WithMessage("Id must be greater than 0");
        }
    }
}


