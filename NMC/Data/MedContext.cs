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

        public DbSet<Department> Departments { get; set; }
        public DbSet<AdmissionType> AdmissionTypes { get; set; }
        public DbSet<AppointmentType> AppointmentTypes { get; set; }
        public DbSet<DischargeType> DischargeTypes { get; set; }
        public DbSet<EmployeeType> EmployeeTypes { get; set; }
        public DbSet<RoomGrade> RoomGrades { get; set; }
        public DbSet<RoomType> RoomTypes { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<DepartmentRoom> DepartmentRooms { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<DoctorSchedule> DoctorSchedules { get; set; }
        public DbSet<DoctorEducation> DoctorEducations { get; set; }
        public DbSet<DoctorExperience> DoctorExperiences { get; set; }
        public DbSet<DepartmentDoctor> DepartmentDoctors { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Attendance> AttendanceSheets { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Admission> Admissions { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<UserNotification> UserNotifications { get; set; }
        public DbSet<ModuleUser> ModuleUsers { get; set; }


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

            builder.Entity<Room>()
                .HasAlternateKey(p => p.RoomNo);

            builder.Entity<Reservation>()
                .HasOne(p => p.Room)
                .WithMany()
                .HasForeignKey(p => p.RoomNo)
                .HasPrincipalKey(p => p.RoomNo);

            builder.Entity<DepartmentDoctor>()
                .HasOne(p => p.Doctor)
                .WithMany(p => p.DepartmentDoctors)
                .HasForeignKey(p => p.DoctorId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
            builder.Entity<DepartmentDoctor>()
                .HasOne(p => p.Department)
                .WithMany(p => p.DepartmentDoctors)
                .HasForeignKey(p => p.DoctorId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
            builder.Entity<DepartmentRoom>()
                .HasOne(p => p.Room)
                .WithMany(p => p.DepartmentRooms)
                .HasForeignKey(p => p.RoomId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
            builder.Entity<DepartmentRoom>()
                .HasOne(p => p.Department)
                .WithMany(p => p.DepartmentRooms)
                .HasForeignKey(p => p.RoomId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            builder.Entity<Reservation>()
                .OwnsMany(p => p.Status, s => {
                    s.WithOwner().HasForeignKey("ReservationId");
                    s.Property<int>("Id");
                    s.HasKey("Id");
                });

            builder.Entity<Invoice>()
                .Property(p => p.Amount)
                .HasColumnType("money");
            builder.Entity<Payment>()
                .Property(p => p.PaidAmount)
                .HasColumnType("money");
            builder.Entity<Expense>()
                .Property(p => p.Amount)
                .HasColumnType("money");


        }
    }
}
