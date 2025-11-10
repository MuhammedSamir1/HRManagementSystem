namespace HRManagementSystem.Data.Models
{
    public class EmployeeShift : BaseModel<int>
    {
        public int EmployeeId { get; set; }
        public int ShiftId { get; set; }

        public DateTime Date { get; set; }
    }
}
