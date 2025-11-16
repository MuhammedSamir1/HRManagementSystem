namespace HRManagementSystem.Data.Models.AddressEntity
{
    public sealed class Country : BaseModel<Guid>
    {
        public string Iso2 { get; set; } = default!;   // "SA"
        public string Iso3 { get; set; } = default!;   // "SAU"
        public string Name { get; set; } = default!;   // "Saudi Arabia"

        public ICollection<State> States { get; set; } = new HashSet<State>();
    }
}
