using HRManagementSystem.Features.ConfigurationsManagement.SalaryItemManagement.AddSalaryItem.Commands;

namespace HRManagementSystem.Features.ConfigurationsManagement.SalaryItemManagement.AddSalaryItem
{
    public class AddSalaryItemEndPoint : BaseEndPoint<AddSalaryItemViewModel, ResponseViewModel<int>>
    {
        public AddSalaryItemEndPoint(EndPointBaseParameters<AddSalaryItemViewModel> parameters) : base(parameters) { }

        [HttpPost]
        public async Task<ResponseViewModel<int>> AddSalaryItem([FromBody] AddSalaryItemViewModel model, CancellationToken ct)
        {
            var command = _mapper.Map<AddSalaryItemCommand>(model);
            var result = await _mediator.Send(command, ct);

            if (!result.isSuccess)
            {
                return ResponseViewModel<int>.Failure(result.message, result.errorCode);
            }

            return ResponseViewModel<int>.Success(result.data, result.message);
        }
    }
}
