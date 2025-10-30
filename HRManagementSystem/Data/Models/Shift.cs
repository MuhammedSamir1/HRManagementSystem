﻿namespace HRManagementSystem.Data.Models
{
    public class Shift : BaseModel<Guid>
    {
        public string Name { get; set; } = null!; // مثال: صباحي - مسائي - شيفت رمضان - تدريب داخلي  
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }
}
