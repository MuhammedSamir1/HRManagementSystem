using HRManagementSystem.Data.Models.AddressEntity;
using HRManagementSystem.Features.Common.AddressManagement.CountryCommon.Dtos;
using HRManagementSystem.Features.Common.CountryCommon.Queries;

namespace HRManagementSystem.Features.CountryManagement.UpdateCountry.Commands
{
    public sealed class UpdateCountryCommandHandler : RequestHandlerBase<UpdateCountryCommand, RequestResult<ViewCountryDto>, Country, Guid>
    {
        public UpdateCountryCommandHandler(RequestHandlerBaseParameters<Country, Guid> parameters) : base(parameters)
        {
        }

        public override async Task<RequestResult<ViewCountryDto>> Handle(UpdateCountryCommand request, CancellationToken cancellationToken)
        {

            var isCountryExist = await _mediator.Send(new IsCountryExistQuery(request.Iso3));

            if (!isCountryExist.isSuccess)
            {
                return RequestResult<ViewCountryDto>.Failure(ErrorCode.NotFound);
            }

            var country = _mapper.Map<Country>(request);
            await _generalRepo.UpdatePartialAsync(country);

            var countryDto = _mapper.Map<ViewCountryDto>(country);
            return RequestResult<ViewCountryDto>.Success(countryDto, "Country updated successfully.");
        }
    }
}

