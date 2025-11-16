using HRManagementSystem.Features.ConfigurationsManagement.CustodyManagement.AddCustody.Commands;

namespace HRManagementSystem.Features.ConfigurationsManagement.CustodyManagement.AddCustody
{
    public class AddCustodyEndPoint : BaseEndPoint<AddCustodyViewModel, ResponseViewModel<Guid>>
    {

        public AddCustodyEndPoint(EndPointBaseParameters<AddCustodyViewModel> parameters) : base(parameters) { }

        [HttpPost]
        public async Task<ResponseViewModel<Guid>> AddCustody([FromBody] AddCustodyViewModel model, CancellationToken ct)
        {

            var command = _mapper.Map<AddCustodyCommand>(model);

            var result = await _mediator.Send(command, ct);

            if (!result.isSuccess)
            {
                return ResponseViewModel<Guid>.Failure(result.message, result.errorCode);
            }


            return ResponseViewModel<Guid>.Success(result.data, "?? ????? ?????? ?????.");
        }
    }
}

