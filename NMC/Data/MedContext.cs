using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NMC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NMC.Data
{
    public class MedContext : IdentityDbContext<AppUser, AppRole, string>
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
            builder.Entity<IdentityUserRole<string>>().ToTable("UserRoles");
            builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins");
            builder.Entity<IdentityUserToken<string>>().ToTable("UserTokens");
            builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims");

            builder.Entity<AppUser>()
                .HasAlternateKey(p => p.UserName)
                .HasName("AK_Username");

            // seed roles and admin user
            builder
            .Entity<AppRole>().HasData(
                Enum.GetValues(typeof(SystemRole))
                    .Cast<SystemRole>()
                    .Select(e => new AppRole()
                    {
                        Id = e.ToString(),
                        Name = e.ToString(),
                        NormalizedName = e.ToString(),
                    })
            );
            
            SeedUser(builder, "admin", new[] { SystemRole.Administration });
            SeedUser(builder, "admission", new[] { SystemRole.Admission });
            SeedUser(builder, "reception", new[] { SystemRole.Reception });
            SeedUser(builder, "lab", new[] { SystemRole.Laboratory });
            SeedUser(builder, "labdoctor", new[] { SystemRole.Laboratory, SystemRole.Doctor });
            SeedUser(builder, "management", new[] { SystemRole.Management });
            SeedUser(builder, "managerdoctor", new[] { SystemRole.Management, SystemRole.Doctor });
            SeedUser(builder, "accountant", new[] { SystemRole.Accounting });

        }

        private static AppUser SeedUser(ModelBuilder builder, string username, SystemRole[] roles)
        {
            var user = new AppUser
            {
                UserName = username,
                NormalizedUserName = username.ToUpper(),
                Email = $"{username}@hospital",
                NormalizedEmail = $"{username}@hospital".ToUpper(),
                SecurityStamp = Guid.NewGuid().ToString("D"),
                ConcurrencyStamp = Guid.NewGuid().ToString("D")
            };

            var hasher = new PasswordHasher<AppUser>();
            user.PasswordHash = hasher.HashPassword(user, "123456");
            builder.Entity<AppUser>().HasData(user);
            builder.Entity<IdentityUserRole<string>>().HasData(roles.Select(role => new IdentityUserRole<string> { RoleId = role.ToString(), UserId = user.Id }));

            return user;
        }
    }
}
