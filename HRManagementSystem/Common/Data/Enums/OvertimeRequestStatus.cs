using System.ComponentModel.DataAnnotations;

namespace HRManagementSystem.Common.Data.Enums
{
    public enum OvertimeRequestStatus
    {
        [Display(Name = "معلق / قيد المراجعة")]
        Pending = 1,

        [Display(Name = "تم الاعتماد والموافقة")]
        Approved = 2,

        [Display(Name = "تم الرفض")]
        Rejected = 3,

        [Display(Name = "تم الإلغاء")]
        Cancelled = 4
    }
}
