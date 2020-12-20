using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

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

    public enum RoomStatus
    {
        [Display(Name = "Available")] Available,
        [Display(Name = "Booked")] Booked,
        [Display(Name = "Reserved")] Reserved
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
        [Display(Name = "Allocations")] public List<RoomAllocation> Allocations { get; set; } = new();
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

    [Index(nameof(Name), IsUnique = false)]
    [Index(nameof(RequestDate), IsUnique = false)]
    public class Booking : Entity<int>
    {
        public Booking()
        {
            RequestDate = DateTime.Today;
            Active = true;
        }

        [Display(Name = "Booking Name"), Required, StringLength(50)] public string Name { get; set; }
        [Display(Name = "Request Date"), Required, DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)] public DateTime RequestDate { get; set; }
        [Display(Name = "Message"), Required, StringLength(1000)] public string Message { get; set; }
        [Display(Name = "Payment")] public int Payment { get; set; }
        [Display(Name = "Doctor")] public int? DoctorId { get; set; }
        [Display(Name = "Doctor")] public Doctor Doctor { get; set; }
        [Display(Name = "Active")] public bool Active { get; set; } = true;
        [Display(Name = "Allocations")] public List<RoomAllocation> Allocations { get; set; } = new();
        [Display(Name = "Room No."), NotMapped] public string RoomNo => Allocations?.Select(x => x.Room?.Code).FirstOrDefault();
        [Display(Name = "From"), NotMapped, DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")] public DateTime From => Allocations?.Min(x => x.Date) ?? RequestDate;
        [Display(Name = "To"), NotMapped, DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")] public DateTime To => Allocations?.Max(x => x.Date) ?? RequestDate;
        [Display(Name = "Status")] public RoomStatus Status => Allocations.FirstOrDefault().Status;
        [Display(Name = "Can Be Cancelled"), NotMapped] public bool CanBeCancelled => !(Status == RoomStatus.Reserved && Allocations.Any(x => x.InpatientId.HasValue));
    }

    [Table("RoomAllocations")]
    [Index(nameof(Date), IsUnique = false)]
    [Index(nameof(Status), IsUnique = false)]
    public class RoomAllocation : Entity<int>
    {
        public RoomAllocation()
        {
            Date = DateTime.Today;
        }

        [Display(Name = "Room"), Required, StringLength(5, MinimumLength = 1)] public int RoomId { get; set; }
        [Display(Name = "Room")] public Room Room { get; set; }
        [Display(Name = "Booking")] public int? BookingId { get; set; }
        [Display(Name = "Booking")] public Booking Booking { get; set; }
        [Display(Name = "Date"), DataType(DataType.Date), DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")] public DateTime Date { get; set; } = DateTime.Today;
        [Display(Name = "Status")] public RoomStatus Status { get; set; }
        [Display(Name = "Text")] public string Text { get; set; }
        [Display(Name = "Inpatient")] public int? InpatientId { get; set; }
        [Display(Name = "Inpatient")] public Inpatient Inpatient { get; set; }
    }

    public enum MaritalStatus
    {
        [Display(Name = "Unspecified")] Unspecified,
        [Display(Name = "Single")] Single,
        [Display(Name = "Married")] Married
    }

    [Table("Patients")]
    [Index(nameof(FirstName), IsUnique = false)]
    [Index(nameof(LastName), IsUnique = false)]
    [Index(nameof(IdentityNo), IsUnique = false)]
    [Index(nameof(Phone), IsUnique = false)]
    [Index(nameof(Mobile), IsUnique = false)]
    [Index(nameof(Email), IsUnique = false)]
    public class Patient : Entity<int>
    {
        [Display(Name = "Identity No."), Required, StringLength(50)] public string IdentityNo { get; set; }
        [Display(Name = "Name")] public string Name => $"{FirstName} {LastName}";
        [Display(Name = "FirstName"), Required, StringLength(50)] public string FirstName { get; set; }
        [Display(Name = "LastName"), Required, StringLength(50)] public string LastName { get; set; }
        [Display(Name = "FatherName"), Required, StringLength(50)] public string FatherName { get; set; }
        [Display(Name = "MotherName"), Required, StringLength(50)] public string MotherName { get; set; }
        [Display(Name = "Gender"), Required] public Gender Gender { get; set; }
        [Display(Name = "Marital Status")] public MaritalStatus MaritalStatus { get; set; }
        [Display(Name = "Birth Date"), DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)] public DateTime BirthDate { get; set; }
        [Display(Name = "Age")] public int Age => DateTime.Today.Year - BirthDate.Year;
        [Display(Name = "Phone"), StringLength(30)] public string Phone { get; set; }
        [Display(Name = "Mobile"), StringLength(30)] public string Mobile { get; set; }
        [Display(Name = "Email"), StringLength(150), DataType(DataType.EmailAddress)] public string Email { get; set; }
        [Display(Name = "Address"), StringLength(150)] public string Address { get; set; }
        [Display(Name = "Occupation"), StringLength(50)] public string Occupation { get; set; }
        [Display(Name = "Blood Group"), StringLength(10)] public string BloodGroup { get; set; }
        [Display(Name = "Medical Allergy")] public string MedicalAllergy { get; set; }
        [Display(Name = "Food Allergy")] public string FoodAllergy { get; set; }
    }

    [Table("Inpatients")]
    public class Inpatient : Entity<int>
    {
        public Inpatient()
        {
            CreatedOn = DateTime.Now;
        }
        [Display(Name = "Patient")] public int PatientId { get; set; }
        [Display(Name = "Patient")] public Patient Patient { get; set; } = new();
        [Display(Name = "Name")] public string Name => $"{Patient?.FirstName} {Patient?.LastName}";
        [Display(Name = "Ward")] public int WardId { get; set; }
        [Display(Name = "Ward")] public Ward Ward { get; set; }
        [Display(Name = "Booking")] public int? BookingId { get; set; }
        [Display(Name = "Booking")] public Booking Booking { get; set; }
        [Display(Name = "Room")] public int? RoomId { get; set; }
        [Display(Name = "Room")] public Room Room { get; set; }
        [Display(Name = "Room Grade")] public RoomGrade RoomGrade { get; set; }
        [Display(Name = "Referrer")] public int? ReferrerId { get; set; }
        [Display(Name = "Referrer")] public Doctor Referrer { get; set; }
        [Display(Name = "Referrer Notes")] public string ReferrerNotes { get; set; }
        [Display(Name = "Emergency")] public bool Emergency { get; set; }
        [Display(Name = "General")] public bool General { get; set; }
        [Display(Name = "Accident")] public bool Accident { get; set; }
        [Display(Name = "Police Ref.")] public bool PoliceRef { get; set; }
        [Display(Name = "Healing")] public bool Healing { get; set; }
        [Display(Name = "Improvement")] public bool Improvement { get; set; }
        [Display(Name = "Ill")] public bool Ill { get; set; }
        [Display(Name = "Death")] public bool Death { get; set; }
        [Display(Name = "Other")] public bool Other { get; set; }
        [Display(Name = "Companion")] public bool Companion { get; set; }
        [Display(Name = "Meals")] public string Meals { get; set; }
        [Display(Name = "GL. Account")] public string GLACC { get; set; }
        [Display(Name = "Est. Days")] public int EstDays { get; set; } = 1;
        [Display(Name = "Act. Days")] public int ActualDays => GetActulaDays();
        [Display(Name = "Created On"), DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)] public DateTime CreatedOn { get; set; }
        [Display(Name = "Admet On"), DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)] public DateTime? AdmetOn { get; set; }
        [Display(Name = "Discharged On"), DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)] public DateTime? DischargedOn { get; set; }
        [Display(Name = "Diseases")] public string Diseases { get; set; }
        [Display(Name = "Medicines")] public string Medicines { get; set; }
        [Display(Name = "Active")] public bool Active { get; set; } = true;
        [Display(Name = "Status")] public string Status => GetStatus();
        [Display(Name = "Status Time")] public DateTime StatusTime => GetStatusTime();
        [Display(Name = "Allocations")] public List<RoomAllocation> Allocations { get; set; } = new();

        private int GetActulaDays()
        {
            if (!AdmetOn.HasValue)
            {
                return 0;
            }

            if(DischargedOn.HasValue)
            {
                return (int) (DischargedOn.Value - AdmetOn.Value).TotalDays;
            }
            else
            {
                return (int)(DateTime.Today - AdmetOn.Value).TotalDays;
            }
        }

        public string GetStatus()
        {
            if (DischargedOn.HasValue)
                return "Discharged";
            else if (AdmetOn.HasValue)
                return "Admet";
            else
                return "New";
        }

        public DateTime GetStatusTime()
        {
            if (DischargedOn.HasValue)
                return DischargedOn.Value;
            else if (AdmetOn.HasValue)
                return AdmetOn.Value;
            else
                return CreatedOn;
        }

        public bool IsUpgrade()
        {
            if (Room == null || RoomGrade == RoomGrade.Unspecified)
                return false;

            return ((int)RoomGrade > (int)Room.RoomGrade);
        }

        public bool IsDowngrade()
        {
            if (Room == null || RoomGrade == RoomGrade.Unspecified)
                return false;

            return ((int)RoomGrade < (int)Room.RoomGrade);
        }
    }
}
