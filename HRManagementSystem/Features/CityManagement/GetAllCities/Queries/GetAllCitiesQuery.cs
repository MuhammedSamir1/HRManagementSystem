using HRManagementSystem.Data.Models.AddressEntity;
using HRManagementSystem.Features.CityManagement.GetAllCities;
using Microsoft.EntityFrameworkCore;

namespace HRManagementSystem.Features.Common.AddressManagement.GetAllCities.Commands
{
    public record GetAllCitiesQuery() : IRequest<RequestResult<List<ViewAllCitiesDto>>>;

    public sealed class GetAllCitiesCommandHandler
        : RequestHandlerBase<GetAllCitiesQuery, RequestResult<List<ViewAllCitiesDto>>, City, int>
    {
        public GetAllCitiesCommandHandler(RequestHandlerBaseParameters<City, int> parameters)
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
