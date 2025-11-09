using System.ComponentModel.DataAnnotations;

namespace HRManagementSystem.Common.Data.Enums
{
    public enum OvertimeDayType
    {
        [Display(Name = "أيام العمل العادية")]
        Weekdays = 1,

        [Display(Name = "نهاية الأسبوع )")]
        Weekends = 2,

        [Display(Name = "إجازة رسمية /  ")]
        Holidays = 3
    }
}
