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
    public class MedContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public MedContext(DbContextOptions<MedContext> options)
            : base(options)
        {
        }

        public DbSet<Ward> Wards { get; set; }
        public DbSet<Speciality> Specialities { get; set; }
        public DbSet<AdmissionType> AdmissionTypes { get; set; }
        public DbSet<DischargeType> DischargeTypes { get; set; }
        public DbSet<AppointmentType> AppointmentTypes { get; set; }
        public DbSet<RoomType> RoomTypes { get; set; }
        public DbSet<RoomGrade> RoomGrades { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomAllocation> RoomAllocations { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Inpatient> Inpatients { get; set; }
        public DbSet<InpatientStatus> InpatientStatuses { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Appointment> Appointments { get; set; }


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

            builder.Entity<RoomAllocation>()
                .HasOne(p => p.Room)
                .WithMany(p => p.Allocations)
                .HasForeignKey(p => p.RoomNo);
            
            builder.Entity<RoomAllocation>()
                .HasOne(p => p.Booking)
                .WithMany(p => p.Allocations)
                .HasForeignKey(p => p.BookingId);
            
            builder.Entity<RoomAllocation>()
                .HasOne(p => p.Patient)
                .WithMany(p => p.Allocations)
                .HasForeignKey(p => p.PatientId);
            
            builder.Entity<RoomAllocation>()
                .HasOne(p => p.Inpatient)
                .WithMany(p => p.Allocations)
                .HasForeignKey(p => p.InpatientId);

            builder.Entity<Inpatient>()
                .HasOne(p => p.Room)
                .WithMany()
                .HasForeignKey(p => p.RoomNo);

            builder.Entity<Inpatient>()
                .Ignore(p => p.Status);

            builder.Entity<Bill>()
                .Property(p => p.Amount)
                .HasColumnType("money");
            builder.Entity<Payment>()
                .Property(p => p.PaidAmount)
                .HasColumnType("money");
            builder.Entity<Expense>()
                .Property(p => p.Amount)
                .HasColumnType("money");

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
