using HRManagementSystem.Data.Models.AddressEntity;
using Microsoft.EntityFrameworkCore;

namespace HRManagementSystem.Features.Common.CountryCommon.Queries
{
    public sealed class IsCountryExistQueryHandler : RequestHandlerBase<IsCountryExistQuery, RequestResult<bool>, Country, Guid>
    {

        public IsCountryExistQueryHandler(RequestHandlerBaseParameters<Country, Guid> parameters) : base(parameters) { }

        public override async Task<RequestResult<bool>> Handle(IsCountryExistQuery request, CancellationToken ct)
        {
            var isExist = await _generalRepo
                .Get(c => c.Iso3 == request.Iso3, ct)
                .AnyAsync(ct);

            if (isExist)
            {

                return RequestResult<bool>.Failure("Country with this ISO3 code already exists.", ErrorCode.Conflict);
            }
            return RequestResult<bool>.Success(isExist);
        }
    }
}

