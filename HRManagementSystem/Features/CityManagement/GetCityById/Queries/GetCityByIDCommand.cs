using HRManagementSystem.Common.BaseRequestHandler;
using HRManagementSystem.Common.Data.Enums;
using HRManagementSystem.Common.Views.Response;
using HRManagementSystem.Data.Models.AddressEntity;
using HRManagementSystem.Features.Common.AddressManagement.CityByIdDto.Dtos;

using MediatR;

namespace HRManagementSystem.Features.Common.AddressManagement.GetCityById.Commands
{
    public record GetCityByIdCommand(int Id) : IRequest<RequestResult<GetCityByIdDto>>;

    public sealed class GetCityByIdCommandHandler
        : RequestHandlerBase<GetCityByIdCommand, RequestResult<GetCityByIdDto>, City, int>
    {
        public GetCityByIdCommandHandler(RequestHandlerBaseParameters<City, int> parameters)
            : base(parameters)
        {
        }

        public override async Task<RequestResult<GetCityByIdDto>> Handle(GetCityByIdCommand request, CancellationToken ct)
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
