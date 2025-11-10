using HRManagementSystem.Data.Models.ConfigurationsModels;
using HRManagementSystem.Features.ConfigurationsManagement.HolidayManagement.Common.DTOs;

namespace HRManagementSystem.Features.ConfigurationsManagement.HolidayManagement.GetHolidayById.Queries
{
    public sealed class GetHolidayByIdQueryHandler : RequestHandlerBase<GetHolidayByIdQuery, RequestResult<ViewHolidayDto>, Holiday, int>
    {
        public GetHolidayByIdQueryHandler(RequestHandlerBaseParameters<Holiday, int> parameters) : base(parameters) { }

        public override async Task<RequestResult<ViewHolidayDto>> Handle(GetHolidayByIdQuery request, CancellationToken ct)
        {
            var holiday = await _generalRepo.GetByIdAsync(request.Id);

            if (holiday == null)
            {
                return RequestResult<ViewHolidayDto>.Failure("Holiday not found.", ErrorCode.NotFound);
            }

            var viewModel = _mapper.Map<ViewHolidayDto>(holiday);

            return RequestResult<ViewHolidayDto>.Success(viewModel);
        }
    }
}
