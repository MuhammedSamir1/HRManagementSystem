using HRManagementSystem.Features.ConfigurationsManagement.DisabilityType.DeleteDisabilityType.Command;

namespace HRManagementSystem.Features.ConfigurationsManagement.DisabilityType.DeleteDisabilityType
{
    // Endpoints/DeleteDisabilityTypeEndPoint.cs
    [ApiGroup("Configurations Management", "Disability Type")]
    public class DeleteDisabilityTypeEndPoint : BaseEndPoint<DeleteDisabilityTypeViewModel,
        ResponseViewModel<bool>>
    {
        public DeleteDisabilityTypeEndPoint(EndPointBaseParameters<DeleteDisabilityTypeViewModel> parameters)
            : base(parameters) { }

        [HttpDelete]
        public async Task<ResponseViewModel<bool>> Delete(
            [FromBody] DeleteDisabilityTypeViewModel model)
        {
            var validationResult = ValidateRequest(model);
            if (!validationResult.isSuccess)
            {
                return ResponseViewModel<bool>.Failure(
                    validationResult.message, validationResult.errorCode);
            }

            var result = await _mediator.Send(new DeleteDisabilityTypeCommand(model.Id));

            if (!result.isSuccess)
            {
                return ResponseViewModel<bool>.Failure(
                    result.message, result.errorCode);
            }

            return ResponseViewModel<bool>.Success(
                result.data, "Disability type deleted successfully");
        }
    }
}



