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


        public async Task<bool> AddTestDoctors()
        {
            var docMales = new Bogus.Faker<Doctor>("ar")
                .RuleFor(d => d.FirstName, f => f.Name.FirstName(Bogus.DataSets.Name.Gender.Male))
                .RuleFor(d => d.LastName, f => f.Name.LastName(Bogus.DataSets.Name.Gender.Male))
                .RuleFor(d => d.Gender, f => Gender.Male)
                .RuleFor(d => d.Phone, f => f.Phone.PhoneNumber())
                .RuleFor(d => d.Mobile, f => f.Phone.PhoneNumber())
                .RuleFor(d => d.Email, f => f.Internet.Email())
                .RuleFor(d => d.Address, f => f.Address.FullAddress())
                .RuleFor(d => d.Title, f => "Doctor in NMC")
                .RuleFor(d => d.Consultant, f => f.Random.Bool())
                .RuleFor(d => d.Referrer, f => f.Random.Bool())
                .RuleFor(d => d.Surgeon, f => f.Random.Bool())
                .RuleFor(d => d.Biography, f => f.Lorem.Paragraph())
                .RuleFor(d => d.WardId, f => (f.Random.Bool() ? f.Random.Int(1, 14) : null));

            var docFemales = new Bogus.Faker<Doctor>("ar")
                .RuleFor(d => d.FirstName, f => f.Name.FirstName(Bogus.DataSets.Name.Gender.Female))
                .RuleFor(d => d.LastName, f => f.Name.LastName(Bogus.DataSets.Name.Gender.Female))
                .RuleFor(d => d.Gender, f => Gender.Female)
                .RuleFor(d => d.Phone, f => f.Phone.PhoneNumber())
                .RuleFor(d => d.Mobile, f => f.Phone.PhoneNumber())
                .RuleFor(d => d.Email, f => f.Internet.Email())
                .RuleFor(d => d.Address, f => f.Address.FullAddress())
                .RuleFor(d => d.Title, f => "Doctor in NMC")
                .RuleFor(d => d.Consultant, f => f.Random.Bool())
                .RuleFor(d => d.Referrer, f => f.Random.Bool())
                .RuleFor(d => d.Surgeon, f => f.Random.Bool())
                .RuleFor(d => d.Biography, f => f.Lorem.Paragraph())
                .RuleFor(d => d.WardId, f => (f.Random.Bool() ? f.Random.Int(1, 14) : null));

            if(!Doctors.Any())
            {
                Doctors.AddRange(docMales.Generate(20));
                Doctors.AddRange(docFemales.Generate(20));
                try
                {
                    await SaveChangesAsync();
                    
                }
                catch
                {
                    return false;
                }
            }

            return true;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

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
                j => j.HasKey(t => new { t.RoleId, t.UserId  })
                );

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
            SeedRolesAndUsers(builder);
            SeedTypes(builder);
            SeedWards(builder);
            
        }

        private void SeedTypes(ModelBuilder builder)
        {
            builder.Entity<Language>()
                .HasData(
                new Language { Id = "en", Name = "Emglish", NameAr = "انجليزي", SortKey = 0 },
                new Language { Id = "ar", Name = "Arabic", NameAr = "عربي", SortKey = 0 }
                );
            builder.Entity<Language>()
                .Property(p => p.Id)
                .HasIdentityOptions(startValue: 3);

            builder.Entity<Country>()
                .HasData(
                    new Country { Id = "SY", Name = "Syria", NameAr = "سورية", SortKey = 0,LanguageId = "ar", NationalityName = "Syrian", NationalityNameAr = "سوري", TelecomCode = "963" },
                    new Country { Id = "US", Name = "USA", NameAr = "أمريكي", SortKey = 0,LanguageId = "en", NationalityName = "American", NationalityNameAr = "أمريكي", TelecomCode = "1" }
                );
            builder.Entity<Language>()
                .Property(p => p.Id)
                .HasIdentityOptions(startValue: 3);

            builder.Entity<City>()
                .HasData(
                    new City { Id = 1, Name = "Damascus", NameAr = "دمشق", SortKey = 0, CountryId = "SY", TelecomCode = "11" }
                );
            builder.Entity<City>()
                .Property(p => p.Id)
                .HasIdentityOptions(startValue: 3);

            builder.Entity<AppointmentType>()
                .Property(p => p.Id)
                .HasIdentityOptions(startValue: 10);
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
                .HasIdentityOptions(startValue: 10);
            builder.Entity<AdmissionType>().HasData(
                new AdmissionType { Id = 1, Name = "Normal", NameAr = "عادي" },
                new AdmissionType { Id = 2, Name = "Emergency", NameAr = "إسعاف" },
                new AdmissionType { Id = 3, Name = "Accident", NameAr = "حادث" }
                );

            builder.Entity<DischargeType>()
                .Property(p => p.Id)
                .HasIdentityOptions(startValue: 10);
            builder.Entity<DischargeType>().HasData(
                new DischargeType { Id = 1, Name = "Healing", NameAr = "شفاء" },
                new DischargeType { Id = 2, Name = "Improvement", NameAr = "تحسن" },
                new DischargeType { Id = 3, Name = "Ill", NameAr = "سوء" },
                new DischargeType { Id = 4, Name = "Death", NameAr = "وفاة" },
                new DischargeType { Id = 5, Name = "Other", NameAr = "أخرى" }
                );

            builder.Entity<RoomGrade>()
                .Property(p => p.Id)
                .HasIdentityOptions(startValue: 10);
            builder.Entity<RoomGrade>().HasData(
                new RoomGrade { Id = 1, Name = "Suite", NameAr = "جناح", Capacity = 1, Level = 10 },
                new RoomGrade { Id = 2, Name = "Excellent Class", NameAr = "درجة ممتازة", Capacity = 1, Level = 9 },
                new RoomGrade { Id = 3, Name = "First Class", NameAr = "درجة أولى", Capacity = 1, Level = 8 },
                new RoomGrade { Id = 4, Name = "Second Class", NameAr = "درجة ثانية", Capacity = 2, Level = 2 }
                );

            builder.Entity<RoomType>()
                .Property(p => p.Id)
                .HasIdentityOptions(startValue: 10);
            builder.Entity<RoomType>().HasData(
                new RoomType { Id = 1, Name = "Patient Room", NameAr = "غرفة مريض" }
                );
        }

        private void SeedWards(ModelBuilder builder)
        {
            builder.Entity<Ward>()
                .Property(p => p.Id)
                .HasIdentityOptions(startValue: 15);

            builder.Entity<Ward>().HasData(
                new Ward { Id = 1,  Floor = 1, Name = "Pediatric Department -  Incubators section (NICU)", NameAr = "جناح الأطفال - قسم الحواضن" },
                new Ward { Id = 2,  Floor = 2, Name = "Internal Medicine", NameAr = "قسم الداخلية الباطنية" },
                new Ward { Id = 3,  Floor = 3, Name = "Intensive Care Unite (ICU)", NameAr = "قسم العناية المشددة" },
                new Ward { Id = 4,  Floor = 4, Name = "Obstetric & Genecology", NameAr = "جناح النسائية والمخاض" },
                new Ward { Id = 5,  Floor = 5, Name = "Dialysis", NameAr = "قسم غسيل الكلى" },
                new Ward { Id = 6,  Floor = 6, Name = "Arthroscopy", NameAr = "قسم التنظير" },
                new Ward { Id = 7,  Floor = 6, Name = "Cath Lab - Cardiovascular (CCU)", NameAr = "قسم العناية القلبة والقثطرة القلبية" },
                new Ward { Id = 8,  Floor = 6, Name = "Blood vessels", NameAr = "قسم الأوعية" },
                new Ward { Id = 9,  Floor = -1, Name = "Urology", NameAr = "قسم البولية" },
                new Ward { Id = 10, Floor = 0, Name = "Respiratory System Diseases", NameAr = "أمراض الجهاز التنفسي" },
                new Ward { Id = 11, Floor = 4, Name = "Emergency (ER)", NameAr = "قسم الإسعاف والطوارئ" },
                new Ward { Id = 12, Floor = -1, Name = "Laboratory", NameAr = "المخبر" },
                new Ward { Id = 13, Floor = -1, Name = "Radiography", NameAr = "قسم التصوير الشعاعي" },
                new Ward { Id = 14, Floor = -2, Name = "Operation Rooms (OR)", NameAr = "جناح العمليات" }
                );

            builder.Entity<Room>().HasData
                (
                new Room { RoomNo = "10", Floor = 1, RoomTypeId = 1, RoomGradeId = 2, WardId = 1 },
                new Room { RoomNo = "11", Floor = 1, RoomTypeId = 1, RoomGradeId = 3, WardId = 1 },
                new Room { RoomNo = "12", Floor = 1, RoomTypeId = 1, RoomGradeId = 3, WardId = 1 },
                new Room { RoomNo = "13", Floor = 1, RoomTypeId = 1, RoomGradeId = 4, WardId = 1 },
                new Room { RoomNo = "14", Floor = 1, RoomTypeId = 1, RoomGradeId = 4, WardId = 1 },
                new Room { RoomNo = "15", Floor = 1, RoomTypeId = 1, RoomGradeId = 4, WardId = 1 },
                new Room { RoomNo = "20", Floor = 2, RoomTypeId = 1, RoomGradeId = 4, WardId = 2 },
                new Room { RoomNo = "21", Floor = 2, RoomTypeId = 1, RoomGradeId = 4, WardId = 2 },
                new Room { RoomNo = "22", Floor = 2, RoomTypeId = 1, RoomGradeId = 3, WardId = 2 },
                new Room { RoomNo = "23", Floor = 2, RoomTypeId = 1, RoomGradeId = 1, WardId = 2 },
                new Room { RoomNo = "24", Floor = 2, RoomTypeId = 1, RoomGradeId = 2, WardId = 2 },
                new Room { RoomNo = "25", Floor = 2, RoomTypeId = 1, RoomGradeId = 3, WardId = 2 },
                new Room { RoomNo = "30", Floor = 3, RoomTypeId = 1, RoomGradeId = 3, WardId = 3 },
                new Room { RoomNo = "31", Floor = 3, RoomTypeId = 1, RoomGradeId = 3, WardId = 3 },
                new Room { RoomNo = "32", Floor = 3, RoomTypeId = 1, RoomGradeId = 4, WardId = 3 },
                new Room { RoomNo = "33", Floor = 3, RoomTypeId = 1, RoomGradeId = 4, WardId = 3 },
                new Room { RoomNo = "34", Floor = 3, RoomTypeId = 1, RoomGradeId = 1, WardId = 3 },
                new Room { RoomNo = "35", Floor = 3, RoomTypeId = 1, RoomGradeId = 2, WardId = 3 },
                new Room { RoomNo = "40", Floor = 4, RoomTypeId = 1, RoomGradeId = 2, WardId = 4 },
                new Room { RoomNo = "41", Floor = 4, RoomTypeId = 1, RoomGradeId = 3, WardId = 4 },
                new Room { RoomNo = "42", Floor = 4, RoomTypeId = 1, RoomGradeId = 3, WardId = 4 },
                new Room { RoomNo = "43", Floor = 4, RoomTypeId = 1, RoomGradeId = 4, WardId = 4 },
                new Room { RoomNo = "44", Floor = 4, RoomTypeId = 1, RoomGradeId = 4, WardId = 4 },
                new Room { RoomNo = "45", Floor = 4, RoomTypeId = 1, RoomGradeId = 1, WardId = 4 },
                new Room { RoomNo = "50", Floor = 5, RoomTypeId = 1, RoomGradeId = 4, WardId = 5 },
                new Room { RoomNo = "51", Floor = 5, RoomTypeId = 1, RoomGradeId = 3, WardId = 5 },
                new Room { RoomNo = "52", Floor = 5, RoomTypeId = 1, RoomGradeId = 3, WardId = 5 },
                new Room { RoomNo = "53", Floor = 5, RoomTypeId = 1, RoomGradeId = 2, WardId = 5 },
                new Room { RoomNo = "54", Floor = 5, RoomTypeId = 1, RoomGradeId = 2, WardId = 5 },
                new Room { RoomNo = "55", Floor = 5, RoomTypeId = 1, RoomGradeId = 2, WardId = 5 },
                new Room { RoomNo = "56", Floor = 5, RoomTypeId = 1, RoomGradeId = 1, WardId = 5 },
                new Room { RoomNo = "60", Floor = 6, RoomTypeId = 1, RoomGradeId = 1, WardId = 6 },
                new Room { RoomNo = "61", Floor = 6, RoomTypeId = 1, RoomGradeId = 1, WardId = 6 },
                new Room { RoomNo = "62", Floor = 6, RoomTypeId = 1, RoomGradeId = 2, WardId = 6 },
                new Room { RoomNo = "63", Floor = 6, RoomTypeId = 1, RoomGradeId = 2, WardId = 6 },
                new Room { RoomNo = "64", Floor = 6, RoomTypeId = 1, RoomGradeId = 3, WardId = 6 },
                new Room { RoomNo = "65", Floor = 6, RoomTypeId = 1, RoomGradeId = 3, WardId = 6 },
                new Room { RoomNo = "66", Floor = 6, RoomTypeId = 1, RoomGradeId = 4, WardId = 6 }
                );
        }

        private static void SeedRolesAndUsers(ModelBuilder builder)
        {
            var roleNames = new[] { 
                Constants.ROLE_ADMIN,
                Constants.ROLE_ADM,
                Constants.ROLE_RECEP,
                Constants.ROLE_ACNT,
                Constants.ROLE_DR,
            };

            int roleCounter = 1;
            builder.Entity<AppRole>()
                .HasData
                (
                roleNames.Select(rn => new AppRole { 
                    Id = roleCounter++,
                    Name = rn,
                    NormalizedName = rn.ToUpper(),
                    ConcurrencyStamp = Guid.NewGuid().ToString("D")
                }).ToArray()
                );

            builder.Entity<AppRole>()
                .Property(p => p.Id)
                .HasIdentityOptions(startValue: 10);

            int userCounter = 1;
            AppUser admin = new AppUser
            {
                Id = userCounter++,
                UserName = Constants.USER_ADMIN,
                NormalizedUserName = Constants.USER_ADMIN.ToUpper(),
                Email = Constants.USER_ADMIN_EMAIL,
                NormalizedEmail = Constants.USER_ADMIN_EMAIL.ToUpper(),
                ConcurrencyStamp = Guid.NewGuid().ToString("D"),
                SecurityStamp = Guid.NewGuid().ToString("D")
            };

            AppUser adm = new AppUser
            {
                Id = userCounter++,
                UserName = "adm",
                NormalizedUserName = "ADM",
                Email = "adm@nmc",
                NormalizedEmail = "ADM@NMC",
                ConcurrencyStamp = Guid.NewGuid().ToString("D"),
                SecurityStamp = Guid.NewGuid().ToString("D")
            };

            AppUser acc = new AppUser
            {
                Id = userCounter++,
                UserName = "acc",
                NormalizedUserName = "ACC",
                Email = "acc@nmc",
                NormalizedEmail = "ACC@NMC",
                ConcurrencyStamp = Guid.NewGuid().ToString("D"),
                SecurityStamp = Guid.NewGuid().ToString("D")
            };

            var hasher = new PasswordHasher<AppUser>();
            admin.PasswordHash = hasher.HashPassword(admin, Constants.USER_ADMIN_P);
            adm.PasswordHash = hasher.HashPassword(adm, Constants.USER_ADMIN_P);
            acc.PasswordHash = hasher.HashPassword(acc, Constants.USER_ADMIN_P);

            builder.Entity<AppUser>().HasData(admin, adm, acc);

            builder.Entity<AppUser>()
                .Property(p => p.Id)
                .HasIdentityOptions(startValue: 10);

            builder.Entity<AppUserClaim>().HasData(
                new AppUserClaim { Id = 1, UserId = 1, ClaimType = "Language", ClaimValue = "en" },
                new AppUserClaim { Id = 2, UserId = 2, ClaimType = "Language", ClaimValue = "en" },
                new AppUserClaim { Id = 3, UserId = 3, ClaimType = "Language", ClaimValue = "en" }
                );

            builder.Entity<AppUserClaim>()
                .Property(p => p.Id)
                .HasIdentityOptions(startValue: 10);

            builder.Entity<AppUserRole>().HasData(
                new AppUserRole { RoleId = 1, UserId = 1 },
                new AppUserRole { RoleId = 2, UserId = 2 },
                new AppUserRole { RoleId = 4, UserId = 3 }
                );

        }
    }
}
