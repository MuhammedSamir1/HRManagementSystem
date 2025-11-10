using HRManagementSystem.Features.ConfigurationsManagement.BonusManagement.AddBonus.Commands;

namespace HRManagementSystem.Features.ConfigurationsManagement.BonusManagement.AddBonus
{
    public class AddBonusEndPoint : BaseEndPoint<AddBonusViewModel, ResponseViewModel<int>>
    {
        public AddBonusEndPoint(EndPointBaseParameters<AddBonusViewModel> parameters) : base(parameters) { }

        [HttpPost]
        public async Task<ResponseViewModel<int>> AddBonus([FromBody] AddBonusViewModel model, CancellationToken ct)
        {
            var command = _mapper.Map<AddBonusCommand>(model);
            var result = await _mediator.Send(command, ct);

            if (!result.isSuccess)
            {
                return ResponseViewModel<int>.Failure(result.message, result.errorCode);
            }

            return ResponseViewModel<int>.Success(result.data, result.message);
        }
    }
}
