﻿using System;
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
    public class MedContext : IdentityDbContext<AppUser, AppRole, int>
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
            builder.Entity<IdentityUserRole<int>>().ToTable("UserRoles");
            builder.Entity<IdentityUserLogin<int>>().ToTable("UserLogins");
            builder.Entity<IdentityUserToken<int>>().ToTable("UserTokens");
            builder.Entity<IdentityUserClaim<int>>().ToTable("UserClaims");
            builder.Entity<IdentityRoleClaim<int>>().ToTable("RoleClaims");

            builder.Entity<AppUser>()
                .HasAlternateKey(p => p.UserName)
                .HasName("AK_Username");

            // Master Seed
            SeedAdmin(builder);

        }

        private static void SeedAdmin(ModelBuilder builder)
        {
            AppUser admin = new AppUser
            {
                Id = 1,
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@localhost",
                NormalizedEmail = "ADMIN@LOCALHOST",
                ConcurrencyStamp = Guid.NewGuid().ToString("D"),
                SecurityStamp = Guid.NewGuid().ToString("D")
            };

            var hasher = new PasswordHasher<AppUser>();
            admin.PasswordHash = hasher.HashPassword(admin, "123456");

            builder.Entity<AppUser>().HasData(admin);

            builder.Entity<IdentityUserClaim<int>>().HasData(
                new IdentityUserClaim<int> { Id = 1, UserId = 1, ClaimType = "Language", ClaimValue = "en" }
                );
        }
    }
}