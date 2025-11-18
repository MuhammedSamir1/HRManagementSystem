using HRManagementSystem.Features.ScopeManagement.UpdateScope.Commands;

namespace HRManagementSystem.Features.ScopeManagement.UpdateScope
{
    [ApiGroup("Configurations Management", "Scope Management")]
    public class UpdateScopeEndPoint : BaseEndPoint<UpdateScopeViewModel, ResponseViewModel<bool>>
    {
        public UpdateScopeEndPoint(EndPointBaseParameters<UpdateScopeViewModel> parameters)
            : base(parameters)
        {
        }

        [HttpPut]
        public async Task<ResponseViewModel<bool>> UpdateScope([FromBody] UpdateScopeViewModel model, CancellationToken ct)
        {
            var command = _mapper.Map<UpdateScopeCommand>(model);
            var result = await _mediator.Send(command, ct);

            if (!result.isSuccess)
            {
                return ResponseViewModel<bool>.Failure(result.message, result.errorCode);
            }

            return ResponseViewModel<bool>.Success(true, result.message);
        }
    }
}

