using HRManagementSystem.Features.ConfigurationsManagement.ProbationPeriodManagement.GetProbationPeriodById.Queries;

namespace HRManagementSystem.Features.ConfigurationsManagement.ProbationPeriodManagement.GetProbationPeriodById
{
    public class GetProbationPeriodByIdEndPoint : BaseEndPoint<GetProbationPeriodByIdViewModel,
       ResponseViewModel<ViewProbationPeriodByIdViewModel>>
    {
        public GetProbationPeriodByIdEndPoint(EndPointBaseParameters<GetProbationPeriodByIdViewModel> parameters)
            : base(parameters) { }

        [HttpGet("id")]
        public async Task<ResponseViewModel<ViewProbationPeriodByIdViewModel>> GetById([FromQuery] GetProbationPeriodByIdViewModel model)
        {
            var validationResult = ValidateRequest(model);
            if (!validationResult.isSuccess)
            {
                return ResponseViewModel<ViewProbationPeriodByIdViewModel>.Failure(validationResult.errorCode);
            }

            var probationPeriod = await _mediator.Send(new GetProbationPeriodByIdQuery(model.Id));

            if (probationPeriod is null) return ResponseViewModel<ViewProbationPeriodByIdViewModel>.Failure(probationPeriod.message,
                ErrorCode.ProbationPeriodNotFound);

            var vm = _mapper.Map<ViewProbationPeriodByIdViewModel>(probationPeriod.data);
            return ResponseViewModel<ViewProbationPeriodByIdViewModel>.Success(vm);
        }
    }
}

