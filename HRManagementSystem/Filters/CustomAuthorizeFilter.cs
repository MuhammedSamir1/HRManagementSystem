using HRManagementSystem.Common.Views;
using HRManagementSystem.Data.Contexts;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace HRManagementSystem.Filters
{
    public class CustomAuthorizeFilter : ActionFilterAttribute
    {
        private readonly Feature _feature;
        private readonly ApplicationDbContext _context;

        public CustomAuthorizeFilter(
            ApplicationDbContext context,
            Feature feature
            )
        {
            _context = context;
            _feature = feature;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var userState = context.HttpContext.RequestServices.GetRequiredService<UserState>();

            // مثال للاستخدام
            var userId = userState.UserId;

            var roleId = context.HttpContext.User.FindFirst(ClaimTypes.Role);

            if (roleId is null || string.IsNullOrEmpty(roleId.Value))
            {
                throw new UnauthorizedAccessException();
            }
            var parsedRoleId = Guid.Parse(roleId.Value);
            var role = _context.Roles.FirstOrDefault(x => x.Id.Equals(parsedRoleId));

            if (role is null)
            {
                throw new UnauthorizedAccessException();
            }

            if (string.IsNullOrEmpty(_feature.ToString()))
            {
                throw new InvalidOperationException("Feature name is not set.");
            }

            var hasAccess = _context.RoleFeatures
                .Any(x => x.RoleId.Equals(role!.Id)
                && x.Feature == _feature);

            if (!hasAccess)
            {
                throw new UnauthorizedAccessException();
            }

            base.OnActionExecuting(context);
        }
    }
}
