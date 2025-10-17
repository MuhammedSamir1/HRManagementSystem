namespace HRManagementSystem.Data.Models
{
    public class Organization : BaseModel
    {
        //public byte[] RowVersion { get; private set; } = default!;
        public string Name { get; private set; } = default!;
        public string? LegalName { get; set; }
        public string? Industry { get; set; }
        public int? AddressId { get; set; }
        public Address Address { get; set; } = default!;
        public string? DefaultTimezone { get; set; }
        public string? DefaultCurrency { get; set; }
    }
}
