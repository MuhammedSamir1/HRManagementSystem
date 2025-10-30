using HRManagementSystem.Data.Models.AddressEntity;
using Microsoft.EntityFrameworkCore;

namespace HRManagementSystem.Features.CityManagement.HasAssignedCities
{
    public sealed class HasAssignedCitiesQueryHandler : RequestHandlerBase<HasAssignedCitiesQuery, RequestResult<bool>, City, int>
    {
        public HasAssignedCitiesQueryHandler(RequestHandlerBaseParameters<City, int> parameters) : base(parameters) { }

        public override async Task<RequestResult<bool>> Handle(HasAssignedCitiesQuery request, CancellationToken ct)
        {

            var hasCities = await _generalRepo
                .Get(c => c.State.CountryId == request.CountryId, ct)
                .AnyAsync(ct);

            if (hasCities)
            {

                return RequestResult<bool>.Failure("Cannot delete country: It has active assigned cities.", ErrorCode.Conflict);
            }
            return RequestResult<bool>.Success(true);
        }
    }
}
