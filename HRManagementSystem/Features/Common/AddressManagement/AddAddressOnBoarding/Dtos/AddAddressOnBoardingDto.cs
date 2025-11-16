namespace HRManagementSystem.Features.Common.AddressManagement.AddAddressOnBoarding.Dtos
{
    public sealed class AddAddressOnBoardingDto
    {
        public List<CountryOnBoardingDto> Countries { get; set; } = new();
    }

    public sealed class CountryOnBoardingDto
    {
        public string Iso2 { get; set; } = default!;
        public string Iso3 { get; set; } = default!;
        public string Name { get; set; } = default!;
        public List<StateOnBoardingDto>? States { get; set; }
    }

    public sealed class StateOnBoardingDto
    {
        public string Code { get; set; } = default!;
        public string Name { get; set; } = default!;
        public List<CityOnBoardingDto>? Cities { get; set; }
    }

    public sealed class CityOnBoardingDto
    {
        public string Name { get; set; } = default!;
    }
}


