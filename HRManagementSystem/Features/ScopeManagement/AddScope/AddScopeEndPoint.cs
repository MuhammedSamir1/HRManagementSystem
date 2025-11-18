using HRManagementSystem.Features.ScopeManagement.AddScope.Commands;

namespace HRManagementSystem.Features.ScopeManagement.AddScope
{
    [ApiGroup("Configurations Management", "Scope Management")]
    public class AddScopeEndPoint : BaseEndPoint<AddScopeViewModel, ResponseViewModel<Guid>>
    {
        public AddScopeEndPoint(EndPointBaseParameters<AddScopeViewModel> parameters)
            : base(parameters)
        {
        }

        [HttpPost]
        public async Task<ResponseViewModel<Guid>> AddScope([FromBody] AddScopeViewModel model, CancellationToken ct)
        {
            var command = _mapper.Map<AddScopeCommand>(model);
            var result = await _mediator.Send(command, ct);

            if (!result.isSuccess)
            {
                return ResponseViewModel<Guid>.Failure(result.message, result.errorCode);
            }

            return ResponseViewModel<Guid>.Success(result.data, result.message);
        }
    }
}

