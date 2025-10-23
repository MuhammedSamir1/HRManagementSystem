using HRManagementSystem.Common.BaseEndPoints;
using HRManagementSystem.Common.Data.Enums;
using HRManagementSystem.Common.Views.Response;
using HRManagementSystem.Features.BranchManagement.DeleteBranch.Commands;
using Microsoft.AspNetCore.Mvc;

namespace HRManagementSystem.Features.BranchManagement.DeleteBranch
{
    public class DeleteBranchEndPoint : BaseEndPoint<DeleteBranchViewModel, ResponseViewModel<bool>>
    {
        public DeleteBranchEndPoint(EndPointBaseParameters<DeleteBranchViewModel> parameters)
            : base(parameters) { }

        [HttpDelete]
        public async Task<ResponseViewModel<bool>> DeleteBranch(DeleteBranchViewModel model, CancellationToken ct)
        {
            var validationResult = ValidateRequest(model);
            if (!validationResult.isSuccess)
                return ResponseViewModel<bool>.Failure(validationResult.errorCode);

            var isDeleted = await _mediator.Send(new DeleteBranchCommand(model.Id));
            if (!isDeleted.isSuccess) return ResponseViewModel<bool>.Failure(isDeleted.message,
                ErrorCode.BranchWasNotDeleted);

            return ResponseViewModel<bool>.Success(isDeleted.isSuccess, "Branch Deleted Successfully!");
        }
    }
}
