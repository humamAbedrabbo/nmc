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
        public DbSet<Reservation> Reservations { get; set; }
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

            //builder.Entity<Reservation>()
            //    .OwnsMany(p => p.Status, s => {
            //        s.WithOwner().HasForeignKey("ReservationId");
            //        s.Property<int>("Id");
            //        s.HasKey("Id");
            //    });

            builder.Entity<Invoice>()
                .Property(p => p.Amount)
                .HasColumnType("money");
            builder.Entity<Payment>()
                .Property(p => p.PaidAmount)
                .HasColumnType("money");
            builder.Entity<Expense>()
                .Property(p => p.Amount)
                .HasColumnType("money");


            // Master Seed
            builder.Entity<Department>().HasData(
                new Department { Id = 1, Name = "Administration", NameAr = "الادارة" },
                new Department { Id = 2, Name = "Accounting", NameAr = "قسم المحاسبة" },
                new Department { Id = 3, Name = "Pediatrics and Baby incubator", NameAr = "قسم طب الأطفال وال الحاضنات" },
                new Department { Id = 4, Name = "Internal", NameAr = "قسم الداخلية" },
                new Department { Id = 5, Name = "Care", NameAr = "قسم العناية" },
                new Department { Id = 6, Name = "Women", NameAr = "قسم النسائية" },
                new Department { Id = 7, Name = "Dialysis", NameAr = "قسم غسيل الكلى" },
                new Department { Id = 8, Name = "Arthroscopy", NameAr = "قسم التنظير" },
                new Department { Id = 9, Name = "Cardiac and catheter", NameAr = "قسم القلبية والقسطرة" },
                new Department { Id = 10, Name = "Blood vessels", NameAr = "قسم الأوعية" },
                new Department { Id = 11, Name = "Urine", NameAr = "قسم البولية" },
                new Department { Id = 12, Name = "Chest", NameAr = "قسم الصدرية" },
                new Department { Id = 13, Name = "Kitchen", NameAr = "المطبخ" },
                new Department { Id = 14, Name = "Emergency", NameAr = "الطوارئ" },
                new Department { Id = 15, Name = "Maintenance", NameAr = "قسم الصيانة" },
                new Department { Id = 16, Name = "Lab", NameAr = "المخبر" },
                new Department { Id = 17, Name = "Radiology", NameAr = "الصور الشعاعية" },
                new Department { Id = 18, Name = "Warehouse", NameAr = "المستودع" },
                new Department { Id = 19, Name = "Pharmacy", NameAr = "الصيدلية" },
                new Department { Id = 20, Name = "Surgery", NameAr = "قسم العمليات" }
                );

            builder.Entity<AppointmentType>().HasData(
                new AppointmentType { Id = 1, Name = "Routine checkup", NameAr = "فحص روتيني" },
                new AppointmentType { Id = 2, Name = "Consulting", NameAr = "استشارة طبية" },
                new AppointmentType { Id = 3, Name = "Vaccinations", NameAr = "لقاح" },
                new AppointmentType { Id = 4, Name = "Eye Care", NameAr = "عينية" },
                new AppointmentType { Id = 5, Name = "Radiology", NameAr = "تصوير شعاعي" },
                new AppointmentType { Id = 6, Name = "Referrals", NameAr = "إحالة" },
                new AppointmentType { Id = 7, Name = "Other", NameAr = "نوع آخر" }
                );

            builder.Entity<AdmissionType>().HasData(
                new AdmissionType { Id = 1, Name = "Normal", NameAr = "عادي"},
                new AdmissionType { Id = 2, Name = "Emergency", NameAr = "إسعاف"},
                new AdmissionType { Id = 3, Name = "Accident", NameAr = "حادث"}
                );

            builder.Entity<DischargeType>().HasData(
                new DischargeType { Id = 1, Name = "Healing", NameAr = "شفاء" },
                new DischargeType { Id = 2, Name = "Improvement", NameAr = "تحسن" },
                new DischargeType { Id = 3, Name = "Ill", NameAr = "سوء" },
                new DischargeType { Id = 4, Name = "Death", NameAr = "وفاة" },
                new DischargeType { Id = 5, Name = "Other", NameAr = "أخرى" }
                );

            builder.Entity<EmployeeType>().HasData(
                new EmployeeType { Id = 1, Name = "Doctor", NameAr = "طبيب" },
                new EmployeeType { Id = 2, Name = "Nurse", NameAr = "ممرض" },
                new EmployeeType { Id = 3, Name = "Laboratorist", NameAr = "مخبري" },
                new EmployeeType { Id = 4, Name = "Secretary", NameAr = "سكرتيرة" },
                new EmployeeType { Id = 5, Name = "Receptionist", NameAr = "موظف استقبال" },
                new EmployeeType { Id = 6, Name = "Accountant", NameAr = "محاسب" },
                new EmployeeType { Id = 7, Name = "Administrator", NameAr = "إداري" },
                new EmployeeType { Id = 8, Name = "Maintenance", NameAr = "صيانة" },
                new EmployeeType { Id = 9, Name = "Pharmacist", NameAr = "صيدلي" },
                new EmployeeType { Id = 10, Name = "Cleaner", NameAr = "عامل تنظيف" }
                );

            builder.Entity<RoomGrade>().HasData(
                new RoomGrade { Id = 1, Name = "Suite", NameAr = "جناح" },
                new RoomGrade { Id = 2, Name = "Excellent Class", NameAr = "درجة ممتازة" },
                new RoomGrade { Id = 3, Name = "First Class", NameAr = "درجة أولى" },
                new RoomGrade { Id = 4, Name = "Second Class", NameAr = "درجة ثانية" }
                );

            builder.Entity<RoomType>().HasData(
                new RoomType { Id = 1, Name = "Patient Room", NameAr = "غرفة مريض" },
                new RoomType { Id = 2, Name = "Emergency Room", NameAr = "غرفة طوارئ" },
                new RoomType { Id = 3, Name = "Care Room", NameAr = "غرفة عناية" },
                new RoomType { Id = 4, Name = "Baby Incubator Room", NameAr = "غرفة حاضنات" }
                );
        }
    }
}
