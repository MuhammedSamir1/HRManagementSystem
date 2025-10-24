using HRManagementSystem.Common.BaseRequestHandler;
using HRManagementSystem.Common.Data.Enums;
using HRManagementSystem.Common.Views.Response;
using HRManagementSystem.Data.Models.AddressEntity;
using HRManagementSystem.Features.Common.AddressManagement.CountryCommon.Dtos;
using Microsoft.EntityFrameworkCore;

namespace HRManagementSystem.Features.CountryManagement.AddCountry.Commands
{
    public sealed class AddCountryCommandHandler : RequestHandlerBase<AddCountryCommand, RequestResult<ViewCountryDto>, Country, int>
    {
        public AddCountryCommandHandler(RequestHandlerBaseParameters<Country, int> parameters) : base(parameters)
        {
        }

        public override async Task<RequestResult<ViewCountryDto>> Handle(AddCountryCommand request, CancellationToken cancellationToken)
        {
            // 1. التحقق من تكرار رمز ISO3
            var exists = await _generalRepo
                .Get(c => c.Iso3 == request.Iso3, cancellationToken)
                .AnyAsync(cancellationToken);

            if (exists)
            {
                return RequestResult<ViewCountryDto>.Failure("Country with this ISO3 code already exists.", ErrorCode.Conflict);
            }

            var countryEntity = _mapper.Map<Country>(request);
            var res = await _generalRepo.AddAsync(countryEntity, cancellationToken);
            if (!res)
            {
                return RequestResult<ViewCountryDto>.Failure("Failed to add country.", ErrorCode.BadRequest);
            }
            // 3. الإرجاع
            var countryDto = _mapper.Map<ViewCountryDto>(countryEntity);
            return RequestResult<ViewCountryDto>.Success(countryDto, "Country added successfully.");
        }
    }
}
