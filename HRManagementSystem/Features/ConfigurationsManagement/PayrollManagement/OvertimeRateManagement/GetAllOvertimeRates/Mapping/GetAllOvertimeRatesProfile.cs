using HRManagementSystem.Data.Models.ConfigurationsModels;
using HRManagementSystem.Features.Common.PayrollCommon;
using HRManagementSystem.Features.ConfigurationsManagement.PayrollManagement.OvertimeRateManagement.GetAllOvertimeRates.Queries;

namespace HRManagementSystem.Features.ConfigurationsManagement.PayrollManagement.OvertimeRateManagement.GetAllOvertimeRates.Mapping
{
    public class GetAllOvertimeRatesProfile : Profile
    {
        public GetAllOvertimeRatesProfile()
        {
            CreateMap<GetAllOvertimeRatesViewModel, GetAllOvertimeRatesQuery>();
            CreateMap<OvertimeRate, OvertimeRateDto>();
        }
    }
}

