using HRManagementSystem.Common.Extensions;
using HRManagementSystem.Common.Views;
using HRManagementSystem.Features.ConfigurationsManagement.HolidayManagement.Common.DTOs;
using HRManagementSystem.Features.ConfigurationsManagement.HolidayManagement.Common.ViewModels;
using HRManagementSystem.Features.ConfigurationsManagement.HolidayManagement.GetAllHolidays.Queries;

namespace HRManagementSystem.Features.ConfigurationsManagement.HolidayManagement.GetAllHolidays
{
    public class GetAllHolidaysEndPoint : BaseEndPoint<GetAllHolidaysViewModel, ResponseViewModel<object>>
    {

        public GetAllHolidaysEndPoint(EndPointBaseParameters<GetAllHolidaysViewModel> parameters) : base(parameters) { }

        [HttpGet]
        public async Task<ResponseViewModel<PagedList<ViewHolidayViewModel>>> GetAllHolidays([FromQuery] GetAllHolidaysViewModel model, CancellationToken ct)
        {

            var query = _mapper.Map<GetAllHolidaysQuery>(model);


            var result = await _mediator.Send(query, ct);


            if (!result.isSuccess)
            {
                return ResponseViewModel<PagedList<ViewHolidayViewModel>>.Failure(result.message, result.errorCode);
            }


            var mappedPagedList = result.data!.MapTo<ViewHolidayDto, ViewHolidayViewModel>(_mapper.ConfigurationProvider);

            return ResponseViewModel<PagedList<ViewHolidayViewModel>>.Success(mappedPagedList);
        }
    }
}
