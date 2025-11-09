using HRManagementSystem.Features.HolidayManagement.Common.DTOs;

namespace HRManagementSystem.Features.HolidayManagement.GetHolidayById.Queries
{
    public sealed record GetHolidayByIdQuery(int Id) : IRequest<RequestResult<ViewHolidayDto>>;
}
