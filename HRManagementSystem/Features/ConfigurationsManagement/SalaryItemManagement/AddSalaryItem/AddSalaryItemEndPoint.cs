using HRManagementSystem.Features.ConfigurationsManagement.SalaryItemManagement.AddSalaryItem.Commands;

namespace HRManagementSystem.Features.ConfigurationsManagement.SalaryItemManagement.AddSalaryItem
{
    public class AddSalaryItemEndPoint : BaseEndPoint<AddSalaryItemViewModel, ResponseViewModel<Guid>>
    {
        public AddSalaryItemEndPoint(EndPointBaseParameters<AddSalaryItemViewModel> parameters) : base(parameters) { }

        [HttpPost]
        public async Task<ResponseViewModel<Guid>> AddSalaryItem([FromBody] AddSalaryItemViewModel model, CancellationToken ct)
        {
            var command = _mapper.Map<AddSalaryItemCommand>(model);
            var result = await _mediator.Send(command, ct);

            if (!result.isSuccess)
            {
                return ResponseViewModel<Guid>.Failure(result.message, result.errorCode);
            }

            return ResponseViewModel<Guid>.Success(result.data, result.message);
        }
    }
}

