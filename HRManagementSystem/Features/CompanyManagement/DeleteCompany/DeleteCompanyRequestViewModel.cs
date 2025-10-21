using FluentValidation;

namespace HRManagementSystem.Features.CompanyManagement.DeleteCompany
{
    public record DeleteCompanyRequestViewModel(int companyId);

    public sealed class DeleteCompanyRequestViewModelValidator : AbstractValidator<DeleteCompanyRequestViewModel>
    {
        public DeleteCompanyRequestViewModelValidator()
        {
            RuleFor(d => d.companyId)
                .NotEmpty().WithMessage("Company Id is required.")
                .GreaterThan(0).WithMessage("Company Id must be greater than 0");
        }
    }
}
