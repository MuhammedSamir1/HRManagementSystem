namespace HRManagementSystem.Data.Models.AddressEntity
{
    public sealed class Address
    {
        public int Id { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; } = null!;
        public int CityId { get; set; }
        public City City { get; set; } = null!;
        public int StateId { get; set; }
        public State State { get; set; } = null!;
        public string? Street { get; set; }
        public string? ZipCode { get; set; }
    }
}
