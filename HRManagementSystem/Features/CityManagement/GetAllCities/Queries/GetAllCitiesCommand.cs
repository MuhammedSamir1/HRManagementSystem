using HRManagementSystem.Common.BaseRequestHandler;
using HRManagementSystem.Common.Data.Enums;
using HRManagementSystem.Common.Views.Response;
using HRManagementSystem.Data.Models.AddressEntity;
using HRManagementSystem.Features.Common.AddressManagement.GetAllCities.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HRManagementSystem.Features.Common.AddressManagement.GetAllCities.Commands
{
    public record GetAllCitiesCommand() : IRequest<RequestResult<List<GetAllCitiesDto>>>;

    public sealed class GetAllCitiesCommandHandler
        : RequestHandlerBase<GetAllCitiesCommand, RequestResult<List<GetAllCitiesDto>>, City, int>
    {
        public GetAllCitiesCommandHandler(RequestHandlerBaseParameters<City, int> parameters)
            : base(parameters)
        {
        }

        public override async Task<RequestResult<List<GetAllCitiesDto>>> Handle(GetAllCitiesCommand request, CancellationToken ct)
        {
            var cities = await _generalRepo.GetAll().ToListAsync(ct);

            if (!cities.Any())
                return RequestResult<List<GetAllCitiesDto>>.Failure("No cities found", ErrorCode.NotFound);

            var cityDtos = _mapper.Map<List<GetAllCitiesDto>>(cities);

            return RequestResult<List<GetAllCitiesDto>>.Success(cityDtos, "Cities retrieved successfully");
        }
    }
}
