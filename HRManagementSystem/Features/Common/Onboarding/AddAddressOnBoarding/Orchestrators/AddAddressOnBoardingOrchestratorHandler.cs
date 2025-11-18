using HRManagementSystem.Data.Models.AddressEntity;
using HRManagementSystem.Features.CityManagement.AddCity.Commands;
using HRManagementSystem.Features.CityManagement.GetAllCities;
using HRManagementSystem.Features.CityManagement.GetAllCities.Queries;
using HRManagementSystem.Features.Common.AddressManagement.CountryCommon.Dtos;
using HRManagementSystem.Features.Common.AddressManagement.StateCommon.Dtos;
using HRManagementSystem.Features.Common.Onboarding.AddAddressOnBoarding.Dtos;
using HRManagementSystem.Features.CountryManagement.AddCountry.Commands;
using HRManagementSystem.Features.CountryManagement.GetAllCountries.Queries;
using HRManagementSystem.Features.StateManagement.AddState.Command;
using HRManagementSystem.Features.StateManagement.GetAllStates.Queries;

namespace HRManagementSystem.Features.Common.Onboarding.AddAddressOnBoarding.Orchestrators
{
    public sealed class AddAddressOnBoardingOrchestratorHandler
        : RequestHandlerBase<AddAddressOnBoardingOrchestrator, RequestResult<bool>, Country, Guid>
    {
        public AddAddressOnBoardingOrchestratorHandler(RequestHandlerBaseParameters<Country, Guid> parameters)
            : base(parameters)
        {
        }

        public override async Task<RequestResult<bool>> Handle(AddAddressOnBoardingOrchestrator request, CancellationToken ct)
        {
            var countriesResult = await _mediator.Send(new GetAllCountriesQuery(), ct);
            if (!countriesResult.isSuccess)
                return RequestResult<bool>.Failure(countriesResult.message, countriesResult.errorCode);
            var countries = countriesResult.data ?? new List<ViewCountryDto>();

            var statesResult = await _mediator.Send(new GetAllStatesQuery(), ct);
            if (!statesResult.isSuccess)
                return RequestResult<bool>.Failure(statesResult.message, statesResult.errorCode);
            var states = statesResult.data?.ToList() ?? new List<ViewStateDto>();

            var citiesResult = await _mediator.Send(new GetAllCitiesQuery(), ct);
            List<ViewAllCitiesDto> cities = new();
            if (citiesResult.isSuccess && citiesResult.data is not null)
            {
                cities = citiesResult.data;
            }
            else if (!citiesResult.isSuccess && citiesResult.errorCode != ErrorCode.NotFound)
            {
                return RequestResult<bool>.Failure(citiesResult.message, citiesResult.errorCode);
            }

            var cityLookup = new HashSet<(Guid stateId, string name)>(
                cities.Select(c => (c.StateId, Normalize(c.Name))));

            foreach (var countryPayload in request.Payload.Countries ?? new List<CountryOnBoardingDto>())
            {
                var country = FindCountry(countries, countryPayload);

                if (country is null)
                {
                    var addCountryResult = await _mediator.Send(
                        new AddCountryCommand(countryPayload.Iso2, countryPayload.Iso3, countryPayload.Name), ct);

                    if (!addCountryResult.isSuccess)
                        return RequestResult<bool>.Failure(addCountryResult.message, addCountryResult.errorCode);

                    country = addCountryResult.data!;
                    countries.Add(country);
                }

                if (countryPayload.States is null) continue;

                foreach (var statePayload in countryPayload.States)
                {
                    var state = states.FirstOrDefault(s =>
                        s.CountryId == country.Id &&
                        string.Equals(s.Code, statePayload.Code, StringComparison.OrdinalIgnoreCase));

                    if (state is null)
                    {
                        var addStateResult = await _mediator.Send(
                            new AddStateCommand(statePayload.Code, statePayload.Name, country.Id), ct);

                        if (!addStateResult.isSuccess)
                            return RequestResult<bool>.Failure(addStateResult.message, addStateResult.errorCode);

                        state = addStateResult.data!;
                        states.Add(state);
                    }

                    if (statePayload.Cities is null) continue;

                    foreach (var cityPayload in statePayload.Cities)
                    {
                        var normalizedCity = Normalize(cityPayload.Name);
                        if (cityLookup.Contains((state.Id, normalizedCity)))
                            continue;

                        var addCityResult = await _mediator.Send(
                            new AddCityCommand(cityPayload.Name, state.Id), ct);

                        if (!addCityResult.isSuccess && addCityResult.errorCode != ErrorCode.Conflict)
                            return RequestResult<bool>.Failure(addCityResult.message, addCityResult.errorCode);

                        cityLookup.Add((state.Id, normalizedCity));
                    }
                }
            }

            return RequestResult<bool>.Success(true, "Address master data onboarded successfully.");
        }

        private static ViewCountryDto? FindCountry(IEnumerable<ViewCountryDto> countries, CountryOnBoardingDto payload)
        {
            var normalizedName = Normalize(payload.Name);

            return countries.FirstOrDefault(country =>
                string.Equals(country.Iso3, payload.Iso3, StringComparison.OrdinalIgnoreCase) ||
                string.Equals(country.Iso2, payload.Iso2, StringComparison.OrdinalIgnoreCase) ||
                string.Equals(Normalize(country.Name), normalizedName, StringComparison.Ordinal));
        }

        private static string Normalize(string value) =>
            (value ?? string.Empty).Trim().ToUpperInvariant();
    }
}


