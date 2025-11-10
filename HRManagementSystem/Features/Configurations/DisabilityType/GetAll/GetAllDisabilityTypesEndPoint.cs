using HRManagementSystem.Features.Configurations.DisabilityType.AddDisabilityType;
using HRManagementSystem.Features.Configurations.DisabilityType.GetAll.Queries;

namespace HRManagementSystem.Features.Configurations.DisabilityType.GetAll
{
    // Endpoints/GetAllDisabilityTypesEndPoint.cs
    public class GetAllDisabilityTypesEndPoint : BaseEndPoint<GetAllDisabilityTypesViewModel,
        ResponseViewModel<IEnumerable<ViewDisabilityTypeViewModel>>>
    {
        public GetAllDisabilityTypesEndPoint(EndPointBaseParameters<GetAllDisabilityTypesViewModel> parameters)
            : base(parameters) { }

        [HttpGet]
        public async Task<ResponseViewModel<IEnumerable<ViewDisabilityTypeViewModel>>> GetAll(
            [FromQuery] GetAllDisabilityTypesViewModel model)
        {
            var validationResult = ValidateRequest(model);
            if (!validationResult.isSuccess)
            {
                return ResponseViewModel<IEnumerable<ViewDisabilityTypeViewModel>>.Failure(
                    validationResult.message, validationResult.errorCode);
            }

            var result = await _mediator.Send(new GetAllDisabilityTypesQuery(model.IncludeInactive));

            if (!result.isSuccess)
            {
                return ResponseViewModel<IEnumerable<ViewDisabilityTypeViewModel>>.Failure(
                    result.message, result.errorCode);
            }

            var vm = _mapper.Map<IEnumerable<ViewDisabilityTypeViewModel>>(result.data);
            return ResponseViewModel<IEnumerable<ViewDisabilityTypeViewModel>>.Success(
                vm, result.message);
        }
    }
}
