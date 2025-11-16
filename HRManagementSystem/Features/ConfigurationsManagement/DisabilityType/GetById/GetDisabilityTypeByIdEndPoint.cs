using HRManagementSystem.Features.ConfigurationsManagement.DisabilityType.AddDisabilityType;
using HRManagementSystem.Features.ConfigurationsManagement.DisabilityType.GetById.Queries;

namespace HRManagementSystem.Features.ConfigurationsManagement.DisabilityType.GetById
{
    // Endpoints/GetDisabilityTypeByIdEndPoint.cs
    public class GetDisabilityTypeByIdEndPoint : BaseEndPoint<GetDisabilityTypeByIdViewModel,
        ResponseViewModel<ViewDisabilityTypeViewModel>>
    {
        public GetDisabilityTypeByIdEndPoint(EndPointBaseParameters<GetDisabilityTypeByIdViewModel> parameters)
            : base(parameters) { }

        [HttpGet("{id}")]
        public async Task<ResponseViewModel<ViewDisabilityTypeViewModel>> GetById(
            [FromRoute] Guid id)
        {
            var model = new GetDisabilityTypeByIdViewModel(id);

            var validationResult = ValidateRequest(model);
            if (!validationResult.isSuccess)
            {
                return ResponseViewModel<ViewDisabilityTypeViewModel>.Failure(
                    validationResult.message, validationResult.errorCode);
            }

            var result = await _mediator.Send(new GetDisabilityTypeByIdQuery(id));

            if (!result.isSuccess)
            {
                return ResponseViewModel<ViewDisabilityTypeViewModel>.Failure(
                    result.message, result.errorCode);
            }

            var vm = _mapper.Map<ViewDisabilityTypeViewModel>(result.data);
            return ResponseViewModel<ViewDisabilityTypeViewModel>.Success(
                vm, result.message);
        }
    }
}

