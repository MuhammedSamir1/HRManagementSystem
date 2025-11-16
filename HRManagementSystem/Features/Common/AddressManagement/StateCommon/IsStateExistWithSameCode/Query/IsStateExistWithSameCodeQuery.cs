using HRManagementSystem.Data.Models.AddressEntity;
using Microsoft.EntityFrameworkCore;

namespace HRManagementSystem.Features.Common.AddressManagement.StateCommon.IsStateExistWithSameCode.Query
{
    public record IsStateExistWithSameCodeQuery(string code, Guid countryId) : IRequest<RequestResult<bool>>;

    public class IsStateExistWithSameCodeQueryHandler : RequestHandlerBase<IsStateExistWithSameCodeQuery, RequestResult<bool>, State, Guid>
    {

        public IsStateExistWithSameCodeQueryHandler(RequestHandlerBaseParameters<State, Guid> _params) : base(_params)
        {
        }
        public override async Task<RequestResult<bool>> Handle(IsStateExistWithSameCodeQuery request, CancellationToken ct)
        {
            var exists = await _generalRepo.Get(x =>
                x.Code == request.code &&
                x.CountryId == request.countryId &&
                !x.IsDeleted, ct)
                .AnyAsync(ct);
            if (exists)
            {
                return RequestResult<bool>.Success(exists);
            }
            else
            {
                return RequestResult<bool>.Failure("State with the same code does not exist.");
            }
        }
    }
}

