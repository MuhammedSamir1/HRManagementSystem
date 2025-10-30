namespace HRManagementSystem.Data.Models
{
    public class EmployeeShift : BaseModel<Guid>
    {
        public Guid EmployeeId { get; set; }
        public Guid ShiftId { get; set; }

        public DateTime Date { get; set; }
    }
}
