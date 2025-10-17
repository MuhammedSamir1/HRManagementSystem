namespace HRManagementSystem.Data.Models.AddressEntity
{
    public sealed class City : BaseModel<int>
    {
        public int StateId { get; set; }
        public State State { get; set; } = default!;

        public string Name { get; set; } = default!;   // "Riyadh City"
    }
}
