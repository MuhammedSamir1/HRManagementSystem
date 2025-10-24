using HRManagementSystem.Common.BaseEndPoints;
using HRManagementSystem.Common.Views.Response;
using HRManagementSystem.Features.Common.AddressManagement.StateCommon.ViewModels;
using HRManagementSystem.Features.StateManagement.GetAllStates.Queries;
using Microsoft.AspNetCore.Mvc;

namespace HRManagementSystem.Features.StateManagement.GetAllStates
{
    public class GetAllStatesEndPoint : BaseEndPoint<GetAllStatesViewModel,
    ResponseViewModel<IEnumerable<ViewStateViewModel>>>
    {
        public GetAllStatesEndPoint(EndPointBaseParameters<GetAllStatesViewModel> parameters)
            : base(parameters) { }

        [HttpGet]
        public async Task<ResponseViewModel<IEnumerable<ViewStateViewModel>>> GetAll([FromQuery] GetAllStatesViewModel model)
        {
            var validationResult = ValidateRequest(model);
            if (!validationResult.isSuccess)
            {
                return ResponseViewModel<IEnumerable<ViewStateViewModel>>.Failure(validationResult.errorCode);
            }

            var states = await _mediator.Send(new GetAllStatesQuery());

            if (!states.isSuccess)
                return ResponseViewModel<IEnumerable<ViewStateViewModel>>.Failure(states.message);

            var vm = _mapper.Map<IEnumerable<ViewStateViewModel>>(states.data);
            return ResponseViewModel<IEnumerable<ViewStateViewModel>>.Success(vm);
        }
    }
}
