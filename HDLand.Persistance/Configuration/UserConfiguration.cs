using HDLand.Logic.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDLand.Persistance.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.HasKey(u => u.Id);

            builder.HasMany(user => user.Roles)
                .WithMany(role => role.Users)
                .UsingEntity<UserRoleEntity>(
                    l => l.HasOne<RoleEntity>().WithMany().HasForeignKey(ur => ur.RoleId),
                    r => r.HasOne<UserEntity>().WithMany().HasForeignKey(ur => ur.UserId)
                ); 
        }
    }
}
