using HRManagementSystem.Data.Models.ConfigurationsModels;
using HRManagementSystem.Features.ConfigurationsManagement.LoanManagement.GetLoanById;
using HRManagementSystem.Features.ConfigurationsManagement.LoanManagement.GetLoanById.Queries;

namespace HRManagementSystem.Features.ConfigurationsManagement.LoanManagement.Mapping
{
    public class GetLoanByIdProfile : Profile
    {
        public GetLoanByIdProfile()
        {
            CreateMap<GetLoanByIdViewModel, GetLoanByIdQuery>();
            CreateMap<Loan, ViewLoanByIdDto>();
            CreateMap<ViewLoanByIdDto, ViewLoanByIdViewModel>();
        }
    }
}
