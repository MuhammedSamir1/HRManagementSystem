using HRManagementSystem.Common.Views;
using System.Security.Claims;

namespace HRManagementSystem.Data.Middlewares
{
    public class UserStateMiddleware
    {
        private readonly RequestDelegate _next;

        public UserStateMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, UserState userState)
        {
            var userIdClaim = context.User.FindFirst(ClaimTypes.NameIdentifier);
            var usernameClaim = context.User.FindFirst(ClaimTypes.Name);
            var roleIdClaim = context.User.FindFirst(ClaimTypes.Role);

            if (userIdClaim != null && Guid.TryParse(userIdClaim.Value, out var userId))
                userState.UserId = userId;

            if (usernameClaim != null)
                userState.Name = usernameClaim.Value;

            if (roleIdClaim != null && Guid.TryParse(roleIdClaim.Value, out var roleId))
                userState.RoleId = roleId;

            await _next(context);
        }
    }

    public static class UserStateMiddlewareExtensions
    {
        public static IApplicationBuilder UseUserStateMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<UserStateMiddleware>();
        }
    }

}
