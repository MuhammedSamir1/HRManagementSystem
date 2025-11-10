using HRManagementSystem.Features.ConfigurationsManagement.EndOfServiceManagement.AddEndOfService.Commands;

namespace HRManagementSystem.Features.ConfigurationsManagement.EndOfServiceManagement.AddEndOfService
{
    public class AddEndOfServiceEndPoint : BaseEndPoint<AddEndOfServiceViewModel, ResponseViewModel<int>>
    {
        public AddEndOfServiceEndPoint(EndPointBaseParameters<AddEndOfServiceViewModel> parameters) : base(parameters) { }

        [HttpPost]
        public async Task<ResponseViewModel<int>> AddEndOfService([FromBody] AddEndOfServiceViewModel model, CancellationToken ct)
        {
            var command = _mapper.Map<AddEndOfServiceCommand>(model);
            var result = await _mediator.Send(command, ct);

            if (!result.isSuccess)
            {
                return ResponseViewModel<int>.Failure(result.message, result.errorCode);
            }

            return ResponseViewModel<int>.Success(result.data, result.message);
        }
    }
}
