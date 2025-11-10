using HRManagementSystem.Features.ConfigurationsManagement.HolidayManagement.Common.DTOs;

namespace HRManagementSystem.Features.ConfigurationsManagement.HolidayManagement.GetHolidayById.Queries
{
    public sealed record GetHolidayByIdQuery(int Id) : IRequest<RequestResult<ViewHolidayDto>>;
}
