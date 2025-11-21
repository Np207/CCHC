using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace LHS_Client.Attributes
{
    public class AuthorizedAttribute : Attribute, IAuthorizationFilter
    {
        public string PermissionCode { get; set; } = "";
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            List<string>? permissionCodes = context.HttpContext.Session.GetObject<List<string>>("PermissionCodes");

            if (permissionCodes.Count == 0 || !permissionCodes.Contains(PermissionCode))
            {
                context.Result = new UnauthorizedResult();
            }
        }
    }
}
