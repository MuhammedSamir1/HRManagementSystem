using HRManagementSystem.Features.CustodyManagement.AddCustody.Commands;

namespace HRManagementSystem.Features.CustodyManagement.AddCustody
{
    public class AddCustodyEndPoint : BaseEndPoint<AddCustodyViewModel, ResponseViewModel<int>>
    {
       
        public AddCustodyEndPoint(EndPointBaseParameters<AddCustodyViewModel> parameters) : base(parameters) { }

        [HttpPost]
        public async Task<ResponseViewModel<int>> AddCustody([FromBody] AddCustodyViewModel model, CancellationToken ct)
        {

            var command = _mapper.Map<AddCustodyCommand>(model);

            var result = await _mediator.Send(command, ct);

            if (!result.isSuccess)
            {
                return ResponseViewModel<int>.Failure(result.message, result.errorCode);
            }

         
            return ResponseViewModel<int>.Success(result.data, "تم إنشاء العهدة بنجاح.");
        }
    }
}
