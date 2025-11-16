using HRManagementSystem.Features.Common.PayrollCommon;

namespace HRManagementSystem.Features.ConfigurationsManagement.PayrollManagement.OvertimeRateManagement.GetOvertimeRateById.Queries
{
    public sealed record GetOvertimeRateByIdQuery(Guid Id) : IRequest<RequestResult<OvertimeRateDto>>;
}

