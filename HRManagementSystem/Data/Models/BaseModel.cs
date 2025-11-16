namespace HRManagementSystem.Data.Models
{
    public abstract class BaseModel<TKey>
    {
        public required TKey Id { get; set; }
        public bool IsDeleted { get; set; } = false;
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }
        public Guid? CreatedBy { get; set; }
        public Guid? UpdatedBy { get; set; }
        public Guid? DeletedBy { get; set; }
        // public byte[] RowVersion { get; set; } = default!;
    }
}
