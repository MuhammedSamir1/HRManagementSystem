using HRManagementSystem.Common.BaseRequestHandler;
using HRManagementSystem.Common.Views.Response;
using HRManagementSystem.Data.Models.AddressEntity;
using HRManagementSystem.Features.Common.AddressManagement.StateCommon.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HRManagementSystem.Features.StateManagement.GetAllStates.Queries
{
    public sealed record GetAllStatesQuery : IRequest<RequestResult<IEnumerable<ViewStateDto>>>;

    public sealed class GetAllStatesQueryHandler : RequestHandlerBase<GetAllStatesQuery,
        RequestResult<IEnumerable<ViewStateDto>>, State, int>
    {
        public GetAllStatesQueryHandler(RequestHandlerBaseParameters<State, int> parameters)
            : base(parameters) { }

        public override async Task<RequestResult<IEnumerable<ViewStateDto>>> Handle(GetAllStatesQuery request, CancellationToken ct)
        {
            var states = await _generalRepo.Get(x => !x.IsDeleted, ct)
                .ToListAsync(ct);
            var stateDtos = _mapper.Map<IEnumerable<ViewStateDto>>(states);

            #region Another way to mapping
            //var states = await _generalRepo.Get(x => !x.IsDeleted, ct)
            //.ProjectTo<ViewStateDto>(_mapper.ConfigurationProvider)
            //.ToListAsync(ct); 
            #endregion
            return RequestResult<IEnumerable<ViewStateDto>>.Success(stateDtos);
        }
    }
}
