namespace HRManagementSystem.Data.Models.AddressEntity
{
    public sealed class Address
    {
        public Guid Id { get; set; }
        public Guid CountryId { get; set; }
        public Country Country { get; set; } = null!;
        public Guid CityId { get; set; }
        public City City { get; set; } = null!;
        public Guid StateId { get; set; }
        public State State { get; set; } = null!;
        public string? Street { get; set; }
        public string? ZipCode { get; set; }
    }
}
