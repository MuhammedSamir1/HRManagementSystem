using System.ComponentModel.DataAnnotations;
using HRManagementSystem.Data.Models.AddressEntity;

namespace HRManagementSystem.Data.Models
{
    public class Organization : BaseModel<int>
    {
        [Required]
        [MaxLength(150)]
        public string Name { get; private set; } = default!;
        public string? Description { get; set; }
        public string? LegalName { get; set; }
        public string? Industry { get; set; }
        public int? AddressId { get; set; }
        [Required]
        public Address Address { get; set; } = default!;
        public DateTime? DefaultTimezone { get; set; } = DateTime.UtcNow;
        public Currency? DefaultCurrency { get; set; }
        public ICollection<Company> Companies { get; set; } = new HashSet<Company>();
    }
}
