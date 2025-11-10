using HRManagementSystem.Features.ConfigurationsManagement.DisabilityType.AddDisabilityType;
using HRManagementSystem.Features.ConfigurationsManagement.DisabilityType.UpdateDisabilityType.Command;

namespace HRManagementSystem.Features.ConfigurationsManagement.DisabilityType.UpdateDisabilityType
{
    // Endpoints/UpdateDisabilityTypeEndPoint.cs
    public class UpdateDisabilityTypeEndPoint : BaseEndPoint<UpdateDisabilityTypeViewModel,
        ResponseViewModel<ViewDisabilityTypeViewModel>>
    {
        public UpdateDisabilityTypeEndPoint(EndPointBaseParameters<UpdateDisabilityTypeViewModel> parameters)
            : base(parameters) { }

        [HttpPut]
        public async Task<ResponseViewModel<ViewDisabilityTypeViewModel>> Update(
            [FromBody] UpdateDisabilityTypeViewModel model)
        {
            var validationResult = ValidateRequest(model);
            if (!validationResult.isSuccess)
            {
                return ResponseViewModel<ViewDisabilityTypeViewModel>.Failure(
                    validationResult.message, validationResult.errorCode);
            }

            var result = await _mediator.Send(new UpdateDisabilityTypeCommand(
                model.Id, model.Code, model.Name, model.Description));

            if (!result.isSuccess)
            {
                return ResponseViewModel<ViewDisabilityTypeViewModel>.Failure(
                    result.message, result.errorCode);
            }

            var vm = _mapper.Map<ViewDisabilityTypeViewModel>(result.data);
            return ResponseViewModel<ViewDisabilityTypeViewModel>.Success(
                vm, "Disability type updated successfully");
        }
    }
}
