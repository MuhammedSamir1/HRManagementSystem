using HRManagementSystem.Data.Models.ConfigurationsModels;
using HRManagementSystem.Features.ConfigurationsManagement.LoanManagement.UpdateLoan;
using HRManagementSystem.Features.ConfigurationsManagement.LoanManagement.UpdateLoan.Commands;

namespace HRManagementSystem.Features.ConfigurationsManagement.LoanManagement.Mapping
{
    public class UpdateLoanProfile : Profile
    {
        public UpdateLoanProfile()
        {
            CreateMap<UpdateLoanViewModel, UpdateLoanCommand>();
            CreateMap<UpdateLoanCommand, Loan>();
        }
    }
}
