using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bogus;
using Microsoft.AspNetCore.Identity;
using NMC.Models;
using static NMC.Constants;

namespace NMC.Data
{
    public static class DbInitializer
    {
        public static void Initialize(NmcContext context)
        {
            if(!context.Roles.Any())
            {
                var roles = AppRole.GetRoles();
                context.Roles.AddRange(
                    roles.Select(r => new AppRole { Name = r, NormalizedName = r.ToUpper(), Id = Guid.NewGuid().ToString("D"), ConcurrencyStamp = Guid.NewGuid().ToString("D") })
                    );
                context.SaveChanges();
            }

            if(!context.Users.Any())
            {
                var admin = new AppUser
                {
                    UserName = "admin",
                    NormalizedUserName = "ADMIN",
                    Email = "admin@nmc",
                    NormalizedEmail = "ADMIN@NMC",
                    ConcurrencyStamp = Guid.NewGuid().ToString("D"),
                    SecurityStamp = Guid.NewGuid().ToString("D"),
                };
                var hasher = new PasswordHasher<AppUser>();
                admin.PasswordHash = hasher.HashPassword(admin, "123456");
                context.Users.Add(admin);
                context.SaveChanges();

                context.UserRoles.Add(new IdentityUserRole<string>
                {
                    UserId = admin.Id,
                    RoleId = context.Roles.First(x => x.Name == RoleAdmin).Id
                });
                context.SaveChanges();
            }
            //return;
            if(!context.Units.Any())
            {
                //context.Units.Add(new Unit { Name = "Internal", NameAr = "داخلية", Type = UnitType.IPD });
                context.Units.AddRange
                    (new[] {
                new Unit { Type = UnitType.IPD, Name = "Pediatric Department -  Incubators section (NICU)", NameAr = "جناح الأطفال - قسم الحواضن" },
                new Unit { Type = UnitType.IPD, Name = "Internal Medicine", NameAr = "قسم الداخلية الباطنية" },
                new Unit { Type = UnitType.IPD, Name = "Intensive Care Unite (ICU)", NameAr = "قسم العناية المشددة" },
                new Unit { Type = UnitType.IPD, Name = "Obstetric & Genecology", NameAr = "جناح النسائية والمخاض" },
                new Unit { Type = UnitType.IPD, Name = "Dialysis", NameAr = "قسم غسيل الكلى" },
                new Unit { Type = UnitType.IPD, Name = "Arthroscopy", NameAr = "قسم التنظير" },
                new Unit { Type = UnitType.IPD, Name = "Cath Lab - Cardiovascular (CCU)", NameAr = "قسم العناية القلبة والقثطرة القلبية" },
                new Unit { Type = UnitType.IPD, Name = "Blood vessels", NameAr = "قسم الأوعية" },
                new Unit { Type = UnitType.IPD, Name = "Urology", NameAr = "قسم البولية" },
                new Unit { Type = UnitType.IPD, Name = "Respiratory System Diseases", NameAr = "أمراض الجهاز التنفسي" },
                new Unit { Type = UnitType.IPD, Name = "Emergency (ER)", NameAr = "قسم الإسعاف والطوارئ" },
                new Unit { Type = UnitType.Unspecified, Name = "Maintenance Department", NameAr = "قسم الصيانة" },
                new Unit { Type = UnitType.Lab, Name = "Laboratory", NameAr = "المخبر" },
                new Unit { Type = UnitType.Lab, Name = "Radiography", NameAr = "قسم التصوير الشعاعي" },
                new Unit { Type = UnitType.OR, Name = "Operation Rooms (OR)", NameAr = "جناح العمليات" }
                // new Unit { Type = UnitType.Unspecified, Name = "Administration", NameAr = "الادارة" },
                // new Unit { Type = UnitType.Unspecified, Name = "Financial and Accounting Department ", NameAr = "الإدارة المالية و قسم المحاسبة" },
                // new Unit { Type = UnitType.Unspecified, Name = "Catering section", NameAr = "قسم الإطعام" },
                // new Unit { Type = UnitType.Unspecified, Name = "Medical warehouse", NameAr = "المستودع الطبي" },
                // new Unit { Type = UnitType.Unspecified, Name = "Pharmacy", NameAr = "الصيدلية" },
                    });
                context.SaveChanges();
            }

            Speciality a = null, b = null, c = null, d = null, e = null, f = null;
            if(!context.Specialities.Any())
            {
                context.Specialities.Add(a = new Speciality { Name = "بولية", NameAr = "بولية" });
                context.Specialities.Add(b = new Speciality { Name = "أوعية", NameAr = "أوعية" });
                context.Specialities.Add(c = new Speciality { Name = "قلبية", NameAr = "قلبية" });
                context.Specialities.Add(d = new Speciality { Name = "صدرية", NameAr = "صدرية" });
                context.Specialities.Add(e = new Speciality { Name = "أطفال", NameAr = "أطفال" });
                context.Specialities.Add(f = new Speciality { Name = "نسائية", NameAr = "نسائية" });
                context.SaveChanges();
            }

            if(!context.BookingReasonTypes.Any())
            {
                context.BookingReasonTypes.Add(new BookingReasonType { Name = "Operation", NameAr = "عملية جراحية" });
                context.BookingReasonTypes.Add(new BookingReasonType { Name = "Check Up", NameAr = "فحص عام" });
                context.SaveChanges();
            }

            if(!context.Rooms.Any())
            {
                List<Room> rooms = new List<Room>();
                rooms.Add(new Room { Floor = 1, RoomNo = "101", UnitId = 2, Capacity = 2 });
                rooms.Add(new Room { Floor = 1, RoomNo = "102", UnitId = 2, Capacity = 2 });
                rooms.Add(new Room { Floor = 1, RoomNo = "103", UnitId = 2, Capacity = 2 });
                rooms.Add(new Room { Floor = 1, RoomNo = "104", UnitId = 2, Capacity = 2 });
                rooms.Add(new Room { Floor = 1, RoomNo = "105", UnitId = 2, Capacity = 2 });
                rooms.Add(new Room { Floor = 1, RoomNo = "106", UnitId = 2, Capacity = 2 });
                rooms.Add(new Room { Floor = 1, RoomNo = "107", UnitId = 2, Capacity = 2 });
                rooms.Add(new Room { Floor = 1, RoomNo = "108", UnitId = 2, Capacity = 1 });
                rooms.Add(new Room { Floor = 1, RoomNo = "109", UnitId = 2, Capacity = 1 });
                rooms.Add(new Room { Floor = 1, RoomNo = "110", UnitId = 2, Capacity = 1 });
                rooms.Add(new Room { Floor = 1, RoomNo = "111", UnitId = 2, Capacity = 2 });
                rooms.Add(new Room { Floor = 1, RoomNo = "112", UnitId = 1, Capacity = 1 });
                
                rooms.Add(new Room { Floor = 2, RoomNo = "201", UnitId = 2, Capacity = 2 });
                rooms.Add(new Room { Floor = 2, RoomNo = "202", UnitId = 2, Capacity = 2 });
                rooms.Add(new Room { Floor = 2, RoomNo = "203", UnitId = 2, Capacity = 2 });
                rooms.Add(new Room { Floor = 2, RoomNo = "204", UnitId = 2, Capacity = 2 });
                rooms.Add(new Room { Floor = 2, RoomNo = "205", UnitId = 2, Capacity = 2 });
                rooms.Add(new Room { Floor = 2, RoomNo = "206", UnitId = 2, Capacity = 2 });
                rooms.Add(new Room { Floor = 2, RoomNo = "207", UnitId = 2, Capacity = 2 });
                rooms.Add(new Room { Floor = 2, RoomNo = "208", UnitId = 2, Capacity = 1 });
                rooms.Add(new Room { Floor = 2, RoomNo = "209", UnitId = 2, Capacity = 1 });
                rooms.Add(new Room { Floor = 2, RoomNo = "210", UnitId = 2, Capacity = 1 });
                rooms.Add(new Room { Floor = 2, RoomNo = "211", UnitId = 2, Capacity = 2 });
                rooms.Add(new Room { Floor = 2, RoomNo = "212", UnitId = 1, Capacity = 1 });

                rooms.Add(new Room { Floor = 3, RoomNo = "301", UnitId = 2, Capacity = 1 });
                rooms.Add(new Room { Floor = 3, RoomNo = "302", UnitId = 2, Capacity = 1 });
                rooms.Add(new Room { Floor = 3, RoomNo = "303", UnitId = 2, Capacity = 1 });
                rooms.Add(new Room { Floor = 3, RoomNo = "304", UnitId = 2, Capacity = 1 });
                rooms.Add(new Room { Floor = 3, RoomNo = "305", UnitId = 2, Capacity = 1 });
                rooms.Add(new Room { Floor = 3, RoomNo = "306", UnitId = 2, Capacity = 1 });
                rooms.Add(new Room { Floor = 3, RoomNo = "307", UnitId = 2, Capacity = 1 });
                rooms.Add(new Room { Floor = 3, RoomNo = "308", UnitId = 2, Capacity = 1 });
                rooms.Add(new Room { Floor = 3, RoomNo = "309", UnitId = 2, Capacity = 1 });

                rooms.Add(new Room { Floor = 4, RoomNo = "401", UnitId = 4, Capacity = 1 });
                rooms.Add(new Room { Floor = 4, RoomNo = "402", UnitId = 4, Capacity = 1 });
                rooms.Add(new Room { Floor = 4, RoomNo = "407", UnitId = 4, Capacity = 1 });
                rooms.Add(new Room { Floor = 4, RoomNo = "408", UnitId = 4, Capacity = 1 });
                rooms.Add(new Room { Floor = 4, RoomNo = "409", UnitId = 4, Capacity = 1 });
                rooms.Add(new Room { Floor = 4, RoomNo = "410", UnitId = 4, Capacity = 1 });
                rooms.Add(new Room { Floor = 4, RoomNo = "412", UnitId = 4, Capacity = 1 });

                rooms.Add(new Room { Floor = 6, RoomNo = "601", UnitId = 3, Capacity = 1 });
                rooms.Add(new Room { Floor = 6, RoomNo = "602", UnitId = 3, Capacity = 1 });
                rooms.Add(new Room { Floor = 6, RoomNo = "603", UnitId = 3, Capacity = 1 });
                rooms.Add(new Room { Floor = 6, RoomNo = "604", UnitId = 3, Capacity = 1 });
                rooms.Add(new Room { Floor = 6, RoomNo = "606", UnitId = 7, Capacity = 1 });
                rooms.Add(new Room { Floor = 6, RoomNo = "607", UnitId = 7, Capacity = 2 });
                rooms.Add(new Room { Floor = 6, RoomNo = "608", UnitId = 7, Capacity = 2 });
                rooms.Add(new Room { Floor = 6, RoomNo = "609", UnitId = 7, Capacity = 1 });
                rooms.Add(new Room { Floor = 6, RoomNo = "610", UnitId = 7, Capacity = 1 });
                rooms.Add(new Room { Floor = 6, RoomNo = "611", UnitId = 7, Capacity = 2 });

                context.Rooms.AddRange(rooms);
                context.SaveChanges();
            }

            if(!context.Doctors.Any())
            {
                //context.Doctors.AddRange(GetRandomDoctor().Generate(50));
                List<Doctor> doctors = new List<Doctor>();

                doctors.Add(new Doctor { IsReferrer = true, FirstName = "هشام", LastName = "سنان", Gender = Gender.Male });
                doctors.Add(new Doctor { IsReferrer = true, FirstName = "عبد الحميد", LastName = "سنان", Gender = Gender.Male });
                doctors.Add(new Doctor { IsReferrer = true, FirstName = "عبد الرحيم", LastName = "سنان", Gender = Gender.Male });
                doctors.Add(new Doctor { IsReferrer = true, FirstName = "أسامة", LastName = "قولي", Gender = Gender.Male });
                doctors.Add(new Doctor { IsReferrer = true, FirstName = "نضال", LastName = "الكسم", Gender = Gender.Male });
                doctors.Add(new Doctor { IsReferrer = true, FirstName = "رائف", LastName = "ياسين", Gender = Gender.Male });
                doctors.Add(new Doctor { IsReferrer = true, FirstName = "عامر", LastName = "تللو", Gender = Gender.Male });
                doctors.Add(new Doctor { IsReferrer = true, Specialities = { a }, FirstName = "عبد القادر", LastName = "سنان", Gender = Gender.Male });
                doctors.Add(new Doctor { IsReferrer = true, FirstName = "علاء", LastName = "ديراني", Gender = Gender.Male });
                doctors.Add(new Doctor { IsReferrer = true, FirstName = "محمد", LastName = "الأحمد", Gender = Gender.Male });
                doctors.Add(new Doctor { IsReferrer = true, FirstName = "باسل", LastName = "قوطرش", Gender = Gender.Male });
                doctors.Add(new Doctor { IsReferrer = true, FirstName = "باسل", LastName = "أبو الهيجاء", Gender = Gender.Male });
                doctors.Add(new Doctor { IsReferrer = true, FirstName = "سعيد", LastName = "فليون", Gender = Gender.Male });
                
                doctors.Add(new Doctor { IsReferrer = true, Specialities = { f }, FirstName = "جهاد", LastName = "الأشقر", Gender = Gender.Male });
                doctors.Add(new Doctor { IsReferrer = true, Specialities = { f }, FirstName = "هدى", LastName = "جيكو", Gender = Gender.Female });
                doctors.Add(new Doctor { IsReferrer = true, Specialities = { f }, FirstName = "هزار", LastName = "جيكو", Gender = Gender.Female });
                doctors.Add(new Doctor { IsReferrer = true, Specialities = { f }, FirstName = "ريد", LastName = "قدورة", Gender = Gender.Male });
                doctors.Add(new Doctor { IsReferrer = true, Specialities = { f }, FirstName = "وليد", LastName = "الشهابي", Gender = Gender.Male });
                doctors.Add(new Doctor { IsReferrer = true, Specialities = { f }, FirstName = "بسام", LastName = "الياس", Gender = Gender.Male });
                doctors.Add(new Doctor { IsReferrer = true, Specialities = { f }, FirstName = "ريم", LastName = "عرنوق", Gender = Gender.Female });
                doctors.Add(new Doctor { IsReferrer = true, Specialities = { f }, FirstName = "فاتن", LastName = "عثمان", Gender = Gender.Female });
                doctors.Add(new Doctor { IsReferrer = true, Specialities = { f }, FirstName = "أولغا", LastName = "الرفاعي", Gender = Gender.Female });
                doctors.Add(new Doctor { IsReferrer = true, Specialities = { f }, FirstName = "آلاء", LastName = "جاويش", Gender = Gender.Female });
                doctors.Add(new Doctor { IsReferrer = true, Specialities = { f }, FirstName = "صباح", LastName = "الحافظ", Gender = Gender.Female });
                doctors.Add(new Doctor { IsReferrer = true, Specialities = { f }, FirstName = "غفران", LastName = "الكل", Gender = Gender.Female });
                doctors.Add(new Doctor { IsReferrer = true, Specialities = { f }, FirstName = "جمال", LastName = "توتنجي", Gender = Gender.Male });
                doctors.Add(new Doctor { IsReferrer = true, Specialities = { f }, FirstName = "علا", LastName = "شحادة", Gender = Gender.Female });
                doctors.Add(new Doctor { IsReferrer = true, Specialities = { f }, FirstName = "رزان", LastName = "وتار", Gender = Gender.Female });
                doctors.Add(new Doctor { IsReferrer = true, Specialities = { f }, FirstName = "بشار", LastName = "الكردي", Gender = Gender.Male });
                doctors.Add(new Doctor { IsReferrer = true, Specialities = { f }, FirstName = "لطفية", LastName = "الرقيق", Gender = Gender.Female });
                doctors.Add(new Doctor { IsReferrer = true, Specialities = { f }, FirstName = "نور الهدى", LastName = "أبو الشامات", Gender = Gender.Female });
                doctors.Add(new Doctor { IsReferrer = true, Specialities = { f }, FirstName = "سلام", LastName = "مشهدي", Gender = Gender.Female });
                doctors.Add(new Doctor { IsReferrer = true, Specialities = { f }, FirstName = "غيداء", LastName = "اليوسف", Gender = Gender.Female });
                doctors.Add(new Doctor { IsReferrer = true, Specialities = { f }, FirstName = "رضوان", LastName = "فيومي", Gender = Gender.Male });
                doctors.Add(new Doctor { IsReferrer = true, Specialities = { f }, FirstName = "ميسون", LastName = "رحيم", Gender = Gender.Female });
                doctors.Add(new Doctor { IsReferrer = true, Specialities = { f }, FirstName = "فريز", LastName = "بيرقدار", Gender = Gender.Male });
                doctors.Add(new Doctor { IsReferrer = true, Specialities = { f }, FirstName = "لينا", LastName = "الدنيا", Gender = Gender.Female });
                doctors.Add(new Doctor { IsReferrer = true, Specialities = { f }, FirstName = "سلوى", LastName = "جبر", Gender = Gender.Female });
                doctors.Add(new Doctor { IsReferrer = true, Specialities = { f }, FirstName = "أحمد", LastName = "طه", Gender = Gender.Male });
                doctors.Add(new Doctor { IsReferrer = true, Specialities = { f }, FirstName = "كنعان", LastName = "السقا", Gender = Gender.Male });
                doctors.Add(new Doctor { IsReferrer = true, Specialities = { f }, FirstName = "دينا", LastName = "الخوري", Gender = Gender.Female });
                doctors.Add(new Doctor { IsReferrer = true, Specialities = { f }, FirstName = "غولناز", LastName = "عثمان", Gender = Gender.Female });
                doctors.Add(new Doctor { IsReferrer = true, Specialities = { f }, FirstName = "سمر", LastName = "السادات", Gender = Gender.Female });
                doctors.Add(new Doctor { IsReferrer = true, Specialities = { f }, FirstName = "فرناز", LastName = "نعال", Gender = Gender.Female });
                doctors.Add(new Doctor { IsReferrer = true, Specialities = { f }, FirstName = "ليلى", LastName = "طوقتلي", Gender = Gender.Female });
                doctors.Add(new Doctor { IsReferrer = true, Specialities = { f }, FirstName = "قمر", LastName = "زينة", Gender = Gender.Female });
                doctors.Add(new Doctor { IsReferrer = true, Specialities = { f }, FirstName = "سميرة", LastName = "دياب", Gender = Gender.Male });
                doctors.Add(new Doctor { IsReferrer = true, Specialities = { f }, FirstName = "فوزي", LastName = "عبد الحميد", Gender = Gender.Male });
                doctors.Add(new Doctor { IsReferrer = true, Specialities = { f }, FirstName = "أنس", LastName = "مشوح", Gender = Gender.Male });
                doctors.Add(new Doctor { IsReferrer = true, Specialities = { f }, FirstName = "ندى", LastName = "اله رشي", Gender = Gender.Female });
                doctors.Add(new Doctor { IsReferrer = true, Specialities = { f }, FirstName = "رائدة", LastName = "مللي", Gender = Gender.Female });
                
                doctors.Add(new Doctor { IsReferrer = true, Specialities = { e }, FirstName = "المصون", LastName = "طرقجي", Gender = Gender.Male });
                doctors.Add(new Doctor { IsReferrer = true, Specialities = { e }, FirstName = "نوران", LastName = "طرقجي", Gender = Gender.Female });
                doctors.Add(new Doctor { IsReferrer = true, Specialities = { e }, FirstName = "محمد ماهر", LastName = "رمضان", Gender = Gender.Male });
                doctors.Add(new Doctor { IsReferrer = true, Specialities = { e }, FirstName = "ظاقر", LastName = "سلامة", Gender = Gender.Male });
                doctors.Add(new Doctor { IsReferrer = true, Specialities = { e }, FirstName = "جهاد", LastName = "الحكيم", Gender = Gender.Male });
                doctors.Add(new Doctor { IsReferrer = true, Specialities = { e }, FirstName = "عدنان", LastName = "الحسامي", Gender = Gender.Male });
                doctors.Add(new Doctor { IsReferrer = true, Specialities = { e }, FirstName = "حسام", LastName = "دالاتي", Gender = Gender.Male });
                doctors.Add(new Doctor { IsReferrer = true, Specialities = { e }, FirstName = "معروف", LastName = "موصللي", Gender = Gender.Male });
                doctors.Add(new Doctor { IsReferrer = true, Specialities = { e }, FirstName = "سمير", LastName = "سرور", Gender = Gender.Male });
                doctors.Add(new Doctor { IsReferrer = true, Specialities = { e }, FirstName = "لينا", LastName = "الخوري", Gender = Gender.Female });
                
                doctors.Add(new Doctor { IsReferrer = true, Specialities = { d }, FirstName = "هادي", LastName = "العقاد", Gender = Gender.Male });
                doctors.Add(new Doctor { IsReferrer = true, Specialities = { d }, FirstName = "حسام", LastName = "البردان", Gender = Gender.Male });
                doctors.Add(new Doctor { IsReferrer = true, Specialities = { d }, FirstName = "عبد الرحمن", LastName = "دكاك", Gender = Gender.Male });
                doctors.Add(new Doctor { IsReferrer = true, Specialities = { d }, FirstName = "خالد", LastName = "الصباغ", Gender = Gender.Male });
                doctors.Add(new Doctor { IsReferrer = true, Specialities = { d }, FirstName = "عماد", LastName = "حفار", Gender = Gender.Male });
                
                doctors.Add(new Doctor { IsReferrer = true, Specialities = { c }, FirstName = "رشيد", LastName = "السعدي", Gender = Gender.Male });
                doctors.Add(new Doctor { IsReferrer = true, Specialities = { c }, FirstName = "أنس", LastName = "الخالد", Gender = Gender.Male });
                doctors.Add(new Doctor { IsReferrer = true, Specialities = { c }, FirstName = "مجد", LastName = "نصار", Gender = Gender.Male });
                doctors.Add(new Doctor { IsReferrer = true, Specialities = { c }, FirstName = "إياد", LastName = "شعيبي", Gender = Gender.Male });
                doctors.Add(new Doctor { IsReferrer = true, Specialities = { c }, FirstName = "إيهاب", LastName = "الزراد", Gender = Gender.Male });
                doctors.Add(new Doctor { IsReferrer = true, Specialities = { c }, FirstName = "أمين", LastName = "الخطيب", Gender = Gender.Male });
                doctors.Add(new Doctor { IsReferrer = true, Specialities = { c }, FirstName = "محمد", LastName = "الفنار", Gender = Gender.Male });
                doctors.Add(new Doctor { IsReferrer = true, Specialities = { c }, FirstName = "عبد القادر", LastName = "قطيني", Gender = Gender.Male });
                doctors.Add(new Doctor { IsReferrer = true, Specialities = { c }, FirstName = "عمرو", LastName = "طرية", Gender = Gender.Male });
                doctors.Add(new Doctor { IsReferrer = true, Specialities = { c }, FirstName = "محمود", LastName = "المطلق", Gender = Gender.Male });
                doctors.Add(new Doctor { IsReferrer = true, Specialities = { c }, FirstName = "خالد", LastName = "مصطفى", Gender = Gender.Male });
                doctors.Add(new Doctor { IsReferrer = true, Specialities = { c }, FirstName = "علي", LastName = "خدام", Gender = Gender.Male });
                doctors.Add(new Doctor { IsReferrer = true, Specialities = { c }, FirstName = "زياد", LastName = "عباس", Gender = Gender.Male });
                doctors.Add(new Doctor { IsReferrer = true, Specialities = { c }, FirstName = "مصعب", LastName = "خلايلي", Gender = Gender.Male });
                doctors.Add(new Doctor { IsReferrer = true, Specialities = { c }, FirstName = "أحمد", LastName = "غيبور", Gender = Gender.Male });
                doctors.Add(new Doctor { IsReferrer = true, Specialities = { c }, FirstName = "ماجد", LastName = "الحسين", Gender = Gender.Male });
                
                doctors.Add(new Doctor { IsReferrer = true, Specialities = { b }, FirstName = "هشام", LastName = "حمزة", Gender = Gender.Male });
                doctors.Add(new Doctor { IsReferrer = true, Specialities = { b }, FirstName = "بشار", LastName = "العجان", Gender = Gender.Male });
                doctors.Add(new Doctor { IsReferrer = true, Specialities = { b }, FirstName = "موفق", LastName = "العلبي", Gender = Gender.Male });
                
                doctors.Add(new Doctor { IsReferrer = true, Specialities = { a }, FirstName = "شهناز", LastName = "الألوسي", Gender = Gender.Female });
                doctors.Add(new Doctor { IsReferrer = true, Specialities = { a }, FirstName = "محمد", LastName = "الطويل", Gender = Gender.Male });

                context.Doctors.AddRange(doctors);
                context.SaveChanges();
            }
            if(!context.Patients.Any())
            {
                //context.Patients.AddRange(GetRandomPatient().Generate(5));
                //context.SaveChanges();
            }
        }

