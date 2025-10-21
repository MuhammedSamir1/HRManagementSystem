using FluentValidation;

namespace HRManagementSystem.Features.CompanyManagement.GetAllCompanies
{
    public record GetAllCompaniesRequestViewModel();

    public class GetAllCompaniesRequestViewModelViewModelValidator : AbstractValidator<GetAllCompaniesRequestViewModel>
    {
        public GetAllCompaniesRequestViewModelViewModelValidator()
        {
        }
    }

}
