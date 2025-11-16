using HRManagementSystem.Features.ConfigurationsManagement.HolidayManagement.Common.DTOs;

namespace HRManagementSystem.Features.ConfigurationsManagement.HolidayManagement.GetHolidayById.Queries
{
    public sealed record GetHolidayByIdQuery(Guid Id) : IRequest<RequestResult<ViewHolidayDto>>;
}

