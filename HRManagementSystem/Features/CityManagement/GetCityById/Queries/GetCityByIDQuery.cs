using HRManagementSystem.Data.Models.AddressEntity;

namespace HRManagementSystem.Features.CityManagement.GetCityById.Queries
{
    public record GetCityByIDQuery(int Id) : IRequest<RequestResult<GetCityByIdDto>>;

    public sealed class GetCityByIdCommandHandler
        : RequestHandlerBase<GetCityByIDQuery, RequestResult<GetCityByIdDto>, City, int>
    {
        public GetCityByIdCommandHandler(RequestHandlerBaseParameters<City, int> parameters)
            : base(parameters)
        {
        }

        public override async Task<RequestResult<GetCityByIdDto>> Handle(GetCityByIDQuery request, CancellationToken ct)
        {
            var city = await _generalRepo.GetByIdAsync(request.Id);

            if (city is null)
                return RequestResult<GetCityByIdDto>.Failure("City not found", ErrorCode.NotFound);

            // تحويل الـ Entity لـ DTO باستخدام الـ mapper
            var cityDto = _mapper.Map<GetCityByIdDto>(city);

            return RequestResult<GetCityByIdDto>.Success(cityDto, "City retrieved successfully");
        }
    }
}
