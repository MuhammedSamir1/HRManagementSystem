using HRManagementSystem.Common.BaseRequestHandler;
using HRManagementSystem.Common.Data.Enums;
using HRManagementSystem.Common.Views.Response;
using HRManagementSystem.Data.Models.AddressEntity;
using HRManagementSystem.Features.Common.AddressManagement.CountryCommon.Dtos;
using HRManagementSystem.Features.Common.CountryCommon.Queries;

namespace HRManagementSystem.Features.CountryManagement.UpdateCountry.Commands
{
    public sealed class UpdateCountryCommandHandler : RequestHandlerBase<UpdateCountryCommand, RequestResult<ViewCountryDto>, Country, int>
    {
        public UpdateCountryCommandHandler(RequestHandlerBaseParameters<Country, int> parameters) : base(parameters)
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
