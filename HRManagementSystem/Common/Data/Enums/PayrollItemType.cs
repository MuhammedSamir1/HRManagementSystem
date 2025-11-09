using System.ComponentModel.DataAnnotations;

namespace HRManagementSystem.Common.Data.Enums
{
    public enum PayrollItemType
    {
        [Display(Name = "إضافة / استحقاق")]
        Addition = 1,

        [Display(Name = "استقطاع / خصم")]
        Deduction = 2
    }
}
