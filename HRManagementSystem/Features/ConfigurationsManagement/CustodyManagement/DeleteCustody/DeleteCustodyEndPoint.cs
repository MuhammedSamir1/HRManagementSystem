using HRManagementSystem.Features.ConfigurationsManagement.CustodyManagement.DeleteCustody.Commands;

namespace HRManagementSystem.Features.Configurations.CustodyManagement.DeleteCustody
{
    [ApiGroup("Configurations Management", "Custody Management")]
    public class DeleteCustodyEndPoint : BaseEndPoint<Guid, ResponseViewModel<bool>>
    {

        public DeleteCustodyEndPoint(EndPointBaseParameters<Guid> parameters)
            : base(parameters)
        {

        }

        [HttpDelete("{id:int}")]
        public async Task<ResponseViewModel<bool>> DeleteCustody(Guid id, CancellationToken ct)
        {

            var command = new DeleteCustodyCommand(id);


            var result = await _mediator.Send(command, ct);


            if (!result.isSuccess)
            {

                return ResponseViewModel<bool>.Failure(result.message, result.errorCode);
            }


            return ResponseViewModel<bool>.Success(true, result.message);
        }
    }
}




