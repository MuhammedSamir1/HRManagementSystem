using HRManagementSystem.Features.DepartmentManagement.GetAllDepartments.Queries;

namespace HRManagementSystem.Features.DepartmentManagement.GetAllDepartments
{
    [ApiGroup("Department Management")]
    public class GetAllDepartmentsEndPoint : BaseEndPoint<GetAllDepartmentsRequestViewModel, ResponseViewModel<IEnumerable<GetAllDepartmentsResponseViewModel>>>
    {
        public GetAllDepartmentsEndPoint(EndPointBaseParameters<GetAllDepartmentsRequestViewModel> parameters) : base(parameters)
        {
        }

        [HttpGet("GetAll")]
        public async Task<ResponseViewModel<IEnumerable<GetAllDepartmentsResponseViewModel>>> GetAllDepartments([FromQuery] GetAllDepartmentsRequestViewModel request, CancellationToken ct)
        {
            var validationResult = ValidateRequest(request);
            if (!validationResult.isSuccess)
            {
                return ResponseViewModel<IEnumerable<GetAllDepartmentsResponseViewModel>>.Failure(validationResult.errorCode);
            }

            var result = await _mediator.Send(new GetAllDepartmentsQuery(), ct);

            if (!result.isSuccess || result.data == null || !result.data.Any())
                return ResponseViewModel<IEnumerable<GetAllDepartmentsResponseViewModel>>.Failure(ErrorCode.NotFound);

            var responseViewModel = _mapper.Map<IEnumerable<GetAllDepartmentsResponseViewModel>>(result.data);

            return ResponseViewModel<IEnumerable<GetAllDepartmentsResponseViewModel>>.Success(responseViewModel, "Departments returned successfully!");
        }

    }
}

