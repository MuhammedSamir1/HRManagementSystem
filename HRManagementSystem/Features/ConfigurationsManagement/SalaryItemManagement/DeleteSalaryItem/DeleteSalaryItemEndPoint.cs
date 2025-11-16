using HRManagementSystem.Features.ConfigurationsManagement.SalaryItemManagement.DeleteSalaryItem.Commands;

namespace HRManagementSystem.Features.ConfigurationsManagement.SalaryItemManagement.DeleteSalaryItem
{
    public class DeleteSalaryItemEndPoint : BaseEndPoint<Guid, ResponseViewModel<bool>>
    {
        public DeleteSalaryItemEndPoint(EndPointBaseParameters<Guid> parameters) : base(parameters) { }

        [HttpDelete("{id:int}")]
        public async Task<ResponseViewModel<bool>> DeleteSalaryItem(Guid id, CancellationToken ct)
        {
            var command = new DeleteSalaryItemCommand(id);
            var result = await _mediator.Send(command, ct);

            if (!result.isSuccess)
            {
                return ResponseViewModel<bool>.Failure(result.message, result.errorCode);
            }

            return ResponseViewModel<bool>.Success(true, result.message);
        }
    }
}

