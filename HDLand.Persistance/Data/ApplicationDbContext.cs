using HDLand.Logic.Entities;
using HDLand.Logic.Models;
using HDLand.Persistance.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDLand.Persistance.Data
{
    public class ApplicationDbContext(
      DbContextOptions<ApplicationDbContext> options,
      IOptions<AuthorizationOptions> authOptions) : DbContext(options)
    {
        public DbSet<UserEntity> Users { get; set; }

        public DbSet<RoleEntity> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());

            modelBuilder.ApplyConfiguration(new RoleConfiguration());

            modelBuilder.ApplyConfiguration(new RolePermissionConfiguration(authOptions.Value));

            modelBuilder.ApplyConfiguration(new PermissionConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
