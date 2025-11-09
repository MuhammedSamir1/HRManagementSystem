using FluentValidation;
using HRManagementSystem.Data.Repositories;
using HRManagementSystem.Features.PayrollManagement.PayrollItemManagement.AddPayrollItem.Commands;
using System.ComponentModel.DataAnnotations;

namespace HRManagementSystem.Features.PayrollManagement.PayrollItemManagement.AddPayrollItem.ViewModels
{
    public record AddPayrollItemViewModel(
      [Required(ErrorMessage = "الاسم مطلوب.")]
    [StringLength(100, ErrorMessage = "الاسم لا يجب أن يتجاوز 100 حرف.")]
    string Name,

      [Required(ErrorMessage = "يجب تحديد نوع البند (إضافة/استقطاع).")]
    PayrollItemType Type,

      [Required(ErrorMessage = "يجب تحديد نوع الحساب (ثابت/نسبة).")]
    CalculationType CalculationType,

      [Required(ErrorMessage = "القيمة مطلوبة.")]
    [Range(0.0001, (double)decimal.MaxValue, ErrorMessage = "يجب أن تكون القيمة موجبة.")]
    decimal Value,

      bool IsStatutory = false);
   
}
