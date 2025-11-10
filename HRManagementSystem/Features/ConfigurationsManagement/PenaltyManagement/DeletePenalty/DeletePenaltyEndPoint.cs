using HRManagementSystem.Features.ConfigurationsManagement.PenaltyManagement.DeletePenalty.Commands;

namespace HRManagementSystem.Features.ConfigurationsManagement.PenaltyManagement.DeletePenalty
{
    public class DeletePenaltyEndPoint : BaseEndPoint<int, ResponseViewModel<bool>>
    {
        public DeletePenaltyEndPoint(EndPointBaseParameters<int> parameters) : base(parameters) { }

        [HttpDelete("{id:int}")]
        public async Task<ResponseViewModel<bool>> DeletePenalty(int id, CancellationToken ct)
        {
            var command = new DeletePenaltyCommand(id);
            var result = await _mediator.Send(command, ct);

            if (!result.isSuccess)
            {
                return ResponseViewModel<bool>.Failure(result.message, result.errorCode);
            }

            return ResponseViewModel<bool>.Success(true, result.message);
        }
    }
}
