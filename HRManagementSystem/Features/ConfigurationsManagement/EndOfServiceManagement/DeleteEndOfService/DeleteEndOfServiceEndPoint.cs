using HRManagementSystem.Features.ConfigurationsManagement.EndOfServiceManagement.DeleteEndOfService.Commands;

namespace HRManagementSystem.Features.ConfigurationsManagement.EndOfServiceManagement.DeleteEndOfService
{
    public class DeleteEndOfServiceEndPoint : BaseEndPoint<Guid, ResponseViewModel<bool>>
    {
        public DeleteEndOfServiceEndPoint(EndPointBaseParameters<Guid> parameters) : base(parameters) { }

        [HttpDelete("{id:int}")]
        public async Task<ResponseViewModel<bool>> DeleteEndOfService(Guid id, CancellationToken ct)
        {
            var command = new DeleteEndOfServiceCommand(id);
            var result = await _mediator.Send(command, ct);

            if (!result.isSuccess)
            {
                return ResponseViewModel<bool>.Failure(result.message, result.errorCode);
            }

            return ResponseViewModel<bool>.Success(true, result.message);
        }
    }
}

