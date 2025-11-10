using HRManagementSystem.Features.CityManagement.UpdateCity.Command;

namespace HRManagementSystem.Features.CityManagement.UpdateCity
{
    public class UpdateCityEndPoint
        : BaseEndPoint<UpdateCityViewModel, ResponseViewModel<bool>>
    {
        public UpdateCityEndPoint(EndPointBaseParameters<UpdateCityViewModel> parameters)
            : base(parameters)
        {
        }

        [HttpPut("update")]
        public async Task<ResponseViewModel<bool>> UpdateCity([FromBody] UpdateCityViewModel model, CancellationToken ct)
        {
            var validationResult = ValidateRequest(model);
            if (!validationResult.isSuccess)
                return ResponseViewModel<bool>.Failure(validationResult.errorCode);

            var result = await _mediator.Send(new UpdateCityCommand(model.Id, model.Name, model.StateId), ct);

            if (!result.isSuccess)
                return ResponseViewModel<bool>.Failure(result.errorCode);

            return ResponseViewModel<bool>.Success(true, "City updated successfully!");
        }
    }
}


