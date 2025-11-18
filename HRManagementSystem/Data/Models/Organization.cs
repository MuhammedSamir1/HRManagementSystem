using HRManagementSystem.Data.Models.AddressEntity;
using System.ComponentModel.DataAnnotations;

namespace HRManagementSystem.Data.Models
{
    public class Organization : BaseModel<Guid>
    {
        [Required]
        [MaxLength(150)]
        public string Name { get; private set; } = default!;
        public string? Description { get; set; }
        public string? LegalName { get; set; }
        public string? Industry { get; set; }
        public Guid? AddressId { get; set; }
        [Required]
        public Address Address { get; set; } = default!;
        public string? DefaultTimezone { get; set; } = TimeZoneInfo.Utc.Id;
        public Currency? DefaultCurrency { get; set; }
        public ICollection<Company> Companies { get; set; } = new HashSet<Company>();
    }
}