        private static Faker<Doctor> GetRandomDoctor()
        {
            return new Faker<Doctor>("ar")
                .RuleFor(d => d.FirstName, f => f.Person.FirstName)
                .RuleFor(d => d.LastName, f => f.Person.LastName)
                .RuleFor(d => d.Phone, f => f.Person.Phone)
                .RuleFor(d => d.Email, f => f.Person.Email)
                .RuleFor(d => d.Address, f => f.Person.Address.Street)
                .RuleFor(d => d.IsConsultant, f => f.Random.Bool())
                .RuleFor(d => d.IsReferrer, f => f.Random.Bool())
                .RuleFor(d => d.IsSurgeon, f => f.Random.Bool())
                .RuleFor(d => d.Title, f => "Specialist Doctor")
                .RuleFor(d => d.Gender, f => f.Person.Gender == Bogus.DataSets.Name.Gender.Male ? Gender.Male : Gender.Female)
                ;
        }

         private static Faker<Patient> GetRandomPatient()
        {
            return new Faker<Patient>("ar")
                .RuleFor(d => d.FirstName, f => f.Person.FirstName)
                .RuleFor(d => d.LastName, f => f.Person.LastName)
                .RuleFor(d => d.FatherName, f => f.Name.FirstName(Bogus.DataSets.Name.Gender.Male))
                .RuleFor(d => d.MotherName, f => f.Name.FirstName(Bogus.DataSets.Name.Gender.Female))
                .RuleFor(d => d.IdNo, f => f.Random.String2(11, "0123456789"))
                .RuleFor(d => d.IdType, f => IdType.National)
                .RuleFor(d => d.Birthdate, f => f.Person.DateOfBirth)
                .RuleFor(d => d.Phone, f => f.Person.Phone)
                .RuleFor(d => d.Email, f => f.Person.Email)
                .RuleFor(d => d.Address, f => f.Person.Address.Street)
                .RuleFor(d => d.IsMarried, f => f.Random.Bool())
                .RuleFor(d => d.Occupation, f => "job title")
                .RuleFor(d => d.Gender, f => f.Person.Gender == Bogus.DataSets.Name.Gender.Male ? Gender.Male : Gender.Female)
                ;
        }


    }
}
