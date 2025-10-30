using HRManagementSystem.Features.DepartmentManagement.DeleteDepartment.Commands;

namespace HRManagementSystem.Features.DepartmentManagement.DeleteDepartment
{
    public class DeleteDepartmentEndPoint : BaseEndPoint<DeleteDepartmentRequestViewModel, ResponseViewModel<bool>>
    {
        public DeleteDepartmentEndPoint(EndPointBaseParameters<DeleteDepartmentRequestViewModel> parameters) : base(parameters) { }

        [HttpDelete("delete/{id:int}")]
        public async Task<ResponseViewModel<bool>> DeleteDepartment([FromRoute] int id, CancellationToken ct)
        {
            var model = new DeleteDepartmentRequestViewModel(id);
            var validationResult = ValidateRequest(model);
            if (!validationResult.isSuccess)
            {
                return ResponseViewModel<bool>.Failure(validationResult.errorCode);
            }

            var command = _mapper.Map<DeleteDepartmentCommand>(model);
            var result = await _mediator.Send(command, ct);


            if (!result.isSuccess)
            {
                return ResponseViewModel<bool>.Failure(result.message, result.errorCode);
            }

            return ResponseViewModel<bool>.Success(true, "Department Deleted Successfully!");
        }
    }
}
