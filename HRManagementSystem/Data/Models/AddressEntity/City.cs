namespace HRManagementSystem.Data.Models.AddressEntity
{
    public sealed class City : BaseModel<Guid>
    {
        public Guid StateId { get; set; }
        public State State { get; set; } = default!;

        public string Name { get; set; } = default!;   // "Riyadh City"
    }
}
