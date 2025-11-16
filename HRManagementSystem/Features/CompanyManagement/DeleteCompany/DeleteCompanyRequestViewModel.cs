using FluentValidation;

namespace HRManagementSystem.Features.CompanyManagement.DeleteCompany
{
    public record DeleteCompanyRequestViewModel(Guid companyId);

    public sealed class DeleteCompanyRequestViewModelValidator : AbstractValidator<DeleteCompanyRequestViewModel>
    {
        public DeleteCompanyRequestViewModelValidator()
        {
            RuleFor(d => d.companyId)
                .NotEmpty().WithMessage("Company Id is required.")
                .NotEqual(Guid.Empty).WithMessage("Company Id must be greater than 0");
        }
    }
}


