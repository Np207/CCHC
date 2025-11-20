using Microsoft.AspNetCore.Mvc.Filters;

namespace LHS_Client.Attributes
{
    public class AuthorizedAttribute : Attribute, IAuthorizationFilter
    {
        public string PermissionCode { get; set; } = "";
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var a = context.HttpContext.Session.GetString("PermissionCodes");
            throw new NotImplementedException();
        }
    }
}
