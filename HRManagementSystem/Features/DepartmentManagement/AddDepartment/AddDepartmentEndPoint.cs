using HRManagementSystem.Common.BaseEndPoints;
using HRManagementSystem.Common.Views.Response;
using HRManagementSystem.Features.DepartmentManagement.AddDepartment.Commands;
using Microsoft.AspNetCore.Mvc;

namespace HRManagementSystem.Features.DepartmentManagement.AddDepartment
{
    public class AddDepartmentEndPoint : BaseEndPoint<AddDepartmentRequestViewModel, ResponseViewModel<bool>>
    {
        public AddDepartmentEndPoint(EndPointBaseParameters<AddDepartmentRequestViewModel> parameters) : base(parameters)
        {
        }

        [HttpPost("add")]
        public async Task<ResponseViewModel<bool>> AddDepartment([FromQuery] AddDepartmentRequestViewModel model, CancellationToken ct)
        {
            var validationResult = ValidateRequest(model);
            if (!validationResult.isSuccess)
            {
                return ResponseViewModel<bool>.Failure(validationResult.errorCode);
            }

            var result = await _mediator.Send(new AddDepartmentCommand(
                                                    model.branchId,
                                                    model.name,
                                                    model.code,
                                                    model.description), ct);

            if (!result.isSuccess) return ResponseViewModel<bool>.Failure(result.errorCode);
            return ResponseViewModel<bool>.Success(true, "Department Added Successfully!");
        }
    }
}
