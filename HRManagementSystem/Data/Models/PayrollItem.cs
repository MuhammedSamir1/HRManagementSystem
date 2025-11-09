namespace HRManagementSystem.Data.Models
{
    public class PayrollItem:BaseModel<int>
    {
        public string Name { get; set; }


        // يحدد هل هو إضافة (Addition) أم استقطاع (Deduction)
        public PayrollItemType Type { get; set; }

        // يحدد هل هو مبلغ ثابت أم نسبة من الراتب الأساسي
        public CalculationType CalculationType { get; set; }

        public decimal Value { get; set; }

        // هل  البند إلزامي  ( الضرائب والتأمينات)
        public bool IsStatutory { get; set; }

    }
}
