using HRManagementSystem.Common.Views.Response;
using HRManagementSystem.Data;
using MediatR;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HRManagementSystem.Features.AuthManagement.Login.Query
{
    public record LoginQuery(string userName, string password) : IRequest<RequestResult<bool>>;


    public class LoginQueryHandler : IRequestHandler<LoginQuery, RequestResult<bool>>
    {
        public async Task<RequestResult<bool>> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            //if (request.userName != "testUser" || request.password != "123456")
            //    return Unauthorized();

            string token = TokenGenerator(3, "Metwally", "Admin");

            throw new NotImplementedException();
        }

        private string TokenGenerator(int id, string userName, string role)
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
                    new Claim(ClaimTypes.NameIdentifier, id.ToString()),
                    new Claim(ClaimTypes.Name, userName),
                    new Claim(ClaimTypes.Role, role),
                })
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
