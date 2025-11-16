using FluentValidation;

namespace HRManagementSystem.Features.CompanyManagement.GetCompanyById
{
    public record GetCompanyByIdRequestViewModel(Guid companyId);

    public class GetCompanyByIdRequestViewModelValidator : AbstractValidator<GetCompanyByIdRequestViewModel>
    {
        public GetCompanyByIdRequestViewModelValidator()
        {
            RuleFor(x => x.companyId)
                .NotEqual(Guid.Empty).WithMessage("Company Id must be greater than zero.");
        }
    }
}


