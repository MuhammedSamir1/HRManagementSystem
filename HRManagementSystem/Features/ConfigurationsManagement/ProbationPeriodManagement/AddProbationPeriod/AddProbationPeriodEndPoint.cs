using HRManagementSystem.Features.ConfigurationsManagement.ProbationPeriodManagement.AddProbationPeriod.Commands;

namespace HRManagementSystem.Features.ConfigurationsManagement.ProbationPeriodManagement.AddProbationPeriod
{
    public class AddProbationPeriodEndPoint : BaseEndPoint<AddProbationPeriodViewModel, ResponseViewModel<bool>>
    {
        public AddProbationPeriodEndPoint(EndPointBaseParameters<AddProbationPeriodViewModel> parameters)
            : base(parameters) { }

        [HttpPost]
        public async Task<ResponseViewModel<bool>> AddProbationPeriod([FromQuery] AddProbationPeriodViewModel model, CancellationToken ct)
        {
            var validationResult = ValidateRequest(model);
            if (!validationResult.isSuccess)
            {
                return ResponseViewModel<bool>.Failure(validationResult.errorCode);
            }

            var result = await _mediator.Send(new AddProbationPeriodCommand(model.StartDate, model.EndDate,
                model.DurationInDays, model.IsApproved, model.ApprovalDate, model.Status), ct);


            if (!result.isSuccess) return ResponseViewModel<bool>.Failure(result.message, result.errorCode);
            return ResponseViewModel<bool>.Success(true, "Probation Period Added Successfully!");
        }
    }
}

