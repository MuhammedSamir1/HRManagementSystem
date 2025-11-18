using HRManagementSystem.Features.ScopeManagement.GetScopeById.Queries;

namespace HRManagementSystem.Features.ScopeManagement.GetScopeById
{
    [ApiGroup("Configurations Management", "Scope Management")]
    public class GetScopeByIdEndPoint : BaseEndPoint<GetScopeByIdViewModel, ResponseViewModel<ViewScopeByIdViewModel>>
    {
        public GetScopeByIdEndPoint(EndPointBaseParameters<GetScopeByIdViewModel> parameters)
            : base(parameters)
        {
        }

        [HttpGet("{id:guid}")]
        public async Task<ResponseViewModel<ViewScopeByIdViewModel>> GetScopeById(Guid id, CancellationToken ct)
        {
            var viewModel = new GetScopeByIdViewModel(id);
            var query = _mapper.Map<GetScopeByIdQuery>(viewModel);
            var result = await _mediator.Send(query, ct);

            if (!result.isSuccess)
            {
                return ResponseViewModel<ViewScopeByIdViewModel>.Failure(result.message, result.errorCode);
            }

            var mapped = _mapper.Map<ViewScopeByIdViewModel>(result.data);
            return ResponseViewModel<ViewScopeByIdViewModel>.Success(mapped);
        }
    }
}

