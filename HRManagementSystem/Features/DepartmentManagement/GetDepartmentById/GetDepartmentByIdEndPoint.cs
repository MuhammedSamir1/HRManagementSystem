using HRManagementSystem.Features.DepartmentManagement.GetDepartmentById.Queries;

namespace HRManagementSystem.Features.DepartmentManagement.GetDepartmentById
{
    [ApiGroup("Department Management")]
    public class GetDepartmentByIdEndPoint : BaseEndPoint<GetDepartmentByIdRequestViewModel, ResponseViewModel<GetDepartmentByIdResponseViewModel>>
    {
        public GetDepartmentByIdEndPoint(EndPointBaseParameters<GetDepartmentByIdRequestViewModel> parameters) : base(parameters)
        {
        }

        [HttpGet("GetDepartmentById")]
        public async Task<ResponseViewModel<GetDepartmentByIdResponseViewModel>> GetDepartmentById([FromQuery] GetDepartmentByIdRequestViewModel model)
        {
            var validationResult = ValidateRequest(model);
            if (!validationResult.isSuccess)
                return ResponseViewModel<GetDepartmentByIdResponseViewModel>.Failure(validationResult.errorCode);

            var result = await _mediator.Send(new GetDepartmentByIdQuery(model.departmentId));

            if (!result.isSuccess || result.data is null)
                return ResponseViewModel<GetDepartmentByIdResponseViewModel>.Failure(ErrorCode.NotFound);

            var mappedCompany = _mapper.Map<GetDepartmentByIdResponseViewModel>(result.data);

            return ResponseViewModel<GetDepartmentByIdResponseViewModel>.Success(mappedCompany, "Department returned Successfully!");
        }
    }
}

