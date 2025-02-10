using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HDLand.Logic.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using HDLand.Logic.Models;
using HDLand.Logic.Enums;
using System.Net;

namespace HDLand.Persistance.Configuration
{
    public class RolePermissionConfiguration : IEntityTypeConfiguration<PermissionRoleEntity>
    {

        private readonly AuthorizationOptions _authorizationOptions;

        public RolePermissionConfiguration(AuthorizationOptions authorizationOptions)
        {
            _authorizationOptions = authorizationOptions;
        }

        public void Configure(EntityTypeBuilder<PermissionRoleEntity> builder)
        {
            builder.HasKey(rp => new { rp.RoleId, rp.PermissionId });

            builder.HasData(ParseRolePermission());
        }

        private PermissionRoleEntity[] ParseRolePermission()
        {
            return _authorizationOptions.RolePermissions
                 .SelectMany(rp => rp.Permissions
                 .Select(p => new PermissionRoleEntity
                 {
                     RoleId = (int)Enum.Parse<Role>(rp.Role),
                     PermissionId = (int)Enum.Parse<Permissions>(p)
                 }))
                 .ToArray();
        }
    }
}
