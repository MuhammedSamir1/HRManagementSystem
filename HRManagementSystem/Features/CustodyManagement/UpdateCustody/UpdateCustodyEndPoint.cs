using HRManagementSystem.Features.CustodyManagement.UpdateCustody.Commands;

namespace HRManagementSystem.Features.CustodyManagement.UpdateCustody
{
    public class UpdateCustodyEndPoint : BaseEndPoint<UpdateCustodyViewModel, ResponseViewModel<bool>>
    {
      
        public UpdateCustodyEndPoint(EndPointBaseParameters<UpdateCustodyViewModel> parameters)
            : base(parameters)
        {
           
        }

        
        [HttpPut]
     
        public async Task<ResponseViewModel<bool>> UpdateCustody([FromBody] UpdateCustodyViewModel model, CancellationToken ct)
        {
        
            var command = _mapper.Map<UpdateCustodyCommand>(model);

          
            var result = await _mediator.Send(command, ct);

        
            if (!result.isSuccess)
            {
               
                return ResponseViewModel<bool>.Failure(result.message, result.errorCode);
            }

        
            return ResponseViewModel<bool>.Success(true, result.message);
        }
    }
}
