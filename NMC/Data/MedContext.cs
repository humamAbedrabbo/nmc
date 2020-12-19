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

        public DbSet<Ward> Wards { get; set; }
        public DbSet<Room> Rooms { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            ConfigureIdentity(builder);

            // Ward
            // Room
            builder.Entity<Room>().HasAlternateKey(x => x.Code);

        }

        private static void ConfigureIdentity(ModelBuilder builder)
        {
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
                j => j.HasKey(t => new { t.RoleId, t.UserId })
                );


            // Add Roles and Admin
            builder.Entity<AppRole>().HasData(new AppRole { Id = 1, Name = "Admin", NormalizedName = "ADMIN" });
            builder.Entity<AppRole>().HasData(new AppRole { Id = 2, Name = "Admission", NormalizedName = "ADMISSION" });
            builder.Entity<AppRole>().HasData(new AppRole { Id = 3, Name = "Doctor", NormalizedName = "DOCTOR" });
            
            var hasher = new PasswordHasher<AppUser>();
            var admin = new AppUser
            {
                Id = 1,
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@nmc",
                NormalizedEmail = "ADMIN@NMC",
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                SecurityStamp = Guid.NewGuid().ToString()
            };
            admin.PasswordHash = hasher.HashPassword(admin, "123456");
            builder.Entity<AppUser>().HasData(admin);
            builder.Entity<AppUserRole>().HasData(new AppUserRole { RoleId = 1, UserId = 1 });

        }
    }
}
