using HRManagementSystem.Data.Models.AddressEntity;
using Microsoft.EntityFrameworkCore;

namespace HRManagementSystem.Features.CityManagement.GetAllCities.Queries
{
    public record GetAllCitiesQuery() : IRequest<RequestResult<List<ViewAllCitiesDto>>>;

    public sealed class GetAllCitiesCommandHandler
        : RequestHandlerBase<GetAllCitiesQuery, RequestResult<List<ViewAllCitiesDto>>, City, Guid>
    {
        public GetAllCitiesCommandHandler(RequestHandlerBaseParameters<City, Guid> parameters)
            : base(parameters)
        {
        }

        public override async Task<RequestResult<List<ViewAllCitiesDto>>> Handle(GetAllCitiesQuery request, CancellationToken ct)
        {
            var cities = await _generalRepo.GetAll().ToListAsync(ct);

            if (!cities.Any())
                return RequestResult<List<ViewAllCitiesDto>>.Failure("No cities found", ErrorCode.NotFound);

            var cityDtos = _mapper.Map<List<ViewAllCitiesDto>>(cities);

            return RequestResult<List<ViewAllCitiesDto>>.Success(cityDtos, "Cities retrieved successfully");
        }
    }
}

