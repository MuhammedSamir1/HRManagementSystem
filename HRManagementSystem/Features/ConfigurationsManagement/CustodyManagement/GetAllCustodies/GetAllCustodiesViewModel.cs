namespace HRManagementSystem.Features.ConfigurationsManagement.CustodyManagement.GetAllCustodies
{
    public record GetAllCustodiesViewModel(
    int PageNumber = 1,
    int PageSize = 10,
    string? SearchTerm = null, // ????? ?? SerialNumber ?? ItemName
    string? Status = null);    // ?????? ??? ???? ??????
}

