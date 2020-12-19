using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NMC.Models
{
    [Table("Wards")]
    [Index(nameof(Name), IsUnique = true)]
    [Index(nameof(Code), IsUnique = true)]
    public class Ward : Entity<int>
    {
        [Display(Name = "Ward"), Required, StringLength(50)] public string Name { get; set; }
        [Display(Name = "W.Code"), Required, StringLength(5)] public string Code { get; set; }
        [Display(Name = "Floor"), Required] public int Floor { get; set; }
    }

    public enum RoomType
    {
        [Display(Name = "Ward Room")] Ward
    }

    public enum RoomGrade
    {
        [Display(Name = "Unspecified")] Unspecified,
        [Display(Name = "2nd Class")] Second,
        [Display(Name = "1st Class")] First,
        [Display(Name = "Excellent")] Excellent,
        [Display(Name = "Suite")] Suite
    }

    [Table("Rooms")]
    [Index(nameof(Code), IsUnique = true)]
    public class Room : Entity<int>
    {
        [Display(Name = "Room")] public string Name => $"{Floor}/{Code}";
        [Display(Name = "Room No."), Required, StringLength(5)] public string Code { get; set; }
        [Display(Name = "Floor"), Required] public int Floor { get; set; }
        [Display(Name = "Ward")] public int? WardId { get; set; }
        [Display(Name = "Ward")] public Ward Ward { get; set; }
        [Display(Name = "Type")] public RoomType RoomType { get; set; }
        [Display(Name = "Grade")] public RoomGrade RoomGrade { get; set; }
    }

    public enum ContractType
    {
        [Display(Name = "Employee")] Employee,
        [Display(Name = "Consultant")] Consultant,
        [Display(Name = "Other")] Other,
    }

    public enum Gender
    {
        [Display(Name = "Male")] Male,
        [Display(Name = "Female")] Female
    }

    [Table("Doctors")]
    [Index(nameof(FirstName), nameof(LastName), IsUnique = false)]
    [Index(nameof(ContractType), IsUnique = false)]
    [Index(nameof(Referrer), IsUnique = false)]
    [Index(nameof(Phone), IsUnique = false)]
    [Index(nameof(Mobile), IsUnique = false)]
    [Index(nameof(Email), IsUnique = false)]
    [Index(nameof(UserName), IsUnique = false)]
    public class Doctor : Entity<int>
    {
        [Display(Name = "Name")] public string Name => $"{FirstName} {LastName}";
        [Display(Name = "Code")] public string Code => $"DR-{Id}";
        [Display(Name = "First Name"), Required, StringLength(50)] public string FirstName { get; set; }
        [Display(Name = "Last Name"), Required, StringLength(50)] public string LastName { get; set; }
        [Display(Name = "User Name"), StringLength(50)] public string UserName { get; set; }
        [Display(Name = "Title"), Required, StringLength(100)] public string Title { get; set; }
        [Display(Name = "Gender")] public Gender Gender { get; set; }
        [Display(Name = "Type")] public ContractType ContractType { get; set; }
        [Display(Name = "Referrer")] public bool Referrer { get; set; }
        [Display(Name = "Phone"), StringLength(30)] public string Phone { get; set; }
        [Display(Name = "Mobile"), StringLength(30)] public string Mobile { get; set; }
        [Display(Name = "Email"), StringLength(150), DataType(DataType.EmailAddress)] public string Email { get; set; }
        [Display(Name = "Address"), StringLength(150)] public string Address { get; set; }
        [Display(Name = "Joining Date"), DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)] public DateTime? JoiningDate { get; set; } = DateTime.Today;
        [Display(Name = "Biography"), StringLength(1000)] public string Biography { get; set; }
        [Display(Name = "Schedules")] public List<DoctorSchedule> Schedule { get; set; } = new();
        [Display(Name = "Education")] public List<DoctorEducation> Education { get; set; } = new();
        [Display(Name = "Experience")] public List<DoctorExperience> Experience { get; set; } = new();
        [Display(Name = "Specialities")] public List<Speciality> Specialities { get; set; } = new();
    }

    [Table("DoctorSpecialities")]
    public class DoctorSpeciality
    {
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public int SpecialityId { get; set; }
        public Speciality Speciality { get; set; }
    }

    [Table("DoctorSchedules")]
    [Index(nameof(FromDate), IsUnique = false)]
    [Index(nameof(ThruDate), IsUnique = false)]
    public class DoctorSchedule : Entity<int>
    {
        public DoctorSchedule()
        {
            FromDate = DateTime.Today;
        }

        [Display(Name = "Doctor")] public int DoctorId { get; set; }
        [Display(Name = "Doctor")] public Doctor Doctor { get; set; }
        [Display(Name = "From Date"), DataType(DataType.Date),DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)] public DateTime FromDate { get; set; } = DateTime.Today;
        [Display(Name = "Thru Date"), DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)] public DateTime? ThruDate { get; set; }
        [Display(Name = "Available Days")] public string Days { get; set; }
        [Display(Name = "Start Time"), Required, StringLength(20)] public string StartTime { get; set; }
        [Display(Name = "End Time"), Required, StringLength(20)] public string EndTime { get; set; }
        [Display(Name = "Message"), StringLength(150)] public string Message { get; set; }
        [Display(Name = "Timing")] public string Timing => $"{StartTime} - {EndTime}";
        [NotMapped]
        public string[] DaysList
        {
            get => Days?.Split(" ");
            set => Days = string.Join(" ", value);
        }
    }

    [Table("DoctorEducations")]
    [Index(nameof(Institution), IsUnique = false)]
    [Index(nameof(StartingYear), IsUnique = false)]
    [Index(nameof(CompletionYear), IsUnique = false)]
    public class DoctorEducation : Entity<int>
    {
        [Display(Name = "Doctor")] public int DoctorId { get; set; }
        [Display(Name = "Doctor")] public Doctor Doctor { get; set; }
        [Display(Name = "Institution"), Required, StringLength(100)] public string Institution { get; set; }
        [Display(Name = "Subject"), StringLength(100)] public string Subject { get; set; }
        [Display(Name = "Degree"), Required, StringLength(100)] public string Degree { get; set; }
        [Display(Name = "Grade"), StringLength(50)] public string Grade { get; set; }
        [Display(Name = "Starting Year")] public int StartingYear { get; set; }
        [Display(Name = "Completion Year")] public int CompletionYear { get; set; }
    }

    [Table("DoctorExperiences")]
    [Index(nameof(Company), IsUnique = false)]
    [Index(nameof(Location), IsUnique = false)]
    [Index(nameof(FromYear), IsUnique = false)]
    [Index(nameof(ToYear), IsUnique = false)]
    public class DoctorExperience : Entity<int>
    {
        [Display(Name = "Doctor")] public int DoctorId { get; set; }
        [Display(Name = "Doctor")] public Doctor Doctor { get; set; }
        [Display(Name = "Company"), Required, StringLength(100)] public string Company { get; set; }
        [Display(Name = "Location"), StringLength(50)] public string Location { get; set; }
        [Display(Name = "Position"), Required, StringLength(100)] public string Position { get; set; }
        [Display(Name = "From Year")] public int FromYear { get; set; }
        [Display(Name = "To Year")] public int? ToYear { get; set; }
    }

    [Table("Specialities")]
    [Index(nameof(Name), IsUnique = true)]
    [Index(nameof(Code), IsUnique = true)]
    public class Speciality : Entity<int>
    {
        [Display(Name = "Speciality"), Required, StringLength(50)] public string Name { get; set; }
        [Display(Name = "S.Code"), Required, StringLength(5)] public string Code { get; set; }
        [Display(Name = "Doctors")] public List<Doctor> Doctors { get; set; } = new();
    }
}
