using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NMC.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NMC.Data
{
    public class MedContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public MedContext(DbContextOptions<MedContext> options)
            : base(options)
        {
        }

        // Reference Entity Types
        public DbSet<RoleType> RoleTypes { get; set; }
        
        // Domain Entities
        public DbSet<Party> Parties { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<PartyRole> PartyRoles { get; set; }

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

            // Master Seed

            SeedRoles(builder);

            SeedUser(builder, "admin", "ADMIN");
            SeedUser(builder, "fd", "FD");
            SeedUser(builder, "act", "ACT");
            SeedUser(builder, "mgt", "MGT");

            SeedRoleTypes(builder);

        }

        private static void SeedRoleTypes(ModelBuilder builder)
        {
            var roleTypes = new[] {
                new RoleType { Id = "DEPT", Name = "Department" },
                new RoleType { Id = "DOCTOR", Name = "Doctor" },
                new RoleType { Id = "IN-PATIENT", Name = "In-Patient" },
                new RoleType { Id = "OUT-PATIENT", Name = "Out-Patient" },
                new RoleType { Id = "EMP", Name = "Employee" },
            };
            builder.Entity<RoleType>().HasData(roleTypes);
        }

        private static void SeedRoles(ModelBuilder builder)
        {
            var roles = new[]
            {
                new AppRole { Id = "ADMIN", Name = "Admin", NormalizedName = "ADMIN" },
                new AppRole { Id = "DOCTOR", Name = "Doctor", NormalizedName = "DOCTOR" },
                new AppRole { Id = "FD", Name = "Front Desk", NormalizedName = "FRONT DESK" },
                new AppRole { Id = "LABD", Name = "Laboratory Doctor", NormalizedName = "LABORATORY DOCTOR" },
                new AppRole { Id = "LABT", Name = "Laboratory Technician", NormalizedName = "LABORATORY TECHNICIAN" },
                new AppRole { Id = "ACT", Name = "Accountant", NormalizedName = "ACCOUNTANT" },
                new AppRole { Id = "MGT", Name = "Management", NormalizedName = "MANAGEMENT" },
            };

            builder.Entity<AppRole>().HasData(roles);
        }

        private static int claimId = 1;
        private static void SeedUser(ModelBuilder builder, string userName, string role)
        {
            AppUser admin = new AppUser
            {
                Id = Guid.NewGuid().ToString("D"),
                UserName = userName,
                NormalizedUserName = userName.ToUpper(),
                Email = $"{userName}@localhost",
                NormalizedEmail = $"{userName.ToUpper()}@LOCALHOST",
                ConcurrencyStamp = Guid.NewGuid().ToString("D"),
                SecurityStamp = Guid.NewGuid().ToString("D")
            };

            var hasher = new PasswordHasher<AppUser>();
            admin.PasswordHash = hasher.HashPassword(admin, "123456");

            builder.Entity<AppUser>().HasData(admin);

            builder.Entity<IdentityUserClaim<string>>().HasData(
                new IdentityUserClaim<string> { Id = claimId++, UserId = admin.Id, ClaimType = "Language", ClaimValue = "en" }
                );

            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string> { RoleId = role, UserId = admin.Id });
        }
    }
}
