using HRManagementSystem.Features.ConfigurationsManagement.ProbationPeriodManagement.UpdateProbationPeriod.Commands;

namespace HRManagementSystem.Features.ConfigurationsManagement.ProbationPeriodManagement.UpdateProbationPeriod
{
    public class UpdateProbationPeriodEndPoint : BaseEndPoint<UpdateProbationPeriodViewModel, RequestResult<bool>>
    {
        public UpdateProbationPeriodEndPoint(EndPointBaseParameters<UpdateProbationPeriodViewModel> parameters) : base(parameters) { }

        [HttpPut("update")]
        public async Task<ResponseViewModel<bool>> UpdateProbationPeriod([FromQuery] UpdateProbationPeriodViewModel model, CancellationToken ct)
        {
            var validationResult = ValidateRequest(model);
            if (!validationResult.isSuccess)
            {
                return ResponseViewModel<bool>.Failure(validationResult.errorCode);
            }

            var result = await _mediator.Send(new UpdateProbationPeriodCommand(model.Id, model.StartDate,
                model.EndDate, model.DurationInDays, model.IsApproved, model.ApprovalDate, model.Status), ct);

            if (!result.isSuccess) return ResponseViewModel<bool>.Failure(result.message, result.errorCode);
            return ResponseViewModel<bool>.Success(result.isSuccess, "Probation Period Updated Successfully!");
        }
    }
}

