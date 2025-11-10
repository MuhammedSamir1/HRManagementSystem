using HRManagementSystem.Features.ConfigurationsManagement.EndOfServiceManagement.UpdateEndOfService.Commands;

namespace HRManagementSystem.Features.ConfigurationsManagement.EndOfServiceManagement.UpdateEndOfService
{
    public class UpdateEndOfServiceEndPoint : BaseEndPoint<UpdateEndOfServiceViewModel, ResponseViewModel<bool>>
    {
        public UpdateEndOfServiceEndPoint(EndPointBaseParameters<UpdateEndOfServiceViewModel> parameters) : base(parameters) { }

        [HttpPut]
        public async Task<ResponseViewModel<bool>> UpdateEndOfService([FromBody] UpdateEndOfServiceViewModel model, CancellationToken ct)
        {
            var command = _mapper.Map<UpdateEndOfServiceCommand>(model);
            var result = await _mediator.Send(command, ct);

            if (!result.isSuccess)
            {
                return ResponseViewModel<bool>.Failure(result.message, result.errorCode);
            }

            return ResponseViewModel<bool>.Success(true, result.message);
        }
    }
}
