namespace HRManagementSystem.Features.CustodyManagement.GetAllCustodies
{
    public record GetAllCustodiesViewModel(
    int PageNumber = 1, 
    int PageSize = 10,  
    string? SearchTerm = null, // للبحث عن SerialNumber أو ItemName
    int? EmployeeId = null,   // لتصفية العهد حسب الموظف
    string? Status = null);    // لتصفية حسب حالة العهدة
}
