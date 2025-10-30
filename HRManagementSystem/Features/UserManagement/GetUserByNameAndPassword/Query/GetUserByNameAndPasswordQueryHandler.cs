using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace HRManagementSystem.Features.UserManagement.GetUserByNameAndPassword.Query
{
    public class GetUserByNameAndPasswordQueryHandler : RequestHandlerBase<GetUserByNameAndPasswordQuery, RequestResult<GetUserByNameAndPasswordDto>, User, Guid>
    {
        public GetUserByNameAndPasswordQueryHandler(
            RequestHandlerBaseParameters<User, Guid> parameters
        ) : base(parameters)
        {
        }

        public override async Task<RequestResult<GetUserByNameAndPasswordDto>> Handle(GetUserByNameAndPasswordQuery request, CancellationToken ct)
        {
            var user = await _generalRepo.GetForLogin(x => x.UserName == request.Username && x.Password == request.Password)
                            .ProjectTo<GetUserByNameAndPasswordDto>(_mapper.ConfigurationProvider)
                            .FirstOrDefaultAsync();

            if (user is null)
                return RequestResult<GetUserByNameAndPasswordDto>.Failure("Incorrect username or password!", ErrorCode.Unauthorized);

            return RequestResult<GetUserByNameAndPasswordDto>.Success(user, "User is valid!");
        }
    }
}
