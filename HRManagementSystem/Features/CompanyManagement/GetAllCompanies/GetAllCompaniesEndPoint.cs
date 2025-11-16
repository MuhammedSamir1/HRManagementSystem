using HRManagementSystem.Features.CompanyManagement.GetAllCompanies.Queries;

namespace HRManagementSystem.Features.CompanyManagement.GetAllCompanies
{
    [ApiGroup("Company Management")]
    public class GetAllCompaniesEndPoint : BaseEndPoint<GetAllCompaniesRequestViewModel, ResponseViewModel<IEnumerable<GetAllCompaniesResponseViewModel>>>
    {
        public GetAllCompaniesEndPoint(EndPointBaseParameters<GetAllCompaniesRequestViewModel> parameters) : base(parameters)
        {
        }

        [HttpGet("GetAll")]
        public async Task<ResponseViewModel<IEnumerable<GetAllCompaniesResponseViewModel>>> GetAllCompanies([FromQuery] GetAllCompaniesRequestViewModel request, CancellationToken ct)
        {
            var validationResult = ValidateRequest(request);
            if (!validationResult.isSuccess)
            {
                return ResponseViewModel<IEnumerable<GetAllCompaniesResponseViewModel>>.Failure(validationResult.errorCode);
            }

            var result = await _mediator.Send(new GetAllCompaniesQuery(), ct);

            if (!result.isSuccess || result.data == null || !result.data.Any())
                return ResponseViewModel<IEnumerable<GetAllCompaniesResponseViewModel>>.Failure(ErrorCode.NotFound);

            var responseViewModel = _mapper.Map<IEnumerable<GetAllCompaniesResponseViewModel>>(result.data);

            return ResponseViewModel<IEnumerable<GetAllCompaniesResponseViewModel>>.Success(responseViewModel, "Companies returned successfully!");
        }

    }
}

