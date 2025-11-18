using HRManagementSystem.Common.Extensions;
using HRManagementSystem.Common.Views;
using HRManagementSystem.Features.ScopeManagement.GetAllScopes.Queries;

namespace HRManagementSystem.Features.ScopeManagement.GetAllScopes
{
    [ApiGroup("Configurations Management", "Scope Management")]
    public class GetAllScopesEndPoint : BaseEndPoint<GetAllScopesViewModel, ResponseViewModel<object>>
    {
        public GetAllScopesEndPoint(EndPointBaseParameters<GetAllScopesViewModel> parameters)
            : base(parameters)
        {
        }

        [HttpGet]
        public async Task<ResponseViewModel<PagedList<ViewScopeViewModel>>> GetAllScopes([FromQuery] GetAllScopesViewModel model, CancellationToken ct)
        {
            var query = _mapper.Map<GetAllScopesQuery>(model);
            var result = await _mediator.Send(query, ct);

            if (!result.isSuccess)
            {
                return ResponseViewModel<PagedList<ViewScopeViewModel>>.Failure(result.message, result.errorCode);
            }

            var mappedPagedList = result.data!.MapTo<ViewScopeDto, ViewScopeViewModel>(_mapper.ConfigurationProvider);
            return ResponseViewModel<PagedList<ViewScopeViewModel>>.Success(mappedPagedList);
        }
    }
}

