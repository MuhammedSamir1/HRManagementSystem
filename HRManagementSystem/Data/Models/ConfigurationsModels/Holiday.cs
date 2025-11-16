namespace HRManagementSystem.Data.Models.ConfigurationsModels
{
    public class Holiday : BaseModel<Guid>
    {
        public string Name { get; set; } = default!;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }


        public bool IsMandatory { get; set; } = true;
        public HolidayType Type { get; set; }
        public int DurationInDays => (int)(EndDate - StartDate).TotalDays + 1;
    }
}

