using HRManagementSystem.Features.Common.PayrollCommon;

namespace HRManagementSystem.Features.ConfigurationsManagement.PayrollManagement.OvertimeRateManagement.GetOvertimeRateById.Queries
{
    public sealed record GetOvertimeRateByIdQuery(int Id) : IRequest<RequestResult<OvertimeRateDto>>;
}
