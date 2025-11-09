using System.ComponentModel.DataAnnotations;

namespace HRManagementSystem.Features.PayrollManagement.OvertimeRateManagement.UpdateOvertimeRate.ViewModels
{
    public record UpdateOvertimeRateViewModel(
        [Required(ErrorMessage = "معرّف سعر العمل الإضافي مطلوب.")]
        int Id,

        [Required(ErrorMessage = "اسم سعر العمل الإضافي مطلوب.")]
        [StringLength(100, ErrorMessage = "الاسم لا يجب أن يتجاوز 100 حرف.")]
        string Name,

        [Required(ErrorMessage = "معامل السعر (Rate Factor) مطلوب.")]
        decimal RateFactor,

        [StringLength(500, ErrorMessage = "الوصف لا يجب أن يتجاوز 500 حرف.")]
        string Description,

        [Required(ErrorMessage = "حالة النشاط مطلوبة.")]
        bool IsActive); 
}
