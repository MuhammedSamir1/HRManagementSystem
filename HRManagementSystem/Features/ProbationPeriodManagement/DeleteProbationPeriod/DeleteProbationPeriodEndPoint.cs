using HRManagementSystem.Features.ProbationPeriodManagement.DeleteProbationPeriod.Commands;

namespace HRManagementSystem.Features.ProbationPeriodManagement.DeleteProbationPeriod
{
    public class DeleteProbationPeriodEndPoint : BaseEndPoint<DeleteProbationPeriodViewModel, ResponseViewModel<bool>>
    {
        public DeleteProbationPeriodEndPoint(EndPointBaseParameters<DeleteProbationPeriodViewModel> parameters)
            : base(parameters) { }

        [HttpDelete]
        public async Task<ResponseViewModel<bool>> DeleteProbationPeriod(DeleteProbationPeriodViewModel model, CancellationToken ct)
        {
            var validationResult = ValidateRequest(model);
            if (!validationResult.isSuccess)
                return ResponseViewModel<bool>.Failure(validationResult.errorCode);

            var isDeleted = await _mediator.Send(new DeleteProbationPeriodCommand(model.Id));
            if (!isDeleted.isSuccess) return ResponseViewModel<bool>.Failure(isDeleted.message,
                ErrorCode.ProbationPeriodWasNotDeleted);

            return ResponseViewModel<bool>.Success(isDeleted.isSuccess, "Probation Period Deleted Successfully!");
        }
    }
}

