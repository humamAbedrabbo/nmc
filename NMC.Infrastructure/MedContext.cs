using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NMC.Core;
using NMC.Domain.Models;

namespace NMC.Infrastructure
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

        public DbSet<SBMenu.SBMenuItem> SBMenuItems { get; set; }
        public DbSet<SBMenu.SBMenuSection> SBMenuSections { get; set; }
        public DbSet<SBMenu.SBMenuSectionItem> SBMenuSectionItems { get; set; }

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
                .HasForeignKey(p => p.DepartmentId)
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
                .HasForeignKey(p => p.DepartmentId)
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

            builder.Entity<Department>()
                .Property(p => p.Id)
                .HasIdentityOptions(startValue: 100);

            builder.Entity<Department>().HasData(
                new Department { Id = 1, Name = "Administration", NameAr = "الادارة" },
                new Department { Id = 2, Name = "Financial and Accounting Department ", NameAr = "الإدارة المالية و قسم المحاسبة" },
                new Department { Id = 3, Name = "Pediatric Department -  Incubators section (NICU)", NameAr = "جناح الأطفال - قسم الحواضن" },
                new Department { Id = 4, Name = "Internal Medicine", NameAr = "قسم الداخلية الباطنية" },
                new Department { Id = 5, Name = "Intensive Care Unite (ICU)", NameAr = "قسم العناية المشددة" },
                new Department { Id = 6, Name = "Obstetric & Genecology", NameAr = "جناح النسائية والمخاض" },
                new Department { Id = 7, Name = "Dialysis", NameAr = "قسم غسيل الكلى" },
                new Department { Id = 8, Name = "Arthroscopy", NameAr = "قسم التنظير" },
                new Department { Id = 9, Name = "Cath Lab - Cardiovascular (CCU)", NameAr = "قسم العناية القلبة والقثطرة القلبية" },
                new Department { Id = 10, Name = "Blood vessels", NameAr = "قسم الأوعية" },
                new Department { Id = 11, Name = "Urology", NameAr = "قسم البولية" },
                new Department { Id = 12, Name = "Respiratory System Diseases", NameAr = "أمراض الجهاز التنفسي" },
                new Department { Id = 13, Name = "Catering section", NameAr = "قسم الإطعام" },
                new Department { Id = 14, Name = "Emergency (ER)", NameAr = "قسم الإسعاف والطوارئ" },
                new Department { Id = 15, Name = "Maintenance Department", NameAr = "قسم الصيانة" },
                new Department { Id = 16, Name = "Laboratory", NameAr = "المخبر" },
                new Department { Id = 17, Name = "Radiography", NameAr = "قسم التصوير الشعاعي" },
                new Department { Id = 18, Name = "Medical warehouse", NameAr = "المستودع الطبي" },
                new Department { Id = 19, Name = "Pharmacy", NameAr = "الصيدلية" },
                new Department { Id = 20, Name = "Operation Rooms (OR)", NameAr = "جناح العمليات" }
                );

            builder.Entity<AppointmentType>()
                .Property(p => p.Id)
                .HasIdentityOptions(startValue: 100);
            builder.Entity<AppointmentType>().HasData(
                new AppointmentType { Id = 1, Name = "Routine checkup", NameAr = "فحص روتيني" },
                new AppointmentType { Id = 2, Name = "Consulting", NameAr = "استشارة طبية" },
                new AppointmentType { Id = 3, Name = "Vaccinations", NameAr = "لقاح" },
                new AppointmentType { Id = 4, Name = "Eye Care", NameAr = "عينية" },
                new AppointmentType { Id = 5, Name = "Radiology", NameAr = "تصوير شعاعي" },
                new AppointmentType { Id = 6, Name = "Referrals", NameAr = "إحالة" },
                new AppointmentType { Id = 7, Name = "Other", NameAr = "نوع آخر" }
                );

            builder.Entity<AdmissionType>()
                .Property(p => p.Id)
                .HasIdentityOptions(startValue: 100);
            builder.Entity<AdmissionType>().HasData(
                new AdmissionType { Id = 1, Name = "Normal", NameAr = "عادي"},
                new AdmissionType { Id = 2, Name = "Emergency", NameAr = "إسعاف"},
                new AdmissionType { Id = 3, Name = "Accident", NameAr = "حادث"}
                );

            builder.Entity<DischargeType>()
                .Property(p => p.Id)
                .HasIdentityOptions(startValue: 100);
            builder.Entity<DischargeType>().HasData(
                new DischargeType { Id = 1, Name = "Healing", NameAr = "شفاء" },
                new DischargeType { Id = 2, Name = "Improvement", NameAr = "تحسن" },
                new DischargeType { Id = 3, Name = "Ill", NameAr = "سوء" },
                new DischargeType { Id = 4, Name = "Death", NameAr = "وفاة" },
                new DischargeType { Id = 5, Name = "Other", NameAr = "أخرى" }
                );

            builder.Entity<EmployeeType>()
                .Property(p => p.Id)
                .HasIdentityOptions(startValue: 100);
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

            builder.Entity<RoomGrade>()
                .Property(p => p.Id)
                .HasIdentityOptions(startValue: 100);
            builder.Entity<RoomGrade>().HasData(
                new RoomGrade { Id = 1, Name = "Suite", NameAr = "جناح" },
                new RoomGrade { Id = 2, Name = "Excellent Class", NameAr = "درجة ممتازة" },
                new RoomGrade { Id = 3, Name = "First Class", NameAr = "درجة أولى" },
                new RoomGrade { Id = 4, Name = "Second Class", NameAr = "درجة ثانية" }
                );

            builder.Entity<RoomType>()
                .Property(p => p.Id)
                .HasIdentityOptions(startValue: 100);
            builder.Entity<RoomType>().HasData(
                new RoomType { Id = 1, Name = "Patient Room", NameAr = "غرفة مريض" },
                new RoomType { Id = 2, Name = "Emergency Room", NameAr = "غرفة طوارئ" },
                new RoomType { Id = 3, Name = "Care Room", NameAr = "غرفة عناية" },
                new RoomType { Id = 4, Name = "Baby Incubator Room", NameAr = "غرفة حاضنات" }
                );


            builder.Entity<SBMenu.SBMenuItem>()
                .HasOne(p => p.Parent)
                .WithMany(prop => prop.Items)
                .HasForeignKey(p => p.ParentId)
                .OnDelete(DeleteBehavior.Cascade);

            // Seed Menu
            var menu = new[]
            {
                new SBMenu.SBMenuItem { Id = 1, SortKey = 1, HRef="/Index", Text = "Dashboard", Icon = "fa fa-dashboard", Visible = true, Enabled = true },
                new SBMenu.SBMenuItem { Id = 2, SortKey = 2, HRef="/UI1/Doctors/Index", Text = "Doctors", Icon = "fa fa-user-md", Visible = true, Enabled = true },
                new SBMenu.SBMenuItem { Id = 3, SortKey = 3, HRef="/UI1/Patients/Index", Text = "Patients", Icon = "fa fa-wheelchair", Visible = true, Enabled = true },
                new SBMenu.SBMenuItem { Id = 4, SortKey = 4, HRef="/UI1/Appointments/Index", Text = "Appointments", Icon = "fa fa-calendar", Visible = true, Enabled = true },
                new SBMenu.SBMenuItem { Id = 5, SortKey = 5, HRef="/UI1/Doctors/DoctorScheduleIndex", Text = "Doctor Schedules", Icon = "fa fa-calendar-check-o", Visible = true, Enabled = true },
                new SBMenu.SBMenuItem { Id = 6, SortKey = 6, HRef="/UI1/Departments/Index", Text = "Departments", Icon = "fa fa-calendar-check-o", Visible = true, Enabled = true },
                new SBMenu.SBMenuItem { Id = 7, SortKey = 7, HRef="/UI1/Rooms/Index", Text = "Rooms", Icon = "fa fa-cube", Visible = true, Enabled = true },
                new SBMenu.SBMenuItem { Id = 8, SortKey = 8, HRef="/UI1/Reservations/Index", Text = "Reservations", Icon = "fa fa-envelope-o", Visible = true, Enabled = true },
                new SBMenu.SBMenuItem { Id = 9, SortKey = 9, HRef="/UI1/Admissions/Index", Text = "Admissions", Icon = "fa fa-bed", Visible = true, Enabled = true },
                new SBMenu.SBMenuItem { Id = 10, SortKey = 10, HRef="#", Text = "Employees", Icon = "fa fa-user", Visible = true, Enabled = true },
                new SBMenu.SBMenuItem { Id = 11, ParentId = 10, SortKey = 11, HRef="/UI1/Employees/Index", Text = "Employee List", Icon = "", Visible = true, Enabled = true },
                new SBMenu.SBMenuItem { Id = 12, ParentId = 10, SortKey = 12, HRef="#", Text = "Attendance", Icon = "", Visible = true, Enabled = true },
                new SBMenu.SBMenuItem { Id = 13, SortKey = 13, HRef="#", Text = "Accounts", Icon = "fa fa-money", Visible = true, Enabled = true },
                new SBMenu.SBMenuItem { Id = 14, ParentId = 13, SortKey = 14, HRef="#", Text = "Invoices", Icon = "", Visible = true, Enabled = true },
                new SBMenu.SBMenuItem { Id = 15, ParentId = 13, SortKey = 15, HRef="#", Text = "Payments", Icon = "", Visible = true, Enabled = true },
                new SBMenu.SBMenuItem { Id = 16, ParentId = 13, SortKey = 16, HRef="#", Text = "Expenses", Icon = "", Visible = true, Enabled = true },
                new SBMenu.SBMenuItem { Id = 17, SortKey = 17, HRef="#", Text = "Types", Icon = "fa fa-cogs", Visible = true, Enabled = true },
                new SBMenu.SBMenuItem { Id = 18, ParentId = 17, SortKey = 18, HRef="/UI1/RoomTypes/Index", Text = "Room Types", Icon = "", Visible = true, Enabled = true },
                new SBMenu.SBMenuItem { Id = 19, ParentId = 17, SortKey = 19, HRef="/UI1/RoomGrades/Index", Text = "Room Grades", Icon = "", Visible = true, Enabled = true },
                new SBMenu.SBMenuItem { Id = 20, ParentId = 17, SortKey = 20, HRef="/UI1/AppointmentTypes/Index", Text = "Appointment Types", Icon = "", Visible = true, Enabled = true },
                new SBMenu.SBMenuItem { Id = 21, ParentId = 17, SortKey = 21, HRef="/UI1/AdmissionTypes/Index", Text = "Admission Types", Icon = "", Visible = true, Enabled = true },
                new SBMenu.SBMenuItem { Id = 22, ParentId = 17, SortKey = 22, HRef="/UI1/DischargeTypes/Index", Text = "Discharge Types", Icon = "", Visible = true, Enabled = true },
                new SBMenu.SBMenuItem { Id = 23, ParentId = 17, SortKey = 23, HRef="/UI1/EmployeeTypes/Index", Text = "Employee Types", Icon = "", Visible = true, Enabled = true },
                new SBMenu.SBMenuItem { Id = 24, SortKey = 24, HRef="#", Text = "Reports", Icon = "fa fa-flag-o", Visible = true, Enabled = true },
                new SBMenu.SBMenuItem { Id = 25, ParentId = 24, SortKey = 25, HRef="#", Text = "Report 1", Icon = "", Visible = true, Enabled = true },
                new SBMenu.SBMenuItem { Id = 26, ParentId = 26, SortKey = 25, HRef="#", Text = "Report 2", Icon = "", Visible = true, Enabled = true },
                new SBMenu.SBMenuItem { Id = 27, SortKey = 27, HRef="#", Text = "Settings", Icon = "fa fa-cog", Visible = true, Enabled = true },
            };
            builder.Entity<SBMenu.SBMenuItem>().HasData(menu);

            var section = new SBMenu.SBMenuSection { Id = 1, Role = "Admin", SortKey = 1, Text = "Main" };
            builder.Entity<SBMenu.SBMenuSection>().HasData(section);

            var sectionItems = new[]
            {
                new SBMenu.SBMenuSectionItem { Id = 1, SortKey = 1, MenuItemId = 1, SectionId = 1 },
                new SBMenu.SBMenuSectionItem { Id = 2, SortKey = 2, MenuItemId = 2, SectionId = 1 },
                new SBMenu.SBMenuSectionItem { Id = 3, SortKey = 3, MenuItemId = 3, SectionId = 1 },
                new SBMenu.SBMenuSectionItem { Id = 4, SortKey = 4, MenuItemId = 4, SectionId = 1 },
                new SBMenu.SBMenuSectionItem { Id = 5, SortKey = 5, MenuItemId = 5, SectionId = 1 },
                new SBMenu.SBMenuSectionItem { Id = 6, SortKey = 6, MenuItemId = 6, SectionId = 1 },
                new SBMenu.SBMenuSectionItem { Id = 7, SortKey = 7, MenuItemId = 7, SectionId = 1 },
                new SBMenu.SBMenuSectionItem { Id = 8, SortKey = 8, MenuItemId = 8, SectionId = 1 },
                new SBMenu.SBMenuSectionItem { Id = 9, SortKey = 9, MenuItemId = 9, SectionId = 1 },
                new SBMenu.SBMenuSectionItem { Id = 10, SortKey = 10, MenuItemId = 10, SectionId = 1 },
                new SBMenu.SBMenuSectionItem { Id = 11, SortKey = 11, MenuItemId = 13, SectionId = 1 },
                new SBMenu.SBMenuSectionItem { Id = 12, SortKey = 12, MenuItemId = 17, SectionId = 1 },
                new SBMenu.SBMenuSectionItem { Id = 13, SortKey = 13, MenuItemId = 24, SectionId = 1 },
                new SBMenu.SBMenuSectionItem { Id = 14, SortKey = 14, MenuItemId = 27, SectionId = 1 },
            };
            builder.Entity<SBMenu.SBMenuSectionItem>().HasData(sectionItems);

            // Seed Roles
            var roles = new[]
            {
                new AppRole { Id = 1, Name = AppRole.ROLE_ADMIN.ToString(), NormalizedName = AppRole.ROLE_ADMIN.ToString().ToUpper() },
                new AppRole { Id = 2, Name = AppRole.ROLE_ADMISSION.ToString(), NormalizedName = AppRole.ROLE_ADMISSION.ToString().ToUpper() },
                new AppRole { Id = 3, Name = AppRole.ROLE_DOCTOR.ToString(), NormalizedName = AppRole.ROLE_DOCTOR.ToString().ToUpper() },
            };

            builder.Entity<AppRole>().HasData(roles);
            builder.Entity<IdentityUserRole<int>>().HasData(new IdentityUserRole<int> { UserId = 1, RoleId = 1 });

            var menuAdmission = new[]
            {
                new SBMenu.SBMenuItem { Id = 28, SortKey = 28, HRef="/UI1/Admissions/Index", Text = "Inpatients", Icon = "fa fa-bed", Visible = true, Enabled = true },
                new SBMenu.SBMenuItem { Id = 29, SortKey = 29, HRef="/UI1/Reservations/Index", Text = "Bookings", Icon = "fa fa-envelope-o", Visible = true, Enabled = true },
                new SBMenu.SBMenuItem { Id = 30, SortKey = 30, HRef="/UI1/Doctors/Index", Text = "Doctors", Icon = "fa fa-user-md", Visible = true, Enabled = true },
            };
            builder.Entity<SBMenu.SBMenuItem>().HasData(menuAdmission);
            var sectionAdmission = new SBMenu.SBMenuSection { Id = 2, Role = AppRole.ROLE_ADMISSION, SortKey = 2, Text = "Admission" };
            builder.Entity<SBMenu.SBMenuSection>().HasData(sectionAdmission);

            var sectionItemsAdmission = new[]
            {
                new SBMenu.SBMenuSectionItem { Id = 15, SortKey = 15, MenuItemId = 28, SectionId = 2 },
                new SBMenu.SBMenuSectionItem { Id = 16, SortKey = 16, MenuItemId = 29, SectionId = 2 },
                new SBMenu.SBMenuSectionItem { Id = 17, SortKey = 17, MenuItemId = 30, SectionId = 2 },
            };
            builder.Entity<SBMenu.SBMenuSectionItem>().HasData(sectionItemsAdmission);

            var menuDoctor = new[]
            {
                new SBMenu.SBMenuItem { Id = 31, SortKey = 31, HRef="/UI1/Admissions/Index", Text = "Inpatients", Icon = "fa fa-bed", Visible = true, Enabled = true },
                new SBMenu.SBMenuItem { Id = 32, SortKey = 32, HRef="/UI1/Reservations/Index", Text = "Bookings", Icon = "fa fa-envelope-o", Visible = true, Enabled = true },

            };
            builder.Entity<SBMenu.SBMenuItem>().HasData(menuDoctor);
            var sectionDoctor = new SBMenu.SBMenuSection { Id = 3, Role = AppRole.ROLE_DOCTOR, SortKey = 3, Text = "Doctor" };
            builder.Entity<SBMenu.SBMenuSection>().HasData(sectionDoctor);

            var sectionItemsDoctor = new[]
            {
                new SBMenu.SBMenuSectionItem { Id = 33, SortKey = 33, MenuItemId = 31, SectionId = 3 },
                new SBMenu.SBMenuSectionItem { Id = 34, SortKey = 34, MenuItemId = 32, SectionId = 3 },
            };
            builder.Entity<SBMenu.SBMenuSectionItem>().HasData(sectionItemsDoctor);

            AppUser admission = new AppUser
            {
                Id = 2,
                UserName = "admission",
                NormalizedUserName = "ADMISSION",
                Email = "admission@localhost",
                NormalizedEmail = "ADMISSION@LOCALHOST",
                ConcurrencyStamp = Guid.NewGuid().ToString("D"),
                SecurityStamp = Guid.NewGuid().ToString("D")
            };

            admission.PasswordHash = hasher.HashPassword(admission, "123456");

            builder.Entity<AppUser>().HasData(admission);

            builder.Entity<IdentityUserClaim<int>>().HasData(
                new IdentityUserClaim<int> { Id = 2, UserId = 2, ClaimType = "Language", ClaimValue = "en" }
                );
            builder.Entity<IdentityUserRole<int>>().HasData(new IdentityUserRole<int> { UserId = 2, RoleId = 2 });

            AppUser doctorUser = new AppUser
            {
                Id = 3,
                UserName = "doctor",
                NormalizedUserName = "DOCTOR",
                Email = "doctor@localhost",
                NormalizedEmail = "DOCTOR@LOCALHOST",
                ConcurrencyStamp = Guid.NewGuid().ToString("D"),
                SecurityStamp = Guid.NewGuid().ToString("D")
            };
            doctorUser.PasswordHash = hasher.HashPassword(doctorUser, "123456");

            builder.Entity<AppUser>().HasData(doctorUser);

            builder.Entity<IdentityUserClaim<int>>().HasData(
                new IdentityUserClaim<int> { Id = 3, UserId = 3, ClaimType = "Language", ClaimValue = "en" }
                );
            builder.Entity<IdentityUserRole<int>>().HasData(new IdentityUserRole<int> { UserId = 3, RoleId = 3 });

            var doctor = new Doctor
            {
                Id = 1,
                FirstName = "An",
                LastName = "Example",
                Gender = Gender.Male,
                Active = true,
                Consultant = true,
                Referrer = true,
                Phone = "+963-11-5555555",
                Mobile = "+963-993-555555",
                Email = "an.example@localhost",
                Address = "Planet Earth",
                Biography = "Greate personality",
                Speciality = "Cancer",
                JoiningDate = new DateTime(2000, 10, 10),
                Username = "doctor"
            };
            builder.Entity<Doctor>().HasData(doctor);

            var edu = new[]
            {
                new DoctorEducation { Id = 1, DoctorId = 1, Institution = "University 1", Degree = "Degree 1", Subject = "Cancer", Grade = "A", StartingDate = new DateTime(1990,1,1), CompleteDate = new DateTime(1998,1,1) },
                new DoctorEducation { Id = 2, DoctorId = 1, Institution = "University 2", Degree = "Degree 2", Subject = "Cancer2", Grade = "A", StartingDate = new DateTime(2000,1,1), CompleteDate = new DateTime(2005,1,1) },
            };
            builder.Entity<DoctorEducation>().HasData(edu);

            var exp = new[]
            {
                new DoctorExperience { Id = 1, DoctorId = 1, Company = "Company 1", Location = "UK", Position = "Doctor", PeriodFrom = new DateTime(2006,1,1), PeriodTo = new DateTime(2008,1,1) },
                new DoctorExperience { Id = 2, DoctorId = 1, Company = "Company 2", Location = "UK", Position = "Doctor", PeriodFrom = new DateTime(2008,1,1), PeriodTo = new DateTime(2009,1,1) },
                new DoctorExperience { Id = 3, DoctorId = 1, Company = "NMC", Location = "SYRIA", Position = "Doctor", PeriodFrom = new DateTime(2009,1,1) },
            };
            builder.Entity<DoctorExperience>().HasData(exp);

            var rooms = new[]
            {
                new Room { Id = 1, FloorNo = 1, RoomNo = "11", BedCount = 1, RoomTypeId = 1, RoomGradeId = 1  },
                new Room { Id = 2, FloorNo = 1, RoomNo = "12", BedCount = 1, RoomTypeId = 1, RoomGradeId = 1  },
                new Room { Id = 3, FloorNo = 1, RoomNo = "13", BedCount = 1, RoomTypeId = 1, RoomGradeId = 2  },
                new Room { Id = 4, FloorNo = 1, RoomNo = "14", BedCount = 1, RoomTypeId = 1, RoomGradeId = 1  },
                new Room { Id = 5, FloorNo = 1, RoomNo = "15", BedCount = 1, RoomTypeId = 1, RoomGradeId = 2  },
                new Room { Id = 6, FloorNo = 1, RoomNo = "16", BedCount = 1, RoomTypeId = 1, RoomGradeId = 1  },
                new Room { Id = 7, FloorNo = 1, RoomNo = "17", BedCount = 1, RoomTypeId = 1, RoomGradeId = 1  },
                new Room { Id = 8, FloorNo = 1, RoomNo = "18", BedCount = 1, RoomTypeId = 1, RoomGradeId = 1  },
                new Room { Id = 9, FloorNo = 1, RoomNo = "19", BedCount = 1, RoomTypeId = 1, RoomGradeId = 1  },
                new Room { Id = 10, FloorNo = 2, RoomNo = "21", BedCount = 1, RoomTypeId = 1, RoomGradeId = 1  },
                new Room { Id = 11, FloorNo = 2, RoomNo = "22", BedCount = 1, RoomTypeId = 1, RoomGradeId = 2  },
                new Room { Id = 12, FloorNo = 2, RoomNo = "23", BedCount = 1, RoomTypeId = 1, RoomGradeId = 1  },
                new Room { Id = 13, FloorNo = 2, RoomNo = "24", BedCount = 1, RoomTypeId = 1, RoomGradeId = 1  },
                new Room { Id = 14, FloorNo = 2, RoomNo = "25", BedCount = 1, RoomTypeId = 1, RoomGradeId = 2  },
                new Room { Id = 15, FloorNo = 2, RoomNo = "26", BedCount = 1, RoomTypeId = 1, RoomGradeId = 1  },
                new Room { Id = 16, FloorNo = 2, RoomNo = "27", BedCount = 1, RoomTypeId = 1, RoomGradeId = 1  },
                new Room { Id = 17, FloorNo = 2, RoomNo = "28", BedCount = 1, RoomTypeId = 1, RoomGradeId = 1  },
                new Room { Id = 18, FloorNo = 2, RoomNo = "29", BedCount = 1, RoomTypeId = 1, RoomGradeId = 1  },
                new Room { Id = 19, FloorNo = 3, RoomNo = "31", BedCount = 1, RoomTypeId = 1, RoomGradeId = 1  },
                new Room { Id = 20, FloorNo = 3, RoomNo = "32", BedCount = 1, RoomTypeId = 1, RoomGradeId = 3  },
                new Room { Id = 21, FloorNo = 3, RoomNo = "33", BedCount = 1, RoomTypeId = 1, RoomGradeId = 1  },
                new Room { Id = 22, FloorNo = 3, RoomNo = "34", BedCount = 1, RoomTypeId = 1, RoomGradeId = 1  },
                new Room { Id = 23, FloorNo = 3, RoomNo = "35", BedCount = 1, RoomTypeId = 1, RoomGradeId = 1  },
                new Room { Id = 24, FloorNo = 3, RoomNo = "36", BedCount = 1, RoomTypeId = 1, RoomGradeId = 3  },
                new Room { Id = 25, FloorNo = 3, RoomNo = "37", BedCount = 1, RoomTypeId = 1, RoomGradeId = 1  },
                new Room { Id = 26, FloorNo = 3, RoomNo = "38", BedCount = 1, RoomTypeId = 1, RoomGradeId = 1  },
                new Room { Id = 27, FloorNo = 3, RoomNo = "39", BedCount = 1, RoomTypeId = 1, RoomGradeId = 2  },
            };

            builder.Entity<Room>().HasData(rooms);
        }
    }
}
