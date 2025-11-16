using HRManagementSystem.Features.ConfigurationsManagement.SalaryItemManagement.GetSalaryItemById.Queries;

namespace HRManagementSystem.Features.ConfigurationsManagement.SalaryItemManagement.GetSalaryItemById
{
    public class GetSalaryItemByIdEndPoint : BaseEndPoint<GetSalaryItemByIdViewModel, ResponseViewModel<ViewSalaryItemByIdViewModel>>
    {
        public GetSalaryItemByIdEndPoint(EndPointBaseParameters<GetSalaryItemByIdViewModel> parameters) : base(parameters) { }

        [HttpGet("{id:int}")]
        public async Task<ResponseViewModel<ViewSalaryItemByIdViewModel>> GetSalaryItemById(Guid id, CancellationToken ct)
        {
            var query = new GetSalaryItemByIdQuery(id);
            var result = await _mediator.Send(query, ct);

            if (!result.isSuccess)
            {
                return ResponseViewModel<ViewSalaryItemByIdViewModel>.Failure(result.message, result.errorCode);
            }

            var mapped = _mapper.Map<ViewSalaryItemByIdViewModel>(result.data);

            return ResponseViewModel<ViewSalaryItemByIdViewModel>.Success(mapped);
        }
    }
}

