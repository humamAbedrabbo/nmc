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
        public DbSet<Inpatient> Inpatients { get; set; }
        public DbSet<BookingReasonType> BookingReasonTypes { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Speciality> Specialities { get; set; }
        public DbSet<DoctorExperience> DoctorExperiences { get; set; }
        public DbSet<DoctorEducation> DoctorEducations { get; set; }
        public DbSet<DoctorSchedule> DoctorSchedules { get; set; }
        public DbSet<DoctorSpeciality> DoctorSpecialities { get; set; }

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

            builder.Entity<Inpatient>()
                .HasOne(p => p.CurrentRoom)
                .WithOne(p => p.CurrentInpatient)
                .HasForeignKey<Inpatient>(p => p.CurrentRoomId);
            
            builder.Entity<Room>()
                .HasOne(p => p.CurrentInpatient)
                .WithOne(p => p.CurrentRoom)
                .HasForeignKey<Room>(p => p.CurrentInpatientId)
                .OnDelete(DeleteBehavior.ClientSetNull);
            
            builder.Entity<DoctorSpeciality>().HasKey(x => new { x.DoctorId, x.SpecialityId });
            
            builder.Entity<Doctor>()
                .HasMany(p => p.Specialities)
                .WithMany(p => p.Doctors)
                .UsingEntity<DoctorSpeciality>(
                    j => j.HasOne(p => p.Speciality).WithMany().HasForeignKey(p => p.SpecialityId),
                    j => j.HasOne(p => p.Doctor).WithMany().HasForeignKey(p => p.DoctorId)
                );
        }
    }
}
