using HRManagementSystem.Common.BaseRequestHandler;
using HRManagementSystem.Common.Data.Enums;
using HRManagementSystem.Common.Views.Response;
using HRManagementSystem.Data.Models.AddressEntity;
using HRManagementSystem.Features.Common.AddressManagement.CountryCommon.Dtos;
using HRManagementSystem.Features.Common.CountryCommon.Queries;

namespace HRManagementSystem.Features.CountryManagement.AddCountry.Commands
{
    public sealed class AddCountryCommandHandler : RequestHandlerBase<AddCountryCommand, RequestResult<ViewCountryDto>, Country, int>
    {
        public AddCountryCommandHandler(RequestHandlerBaseParameters<Country, int> parameters) : base(parameters)
        {
        }


        public override async Task<RequestResult<ViewCountryDto>> Handle(AddCountryCommand request, CancellationToken cancellationToken)
        {
            var existsResult = await _mediator.Send(new IsCountryExistQuery(request.Iso3), cancellationToken);

            if (!existsResult.isSuccess)
            {
                return RequestResult<ViewCountryDto>.Failure(existsResult.message, existsResult.errorCode);
            }


            var countryEntity = _mapper.Map<Country>(request);
            var res = await _generalRepo.AddAsync(countryEntity, cancellationToken);

            if (!res)
            {
                return RequestResult<ViewCountryDto>.Failure("Failed to add country to the database.", ErrorCode.InternalServerError);
            }

            var countryDto = _mapper.Map<ViewCountryDto>(countryEntity);
            return RequestResult<ViewCountryDto>.Success(countryDto, "Country added successfully.");
        }
    }
}
