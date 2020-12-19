using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NMC.Models;

namespace NMC.Data
{
    public class MedContext : IdentityDbContext<AppUser, AppRole, int,
        AppUserClaim, AppUserRole, AppUserLogin,
        AppRoleClaim, AppUserToken>
    {
        public MedContext(DbContextOptions<MedContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<AppUser>().ToTable("Users");
            builder.Entity<AppRole>().ToTable("Roles");
            builder.Entity<AppUserRole>().ToTable("UserRoles");
            builder.Entity<AppUserLogin>().ToTable("UserLogins");
            builder.Entity<AppUserToken>().ToTable("UserTokens");
            builder.Entity<AppUserClaim>().ToTable("UserClaims");
            builder.Entity<AppRoleClaim>().ToTable("RoleClaims");

            builder.Entity<AppUser>()
                .HasAlternateKey(p => p.UserName)
                .HasName("AK_Username");

            builder.Entity<AppUser>()
                .HasMany(p => p.Roles)
                .WithMany(p => p.Users)
                .UsingEntity<AppUserRole>(
                j => j.HasOne(p => p.Role).WithMany().HasForeignKey(p => p.RoleId),
                j => j.HasOne(p => p.User).WithMany().HasForeignKey(p => p.UserId),
                j => j.HasKey(t => new { t.RoleId, t.UserId  })
                );

        }

    }
}
