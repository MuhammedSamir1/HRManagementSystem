using HRManagementSystem.Features.ProbationPeriodManagement.GetAllProbationPeriods.Queries;

namespace HRManagementSystem.Features.ProbationPeriodManagement.GetAllProbationPeriods
{
    public class GetAllProbationPeriodsEndPoint : BaseEndPoint<GetAllProbationPeriodsViewModel,
       ResponseViewModel<ViewProbationPeriodViewModel>>
    {
        public GetAllProbationPeriodsEndPoint(EndPointBaseParameters<GetAllProbationPeriodsViewModel> parameters)
            : base(parameters) { }

        [HttpGet("id")]
        public async Task<ResponseViewModel<List<ViewProbationPeriodViewModel>>> GetById([FromQuery] GetAllProbationPeriodsViewModel model)
        {
            var validationResult = ValidateRequest(model);
            if (!validationResult.isSuccess)
            {
                return ResponseViewModel<List<ViewProbationPeriodViewModel>>.Failure(validationResult.errorCode);
            }

            var probationPeriod = await _mediator.Send(new GetAllProbationPeriodsQuery());

            if (probationPeriod is null) return ResponseViewModel<List<ViewProbationPeriodViewModel>>.Failure(probationPeriod.message,
                ErrorCode.ProbationPeriodNotFound);

            var vm = _mapper.Map<List<ViewProbationPeriodViewModel>>(probationPeriod.data);
            return ResponseViewModel<List<ViewProbationPeriodViewModel>>.Success(vm);
        }
    }
}

