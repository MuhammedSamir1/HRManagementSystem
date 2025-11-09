using HRManagementSystem.Features.CustodyManagement.DeleteCustody.Commands;

namespace HRManagementSystem.Features.CustodyManagement.DeleteCustody
{
    public class DeleteCustodyEndPoint : BaseEndPoint<int, ResponseViewModel<bool>>
    {
      
        public DeleteCustodyEndPoint(EndPointBaseParameters<int> parameters)
            : base(parameters)
        {
      
        }

        [HttpDelete("{id:int}")] 
        public async Task<ResponseViewModel<bool>> DeleteCustody(int id, CancellationToken ct)
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
