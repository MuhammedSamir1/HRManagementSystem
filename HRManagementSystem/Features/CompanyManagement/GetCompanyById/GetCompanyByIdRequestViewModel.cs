using FluentValidation;

namespace HRManagementSystem.Features.CompanyManagement.GetCompanyById
{
    public record GetCompanyByIdRequestViewModel(int companyId);

    public class GetCompanyByIdRequestViewModelValidator : AbstractValidator<GetCompanyByIdRequestViewModel>
    {
        public GetCompanyByIdRequestViewModelValidator()
        {
            RuleFor(x => x.companyId)
                .GreaterThan(0).WithMessage("Company Id must be greater than zero.");
        }
    }
}
