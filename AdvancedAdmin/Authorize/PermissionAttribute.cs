using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace AdvancedAdmin.Authorize
{
    public class PermissionAttribute : Attribute, IAuthorizationFilter
    {
        public string Name { get; set; }

        public PermissionAttribute(string name)
        {
            Name = name;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var service = (IAuthorizationService)context.HttpContext.RequestServices.GetService(typeof(IAuthorizationService));

            var result = service.AuthorizeAsync(context.HttpContext.User, null, new PermissionRequirement(Name)).Result;

            if (!result.Succeeded)
            {
                context.Result = new UnauthorizedResult();
            }
        }

    }
}
