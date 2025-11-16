using HRManagementSystem.Features.ConfigurationsManagement.EndOfServiceManagement.AddEndOfService.Commands;

namespace HRManagementSystem.Features.ConfigurationsManagement.EndOfServiceManagement.AddEndOfService
{
    public class AddEndOfServiceEndPoint : BaseEndPoint<AddEndOfServiceViewModel, ResponseViewModel<Guid>>
    {
        public AddEndOfServiceEndPoint(EndPointBaseParameters<AddEndOfServiceViewModel> parameters) : base(parameters) { }

        [HttpPost]
        public async Task<ResponseViewModel<Guid>> AddEndOfService([FromBody] AddEndOfServiceViewModel model, CancellationToken ct)
        {
            var command = _mapper.Map<AddEndOfServiceCommand>(model);
            var result = await _mediator.Send(command, ct);

            if (!result.isSuccess)
            {
                return ResponseViewModel<Guid>.Failure(result.message, result.errorCode);
            }

            return ResponseViewModel<Guid>.Success(result.data, result.message);
        }
    }
}

