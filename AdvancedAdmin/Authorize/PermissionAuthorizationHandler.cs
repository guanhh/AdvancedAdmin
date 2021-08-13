using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AdvancedAdmin.Authorize
{
    public class PermissionAuthorizationHandler : AuthorizationHandler<PermissionRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
        {
            if (!context.User.Identity.IsAuthenticated)
            {
                //user未登录
            }

            if (context.User.IsInRole("admin"))
            {
                context.Succeed(requirement);
                return Task.CompletedTask;
            }

            //获取用户id
            var id = context.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (id != null)
            {
                //找出id对应的roles
            }

            context.Fail();
            return Task.CompletedTask;

        }
    }
}
