namespace HRManagementSystem.Features.UserManagement.GetUserByNameAndPassword.Query
{
    public record GetUserByNameAndPasswordQuery(
        string Username,
        string Password
        ) : IRequest<RequestResult<GetUserByNameAndPasswordDto>>;
}
