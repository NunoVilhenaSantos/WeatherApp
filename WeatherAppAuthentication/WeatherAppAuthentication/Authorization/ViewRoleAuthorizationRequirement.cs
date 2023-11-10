// ---------------------------------------------------
// Demo 1: https://quickapp-pro.azurewebsites.net
// Demo 2: https://quickapp-standard.azurewebsites.net
//
// --> Gun4Hire: contact@ebenmonney.com
// ---------------------------------------------------

using System.Threading.Tasks;
using DAL.Core;
using Microsoft.AspNetCore.Authorization;

namespace WeatherAppAuthentication.Authorization;

public class ViewRoleAuthorizationRequirement : IAuthorizationRequirement
{
}

public class ViewRoleAuthorizationHandler : AuthorizationHandler<
    ViewRoleAuthorizationRequirement, string>
{
    protected override Task HandleRequirementAsync(
        AuthorizationHandlerContext context,
        ViewRoleAuthorizationRequirement requirement, string roleName)
    {
        if (context.User == null)
            return Task.CompletedTask;

        if (context.User.HasClaim(ClaimConstants.Permission,
                ApplicationPermissions.ViewRoles) ||
            context.User.IsInRole(roleName))
            context.Succeed(requirement);

        return Task.CompletedTask;
    }
}