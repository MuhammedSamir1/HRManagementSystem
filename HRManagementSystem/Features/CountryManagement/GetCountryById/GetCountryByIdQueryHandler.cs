using HRManagementSystem.Data.Models.AddressEntity;
using HRManagementSystem.Features.Common.AddressManagement.CountryCommon.Dtos;

namespace HRManagementSystem.Features.CountryManagement.GetCountryById
{
    public sealed class GetCountryByIdQueryHandler : RequestHandlerBase<GetCountryByIdQuery, ResponseViewModel<ViewCountryDto>, Country, Guid>
    {
        // ??? ??????????? ????????
        public GetCountryByIdQueryHandler(RequestHandlerBaseParameters<Country, Guid> parameters) : base(parameters)
        {
        }

        public override async Task<ResponseViewModel<ViewCountryDto>> Handle(GetCountryByIdQuery request, CancellationToken cancellationToken)
        {
            // 1. ??????? ?????? ???????? GetByIdAsync (????? ??? ???????/???? ????)
            var countryEntity = await _generalRepo.GetByIdAsync(request.Id);

            if (countryEntity == null)
            {
                // ????? ??? ??? ?????? ???????? ??? ?????
                return ResponseViewModel<ViewCountryDto>.Failure(ErrorCode.NotFound);
            }

            // 2. ????? Entity ??? DTO ??????? (???????? ??? Mapper)
            var countryDto = _mapper.Map<ViewCountryDto>(countryEntity);

            return ResponseViewModel<ViewCountryDto>.Success(countryDto);
        }
    }
}

