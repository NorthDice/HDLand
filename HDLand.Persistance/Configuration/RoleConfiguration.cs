using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HDLand.Logic.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using HDLand.Logic.Enums;

namespace HDLand.Persistance.Configuration
{
    public class RoleConfiguration : IEntityTypeConfiguration<RoleEntity>
    {
        public void Configure(EntityTypeBuilder<RoleEntity> builder)
        {
            builder.HasKey(r => r.Id);

            builder.HasMany(r => r.Permissions)
                .WithMany(p => p.Roles)
                .UsingEntity<PermissionRoleEntity>(
                    j => j.HasOne(rp => rp.Permission).WithMany().HasForeignKey(j => j.PermissionId),
                    j => j.HasOne(rp => rp.Role).WithMany().HasForeignKey(j => j.RoleId),
                    j =>
                    {
                        j.HasKey(rp => new { rp.RoleId, rp.PermissionId });
                    }
                );
            var roles = Enum
                .GetValues<Role>()
                .Select(r => new RoleEntity
                {
                    Id = (int)r,
                    Name = r.ToString()
                });
            builder.HasData(roles);
        }
    }
}
