namespace HRManagementSystem.Data.Models.ConfigurationsModels
{
    public class Shift : BaseModel<int>
    {
        public string Name { get; set; } = null!; // مثال: صباحي - مسائي - شيفت رمضان - تدريب داخلي  
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }
}
