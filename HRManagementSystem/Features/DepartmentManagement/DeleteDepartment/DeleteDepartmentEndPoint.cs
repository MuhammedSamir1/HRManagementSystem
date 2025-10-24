using HRManagementSystem.Common.BaseEndPoints;
using HRManagementSystem.Common.Data.Enums;
using HRManagementSystem.Common.Views.Response;
using HRManagementSystem.Features.DepartmentManagement.DeleteDepartment.Commands;
using Microsoft.AspNetCore.Mvc;

namespace HRManagementSystem.Features.DepartmentManagement.DeleteDepartment
{
    public class DeleteDepartmentEndPoint : BaseEndPoint<DeleteDepartmentRequestViewModel, ResponseViewModel<bool>>
    {
        public DeleteDepartmentEndPoint(EndPointBaseParameters<DeleteDepartmentRequestViewModel> parameters)
                 : base(parameters) { }

        [HttpDelete]
        public async Task<ResponseViewModel<bool>> DeleteOrganization(DeleteDepartmentRequestViewModel model, CancellationToken ct)
        {
            var validationResult = ValidateRequest(model);
            if (!validationResult.isSuccess)
                return ResponseViewModel<bool>.Failure(validationResult.errorCode);

            var isDeleted = await _mediator.Send(new DeleteDepartmentCommand(model.departmentId));
            if (!isDeleted.isSuccess) return ResponseViewModel<bool>.Failure(ErrorCode.NotFound);

            return ResponseViewModel<bool>.Success(isDeleted.isSuccess, "Department Deleted Successfully!");
        }
    }
}
