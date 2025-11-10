namespace HRManagementSystem.Data.Models.ConfigurationsModels
{
    public class Custody : BaseModel<int>
    {
        public string ItemName { get; set; }
        public string SerialNumber { get; set; }
        public DateTime HandoverDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public string Status { get; set; } // الحالة (Active, Returned, Damaged)

        // علاقة بالمستلم
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
