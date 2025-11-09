using System.ComponentModel.DataAnnotations;

namespace HRManagementSystem.Common.Data.Enums
{
    public enum PayrollStatus
    {
        [Display(Name = "مسودة / قيد المراجعة")]
        Draft = 1,

        [Display(Name = "تم الاعتماد والإغلاق")]
        Finalized = 2,

        [Display(Name = "تم الدفع")]
        Paid = 3
    }
}
