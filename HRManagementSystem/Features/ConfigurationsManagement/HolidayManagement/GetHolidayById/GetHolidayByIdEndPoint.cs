using HRManagementSystem.Features.ConfigurationsManagement.HolidayManagement.Common.ViewModels;
using HRManagementSystem.Features.ConfigurationsManagement.HolidayManagement.GetHolidayById.Queries;

namespace HRManagementSystem.Features.Configurations.HolidayManagement.GetHolidayById
{
    public class GetHolidayByIdEndPoint : BaseEndPoint<object, ResponseViewModel<object>>
    {
        public GetHolidayByIdEndPoint(EndPointBaseParameters<object> parameters) : base(parameters) { }

        [HttpGet("{id:int}")]
        public async Task<ResponseViewModel<ViewHolidayViewModel>> GetHolidayById([FromRoute] Guid id, CancellationToken ct)
        {
            // 1.  Query  DTO
            var result = await _mediator.Send(new GetHolidayByIdQuery(id), ct);

            if (!result.isSuccess)
                return ResponseViewModel<ViewHolidayViewModel>.Failure(result.message, result.errorCode);

            // 2. Mapping ?? DTO ??? ViewModel  
            var mappedViewModel = _mapper.Map<ViewHolidayViewModel>(result.data);

            return ResponseViewModel<ViewHolidayViewModel>.Success(mappedViewModel);
        }
    }
}

