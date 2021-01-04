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
    public class NmcContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public NmcContext(DbContextOptions<NmcContext> options)
            : base(options)
        {
        }

        public DbSet<Unit> Units { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }

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

            //builder.Entity<Doctor>()
            //    .Property(p => p.Name)
            //    .HasComputedColumnSql("[FirstName] + ' ' + [LastName]", stored: true);

            builder.Entity<Doctor>()
                .HasOne(p => p.User)
                .WithOne(p => p.Doctor)
                .HasForeignKey<Doctor>(p => p.UserId);
            
            builder.Entity<AppUser>()
                .HasOne(p => p.Doctor)
                .WithOne(p => p.User)
                .HasForeignKey<AppUser>(p => p.DoctorId);

        }
    }
}
