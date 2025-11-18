using HRManagementSystem.Features.ScopeManagement.DeleteScope.Commands;

namespace HRManagementSystem.Features.ScopeManagement.DeleteScope
{
    [ApiGroup("Configurations Management", "Scope Management")]
    public class DeleteScopeEndPoint : BaseEndPoint<Guid, ResponseViewModel<bool>>
    {
        public DeleteScopeEndPoint(EndPointBaseParameters<Guid> parameters)
            : base(parameters)
        {
        }

        [HttpDelete("{id:guid}")]
        public async Task<ResponseViewModel<bool>> DeleteScope(Guid id, CancellationToken ct)
        {
            var command = new DeleteScopeCommand(id);
            var result = await _mediator.Send(command, ct);

            if (!result.isSuccess)
            {
                return ResponseViewModel<bool>.Failure(result.message, result.errorCode);
            }

            return ResponseViewModel<bool>.Success(true, result.message);
        }
    }
}

