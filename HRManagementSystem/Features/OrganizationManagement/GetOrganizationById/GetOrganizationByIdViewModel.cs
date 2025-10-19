using FluentValidation;

namespace HRManagementSystem.Features.OrganizationManagement.GetOrganizationById
{
    public sealed record GetOrganizationByIdViewModel(int Id);


    public sealed class GetOrganizationByIdViewModelValidator : AbstractValidator<GetOrganizationByIdViewModel>
    {
        public GetOrganizationByIdViewModelValidator()
        {
            RuleFor(d => d.Id)
                .NotEmpty().WithMessage("Id is required.")
                .GreaterThan(0).WithMessage("Id must be greater than 0");
        }
    }
}
