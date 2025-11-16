using HRManagementSystem.Features.ConfigurationsManagement.BonusManagement.DeleteBonus.Commands;

namespace HRManagementSystem.Features.ConfigurationsManagement.BonusManagement.DeleteBonus
{
    public class DeleteBonusEndPoint : BaseEndPoint<Guid, ResponseViewModel<bool>>
    {
        public DeleteBonusEndPoint(EndPointBaseParameters<Guid> parameters) : base(parameters) { }

        [HttpDelete("{id:int}")]
        public async Task<ResponseViewModel<bool>> DeleteBonus(Guid id, CancellationToken ct)
        {
            var command = new DeleteBonusCommand(id);
            var result = await _mediator.Send(command, ct);

            if (!result.isSuccess)
            {
                return ResponseViewModel<bool>.Failure(result.message, result.errorCode);
            }

            return ResponseViewModel<bool>.Success(true, result.message);
        }
    }
}

