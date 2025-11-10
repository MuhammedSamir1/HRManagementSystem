using HRManagementSystem.Features.ConfigurationsManagement.SalaryItemManagement.UpdateSalaryItem.Commands;

namespace HRManagementSystem.Features.ConfigurationsManagement.SalaryItemManagement.UpdateSalaryItem
{
    public class UpdateSalaryItemEndPoint : BaseEndPoint<UpdateSalaryItemViewModel, ResponseViewModel<bool>>
    {
        public UpdateSalaryItemEndPoint(EndPointBaseParameters<UpdateSalaryItemViewModel> parameters) : base(parameters) { }

        [HttpPut]
        public async Task<ResponseViewModel<bool>> UpdateSalaryItem([FromBody] UpdateSalaryItemViewModel model, CancellationToken ct)
        {
            var command = _mapper.Map<UpdateSalaryItemCommand>(model);
            var result = await _mediator.Send(command, ct);

            if (!result.isSuccess)
            {
                return ResponseViewModel<bool>.Failure(result.message, result.errorCode);
            }

            return ResponseViewModel<bool>.Success(true, result.message);
        }
    }
}
