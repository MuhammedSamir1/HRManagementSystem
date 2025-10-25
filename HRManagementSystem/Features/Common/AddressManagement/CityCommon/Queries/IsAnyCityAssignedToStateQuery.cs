using HRManagementSystem.Common.BaseRequestHandler;
using HRManagementSystem.Common.Views.Response;
using HRManagementSystem.Data.Models.AddressEntity;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HRManagementSystem.Features.Common.AddressManagement.CityCommon.Queries
{
    public record IsAnyCityAssignedToStateQuery(int stateId) : IRequest<RequestResult<bool>>;

    public class IsAnyCityAssignedToStateQueryHandler : RequestHandlerBase<IsAnyCityAssignedToStateQuery, RequestResult<bool>,City,int>
    {
        public IsAnyCityAssignedToStateQueryHandler(RequestHandlerBaseParameters<City,int>_params):base(_params)
        {
            
        }

        public override async Task<RequestResult<bool>> Handle(IsAnyCityAssignedToStateQuery request, CancellationToken cancellationToken)
        {
            var hasCities = await _generalRepo.CheckAnyAsync(c => c.StateId == request.stateId, cancellationToken);
            if (hasCities)
            {
                return RequestResult<bool>.Success(true, "State has assigned cities.");
            }
            else
            {
                return RequestResult<bool>.Success(false, "State has no assigned cities.");
            }

        }
    }

}
