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
                context.Units.Add(new Unit { Name = "Internal", NameAr = "داخلية", Type = UnitType.IPD });
                context.SaveChanges();
            }

            if(!context.Specialities.Any())
            {
                context.Specialities.Add(new Speciality { Name = "Spec 1", NameAr = "اختصاص 1" });
                context.Specialities.Add(new Speciality { Name = "Spec 2", NameAr = "اختصاص 2" });
                context.SaveChanges();
            }

            if(!context.BookingReasonTypes.Any())
            {
                context.BookingReasonTypes.Add(new BookingReasonType { Name = "Reason 1", NameAr = "سبب 1" });
                context.BookingReasonTypes.Add(new BookingReasonType { Name = "Reason 2", NameAr = "سبب 2" });
                context.SaveChanges();
            }

            if(!context.Rooms.Any())
            {
                List<Room> rooms = new List<Room>();
                // Add IPD Rooms
                for (int i = 1; i <= 1; i++)
                {
                    rooms.Add(new Room { Floor = 1, RoomNo = i.ToString(), UnitId = 1 });
                }

                context.Rooms.AddRange(rooms);
                context.SaveChanges();
            }

            if(!context.Doctors.Any())
            {
                context.Doctors.AddRange(GetRandomDoctor().Generate(50));
                context.SaveChanges();
            }
            if(!context.Patients.Any())
            {
                context.Patients.AddRange(GetRandomPatient().Generate(5));
                context.SaveChanges();
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
