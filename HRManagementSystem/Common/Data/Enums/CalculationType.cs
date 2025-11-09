using System.ComponentModel.DataAnnotations;

namespace HRManagementSystem.Common.Data.Enums
{
    public enum CalculationType
    {
        [Display(Name = "مبلغ ثابت")]
        FixedAmount = 1,

        [Display(Name = "نسبة من الراتب الأساسي")]
        PercentageOfBaseSalary = 2

        //    PercentageOfGrossSalary, PerDayRate
    }
}
