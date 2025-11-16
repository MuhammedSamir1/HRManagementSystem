using HRManagementSystem.Features.ConfigurationsManagement.BonusManagement.AddBonus.Commands;

namespace HRManagementSystem.Features.ConfigurationsManagement.BonusManagement.AddBonus
{
    public class AddBonusEndPoint : BaseEndPoint<AddBonusViewModel, ResponseViewModel<Guid>>
    {
        public AddBonusEndPoint(EndPointBaseParameters<AddBonusViewModel> parameters) : base(parameters) { }

        [HttpPost]
        public async Task<ResponseViewModel<Guid>> AddBonus([FromBody] AddBonusViewModel model, CancellationToken ct)
        {
            var command = _mapper.Map<AddBonusCommand>(model);
            var result = await _mediator.Send(command, ct);

            if (!result.isSuccess)
            {
                return ResponseViewModel<Guid>.Failure(result.message, result.errorCode);
            }

            return ResponseViewModel<Guid>.Success(result.data, result.message);
        }
    }
}

