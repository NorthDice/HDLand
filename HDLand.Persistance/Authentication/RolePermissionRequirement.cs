using HDLand.Logic.Enums;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDLand.Persistance.Authentication
{
    public class RolePermissionRequirement : IAuthorizationRequirement
    {
        public RolePermissionRequirement(Permissions[] permissions)
        {
            Permissions = permissions;
        }

        public Permissions[] Permissions { get; set; } = [];
    }
}
