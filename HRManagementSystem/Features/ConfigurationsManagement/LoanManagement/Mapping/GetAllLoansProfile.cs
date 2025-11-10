using HRManagementSystem.Data.Models.ConfigurationsModels;
using HRManagementSystem.Features.ConfigurationsManagement.LoanManagement.GetAllLoans;
using HRManagementSystem.Features.ConfigurationsManagement.LoanManagement.GetAllLoans.Queries;

namespace HRManagementSystem.Features.ConfigurationsManagement.LoanManagement.Mapping
{
    public class GetAllLoansProfile : Profile
    {
        public GetAllLoansProfile()
        {
            CreateMap<GetAllLoansViewModel, GetAllLoansQuery>();
            CreateMap<Loan, ViewLoanDto>();
            CreateMap<ViewLoanDto, ViewLoanViewModel>();
        }
    }
}
