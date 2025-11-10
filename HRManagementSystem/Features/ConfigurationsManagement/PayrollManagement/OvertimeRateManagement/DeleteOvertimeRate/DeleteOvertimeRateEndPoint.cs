namespace HRManagementSystem.Features.ConfigurationsManagement.PayrollManagement.OvertimeRateManagement.DeleteOvertimeRate
{
    public class DeleteOvertimeRateEndPoint : BaseEndPoint<int, ResponseViewModel<bool>>
    {
        public DeleteOvertimeRateEndPoint(EndPointBaseParameters<int> parameters) : base(parameters) { }


        [HttpDelete("payroll/overtime-rates/{id:int}")]

        public async Task<ResponseViewModel<bool>> Delete([FromRoute] int id, CancellationToken ct)
        {
            var cmd = new Commands.DeleteOvertimeRateCommand(id);
            var result = await _mediator.Send(cmd, ct);

            if (!result.isSuccess)
                return ResponseViewModel<bool>.Failure(result.message, result.errorCode);

            return ResponseViewModel<bool>.Success(result.data, result.message);
        }
    }
}
