using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvancedAdmin.Authorize
{
    public class PermissionRequirement : IAuthorizationRequirement
    {
        public string Name { get; set; }

        public PermissionRequirement(string name)
        {
            Name = name;
        }
    }
}
