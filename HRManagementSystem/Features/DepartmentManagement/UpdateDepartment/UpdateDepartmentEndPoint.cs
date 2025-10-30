using HRManagementSystem.Features.DepartmentManagement.UpdateDepartment.Commands;

namespace HRManagementSystem.Features.DepartmentManagement.UpdateDepartment
{
    public class UpdateDepartmentEndPoint : BaseEndPoint<UpdateDepartmentRequestViewModel, ResponseViewModel<bool>>
    {
        public UpdateDepartmentEndPoint(EndPointBaseParameters<UpdateDepartmentRequestViewModel> parameters) : base(parameters) { }

        [HttpPut("update")]
        public async Task<ResponseViewModel<bool>> UpdateDepartment([FromQuery] UpdateDepartmentRequestViewModel model, CancellationToken ct)
        {
            var validationResult = ValidateRequest(model);
            if (!validationResult.isSuccess)
            {
                return ResponseViewModel<bool>.Failure(validationResult.errorCode);
            }


            var command = _mapper.Map<UpdateDepartmentCommand>(model);
            var result = await _mediator.Send(command, ct);


            if (!result.isSuccess)
            {

                return ResponseViewModel<bool>.Failure(result.message, result.errorCode);
            }

            return ResponseViewModel<bool>.Success(true, "Department Updated Successfully!");
        }
    }
}
