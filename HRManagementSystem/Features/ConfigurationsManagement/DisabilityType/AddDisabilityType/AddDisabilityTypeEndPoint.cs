using HRManagementSystem.Features.ConfigurationsManagement.DisabilityType.AddDisabilityType.Command;

namespace HRManagementSystem.Features.ConfigurationsManagement.DisabilityType.AddDisabilityType
{
    // Endpoints/AddDisabilityTypeEndPoint.cs
    public class AddDisabilityTypeEndPoint : BaseEndPoint<AddDisabilityTypeViewModel,
        ResponseViewModel<ViewDisabilityTypeViewModel>>
    {
        public AddDisabilityTypeEndPoint(EndPointBaseParameters<AddDisabilityTypeViewModel> parameters)
            : base(parameters) { }

        [HttpPost]
        public async Task<ResponseViewModel<ViewDisabilityTypeViewModel>> Add(
            [FromBody] AddDisabilityTypeViewModel model)
        {
            var validationResult = ValidateRequest(model);
            if (!validationResult.isSuccess)
            {
                return ResponseViewModel<ViewDisabilityTypeViewModel>.Failure(
                    validationResult.message, validationResult.errorCode);
            }

            var result = await _mediator.Send(new AddDisabilityTypeCommand(
                model.Code, model.Name, model.Description));

            if (!result.isSuccess)
            {
                return ResponseViewModel<ViewDisabilityTypeViewModel>.Failure(
                    result.message, result.errorCode);
            }

            var vm = _mapper.Map<ViewDisabilityTypeViewModel>(result.data);
            return ResponseViewModel<ViewDisabilityTypeViewModel>.Success(
                vm, "Disability type created successfully");
        }
    }

}
