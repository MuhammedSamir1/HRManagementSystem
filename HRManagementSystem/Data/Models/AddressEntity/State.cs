namespace HRManagementSystem.Data.Models.AddressEntity
{
    public sealed class State : BaseModel<Guid>
    {
        public Guid CountryId { get; set; }
        public Country Country { get; set; } = default!;

        public string Code { get; set; } = default!;   // "RIY"
        public string Name { get; set; } = default!;   // "Riyadh"

        public ICollection<City> Cities { get; set; } = new HashSet<City>();
    }
}
