using HDLand.Logic.Enums;
using HDLand.Logic.Interfaces;
using HDLand.Logic.Models.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HDLand.Persistance.Authentication
{
    public class PermissionAuthorizationHandler : AuthorizationHandler<RolePermissionRequirement>
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public PermissionAuthorizationHandler(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        protected override async Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            RolePermissionRequirement requirement)
        {
            var userId = context.User.Claims.FirstOrDefault(
                c => c.Type == CustomClaims.UserId
            );

            if (userId is null || !Guid.TryParse(userId.Value, out var id))
            {
                return;
            }

            using var scope = _serviceScopeFactory.CreateScope();

            var permissionService = scope.ServiceProvider
                .GetRequiredService<IPermissionService>();

            var permissions = await permissionService.GetPermissionsAsync(id);

            if (permissions.Intersect(requirement.Permissions).Any())
            {
                context.Succeed(requirement);
            }
        }
    }
}
