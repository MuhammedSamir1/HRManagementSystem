namespace HRManagementSystem.Data.Models.ConfigurationsModels
{
    public class OvertimeRate : BaseModel<int>
    {

        public string Name { get; set; }


        // ده بالنسبة ليا  اللي هيضرب   في الوقت المحدد
        public decimal Multiplier { get; set; }

        // نوع اليوم     (Weekdays, Weekends, Holidays)
        public OvertimeDayType DayType { get; set; }
        public string? Description { get; set; }
    }
}
