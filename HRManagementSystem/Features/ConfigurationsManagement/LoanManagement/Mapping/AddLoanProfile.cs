using HRManagementSystem.Data.Models.ConfigurationsModels;
using HRManagementSystem.Features.Common.Dtos;
using HRManagementSystem.Features.ConfigurationsManagement.LoanManagement.AddLoan;
using HRManagementSystem.Features.ConfigurationsManagement.LoanManagement.AddLoan.Commands;

namespace HRManagementSystem.Features.ConfigurationsManagement.LoanManagement.Mapping
{
    public class AddLoanProfile : Profile
    {
        public AddLoanProfile()
        {
            CreateMap<AddLoanViewModel, AddLoanCommand>();
            CreateMap<AddLoanCommand, Loan>();
            CreateMap<Loan, CreatedIdDto>();
        }
    }
}
