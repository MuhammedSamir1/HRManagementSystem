using HRManagementSystem.Features.ConfigurationsManagement.BonusManagement.UpdateBonus.Commands;

namespace HRManagementSystem.Features.ConfigurationsManagement.BonusManagement.UpdateBonus
{
    [ApiGroup("Configurations Management", "Bonus Management")]
    public class UpdateBonusEndPoint : BaseEndPoint<UpdateBonusViewModel, ResponseViewModel<bool>>
    {
        public UpdateBonusEndPoint(EndPointBaseParameters<UpdateBonusViewModel> parameters) : base(parameters) { }

        [HttpPut]
        public async Task<ResponseViewModel<bool>> UpdateBonus([FromBody] UpdateBonusViewModel model, CancellationToken ct)
        {
            var command = _mapper.Map<UpdateBonusCommand>(model);
            var result = await _mediator.Send(command, ct);

            if (!result.isSuccess)
            {
                return ResponseViewModel<bool>.Failure(result.message, result.errorCode);
            }

            return ResponseViewModel<bool>.Success(true, result.message);
        }
    }
}



