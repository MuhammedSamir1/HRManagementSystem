using HRManagementSystem.Data;
using HRManagementSystem.Features.UserManagement.GetUserByNameAndPassword.Query;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HRManagementSystem.Features.UserManagement.LoginUser.Query
{
    public record LoginUserQuery(string userName, string password) : IRequest<RequestResult<string>>;

    public class LoginQueryHandler : RequestHandlerBase<LoginUserQuery, RequestResult<string>, User, Guid>
    {
        public LoginQueryHandler(RequestHandlerBaseParameters<User, Guid> parameters)
            : base(parameters)
        {
        }

        public override async Task<RequestResult<string>> Handle(LoginUserQuery request, CancellationToken cn)
        {
            var user = await _mediator.Send(new GetUserByNameAndPasswordQuery(request.userName, request.password), cn);

            string token = TokenGenerator(
                user.data.userId.ToString(),
                user.data.Username,
                user.data.RoleId.ToString());

            if (token is null || string.IsNullOrEmpty(token))
                return RequestResult<string>.Failure("Token generation failed!", ErrorCode.InternalServerError);

            return RequestResult<string>.Success(token, "Token generation successfully!");
        }

        private string TokenGenerator(string userId, string userName, string roleId)
        {
            var key = Encoding.ASCII.GetBytes(Constants.SecretKey);

            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = "Upskilling",
                Audience = "Upskilling-front",
                Expires = DateTime.Now.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, userId),
                    new Claim(ClaimTypes.Name, userName),
                    new Claim(ClaimTypes.Role, roleId)
                })
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
