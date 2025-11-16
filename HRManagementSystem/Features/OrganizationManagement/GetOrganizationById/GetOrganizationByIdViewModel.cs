using FluentValidation;

namespace HRManagementSystem.Features.OrganizationManagement.GetOrganizationById
{
    public sealed record GetOrganizationByIdViewModel(Guid Id);


    public sealed class GetOrganizationByIdViewModelValidator : AbstractValidator<GetOrganizationByIdViewModel>
    {
        public GetOrganizationByIdViewModelValidator()
        {
            RuleFor(d => d.Id)
                .NotEmpty().WithMessage("Id is required.")
                .NotEqual(Guid.Empty).WithMessage("Id must not be empty.");
        }
    }
}
