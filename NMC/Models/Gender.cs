using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NMC.Models
{
    public enum Gender
    {
        [Display(Name = "Male")]
        Male,

        [Display(Name = "Female")]
        Female
    }
    
    public enum MaritalStatus
    {
        [Display(Name = "Unspecified")]
        Unspecified,

        [Display(Name = "Single")]
        Single,

        [Display(Name = "Married")]
        Married
    }

    [Index(nameof(Name), IsUnique = true)]
    [Index(nameof(NameAr), IsUnique = true)]
    public class Ward
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        [Display(Name = "Name (ar)")]
        public string NameAr { get; set; }

        [Display(Name = "Sort Key")]
        public int SortKey { get; set; }

        public int Floor { get; set; }
    }
    
    [Index(nameof(Name), IsUnique = true)]
    [Index(nameof(NameAr), IsUnique = true)]
    public class Speciality
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        [Display(Name = "Name (ar)")]
        public string NameAr { get; set; }

        [Display(Name = "Sort Key")]
        public int SortKey { get; set; }

        public List<Doctor> Doctors { get; set; } = new();
    }

    [Index(nameof(Name), IsUnique = true)]
    [Index(nameof(NameAr), IsUnique = true)]
    public class AdmissionType
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        [Display(Name = "Name (ar)")]
        public string NameAr { get; set; }

        [Display(Name = "Sort Key")]
        public int SortKey { get; set; }
    }

    [Index(nameof(Name), IsUnique = true)]
    [Index(nameof(NameAr), IsUnique = true)]
    public class DischargeType
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        [Display(Name = "Name (ar)")]
        public string NameAr { get; set; }

        [Display(Name = "Sort Key")]
        public int SortKey { get; set; }
    }

    [Index(nameof(Name), IsUnique = true)]
    [Index(nameof(NameAr), IsUnique = true)]
    public class AppointmentType
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        [Display(Name = "Name (ar)")]
        public string NameAr { get; set; }

        [Display(Name = "Sort Key")]
        public int SortKey { get; set; }
    }

    [Index(nameof(Name), IsUnique = true)]
    [Index(nameof(NameAr), IsUnique = true)]
    public class RoomType
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        [Display(Name = "Name (ar)")]
        public string NameAr { get; set; }

        [Display(Name = "Sort Key")]
        public int SortKey { get; set; }
    }

    [Index(nameof(Name), IsUnique = true)]
    [Index(nameof(NameAr), IsUnique = true)]
    public class RoomGrade
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        [Display(Name = "Name (ar)")]
        public string NameAr { get; set; }

        [Display(Name = "Sort Key")]
        public int SortKey { get; set; }

        public int Level { get; set; }

        public int Capacity { get; set; }
    }
    
    [Index(nameof(Name), IsUnique = true)]
    [Index(nameof(NameAr), IsUnique = true)]
    public class Language
    {
        [Key]
        [StringLength(2)]
        public string Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        [Display(Name = "Name (ar)")]
        public string NameAr { get; set; }

        [Display(Name = "Sort Key")]
        public int SortKey { get; set; }

    }
    
    [Index(nameof(Name), IsUnique = true)]
    [Index(nameof(NameAr), IsUnique = true)]
    [Index(nameof(NationalityName), IsUnique = true)]
    [Index(nameof(NationalityNameAr), IsUnique = true)]
    public class Country
    {
        [Key]
        [StringLength(2)]
        public string Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        [Display(Name = "Name (ar)")]
        public string NameAr { get; set; }

        [Display(Name = "Sort Key")]
        public int SortKey { get; set; }

        [Required]
        [StringLength(3, MinimumLength = 1)]
        [Display(Name = "Tel. Code")]
        public string TelecomCode { get; set; }

        [StringLength(2)]
        [Display(Name = "Language")]
        public string LanguageId { get; set; }

        [Display(Name = "Language")]
        public Language Language { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        [Display(Name = "Nationality")]
        public string NationalityName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        [Display(Name = "Nationality (ar)")]
        public string NationalityNameAr { get; set; }

        public List<City> Cities { get; set; } = new();
    }
    
    [Index(nameof(Name), IsUnique = false)]
    [Index(nameof(NameAr), IsUnique = false)]
    public class City
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        [Display(Name = "Name (ar)")]
        public string NameAr { get; set; }

        [Display(Name = "Sort Key")]
        public int SortKey { get; set; }

        [Required]
        [StringLength(2, MinimumLength = 1)]
        [Display(Name = "Country")]
        public string CountryId { get; set; }

        [Display(Name = "Country")]
        public Country Country { get; set; }

        [Required]
        [StringLength(3, MinimumLength = 1)]
        [Display(Name = "Tel. Code")]
        public string TelecomCode { get; set; }

    }

    [Index(nameof(FirstName), IsUnique = false)]
    [Index(nameof(LastName), IsUnique = false)]
    [Index(nameof(Phone), IsUnique = false)]
    [Index(nameof(Mobile), IsUnique = false)]
    [Index(nameof(Email), IsUnique = false)]
    public class Doctor
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        
        [Required]
        [StringLength(50, MinimumLength = 1)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Name")]
        public string Name => $"{FirstName} {LastName}";

        public Gender Gender { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string Title { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Joining Date")]
        public DateTime? JoiningDate { get; set; }

        [Display(Name = "Consultant")]
        public bool Consultant { get; set; }

        [Display(Name = "Referrer")]
        public bool Referrer { get; set; }

        [Display(Name = "Surgeon")]
        public bool Surgeon { get; set; }

        public string Biography { get; set; }

        [Display(Name = "Ward")]
        public int? WardId { get; set; }

        public Ward Ward { get; set; }

        [StringLength(30)]
        public string Phone { get; set; }

        [StringLength(30)]
        public string Mobile { get; set; }

        [StringLength(200)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [StringLength(150)]
        public string Address { get; set; }

        [Display(Name = "Photo")]
        public string PhotoUrl { get; set; }

        public List<Speciality> Specialities { get; set; } = new();
        public List<Education> Educations { get; set; } = new();
        public List<Experience> Experiences { get; set; } = new();
        public List<Schedule> Schedules { get; set; } = new();
        public List<Booking> Bookings { get; set; } = new();
    }

    public class Education
    {
        public int Id { get; set; }

        [Display(Name = "Doctor")]
        public int DoctorId { get; set; }

        [Display(Name = "Doctor")]
        public Doctor Doctor { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Institution")]
        public string Institution { get; set; }

        [StringLength(100)]
        [Display(Name = "Subject")]
        public string Subject { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Degree")]
        public string Degree { get; set; }

        [StringLength(50)]
        [Display(Name = "Grade")]
        public string Grade { get; set; }

        [Display(Name = "Starting Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime StartingDate { get; set; }

        [Display(Name = "Completing Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime CompleteDate { get; set; }
    }

    public class Experience
    {
        public int Id { get; set; }

        [Display(Name = "Doctor")]
        public int DoctorId { get; set; }

        [Display(Name = "Doctor")]
        public Doctor Doctor { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Company")]
        public string Company { get; set; }

        [StringLength(50)]
        [Display(Name = "Location")]
        public string Location { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Position")]
        public string Position { get; set; }

        [Display(Name = "Period From")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime PeriodFrom { get; set; }

        [Display(Name = "Period To")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? PeriodTo { get; set; }

        [Display(Name = "Period From")]
        public string FromStr => PeriodFrom.ToString("MMM yyyy");

        [Display(Name = "Period To")]
        public string ToStr => PeriodTo.HasValue ? PeriodTo.Value.ToString("MMM yyyy") : "Present";
    }

    [Index(nameof(FromDate), IsUnique = false)]
    [Index(nameof(ThruDate), IsUnique = false)]
    public class Schedule
    {
        public int Id { get; set; }

        [Display(Name = "From Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime FromDate { get; set; } = DateTime.Today;

        [Display(Name = "Thru Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? ThruDate { get; set; }

        [Display(Name = "Doctor")]
        public int DoctorId { get; set; }

        [Display(Name = "Doctor")]
        public Doctor Doctor { get; set; }

        [Display(Name = "Available Days")]
        public string Days { get; set; }

        [NotMapped]
        public string[] DaysList
        {
            get => Days?.Split(" ");
            set => Days = string.Join(" ", value);
        }

        [Required]
        [StringLength(20)]
        [Display(Name = "Start Time")]
        public string StartTime { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "End Time")]
        public string EndTime { get; set; }

        [Display(Name = "Message")]
        public string Message { get; set; }

        [Display(Name = "Timing")]
        public string Timing => $"{StartTime} - {EndTime}";
    }

    [Index(nameof(Name), IsUnique = false)]
    [Index(nameof(RequestDate), IsUnique = false)]
    public class Booking
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string Name { get; set; }

        [Display(Name = "Request Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-ddTHH:mm:ss}")]
        public DateTime RequestDate { get; set; } = DateTime.Now;

        [Display(Name = "Doctor")]
        public int? DoctorId { get; set; }

        [Display(Name = "Doctor")]
        public Doctor Doctor { get; set; }

        public string Message { get; set; }

        [Display(Name = "Down Payment")]
        [Range(0, int.MaxValue)]
        public int DownPayment { get; set; }

        public bool Active { get; set; } = true;

        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }

        public List<RoomAllocation> Allocations { get; set; } = new();

    }

    [Index(nameof(RoomNo), IsUnique = true)]
    public class Room
    {
        [Key]
        [StringLength(5, MinimumLength = 1)]
        [Display(Name = "Room No.")]
        public string RoomNo { get; set; }

        public int Floor { get; set; }

        [Display(Name = "Ward")]
        public int? WardId { get; set; }

        [Display(Name = "Ward")]
        public Ward Ward { get; set; }

        [Display(Name = "Room Type")]
        public int RoomTypeId { get; set; }

        [Display(Name = "Room Type")]
        public RoomType RoomType { get; set; }

        [Display(Name = "Room Grade")]
        public int? RoomGradeId { get; set; }

        [Display(Name = "Room Grade")]
        public RoomGrade RoomGrade { get; set; }

        public List<RoomAllocation> Allocations { get; set; } = new();
    }

    public enum RoomStatus
    {
        Available,
        Booked,
        Reserved
    }

    [Index(nameof(Date), IsUnique = false)]
    [Index(nameof(Status), IsUnique = false)]
    public class RoomAllocation
    {
        public int Id { get; set; }

        [Required]
        [StringLength(5, MinimumLength = 1)]
        [Display(Name = "Room No.")]
        public string RoomNo { get; set; }

        [Display(Name = "Room")]
        public Room Room { get; set; }

        [Display(Name = "Booking")]
        public int? BookingId { get; set; }

        [Display(Name = "Booking")]
        public Booking Booking { get; set; }

        [Display(Name = "Patient")]
        public int? PatientId { get; set; }

        [Display(Name = "Patient")]
        public Patient Patient { get; set; }

        [Display(Name = "Inpatient")]
        public int? InpatientId { get; set; }

        [Display(Name = "Inpatient")]
        public Inpatient Inpatient { get; set; }

        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime Date { get; set; } = DateTime.Today;

        public RoomStatus Status { get; set; }

        public string Text { get; set; }
    }

    [Index(nameof(FirstName), IsUnique = false)]
    [Index(nameof(LastName), IsUnique = false)]
    [Index(nameof(IdentityNo), IsUnique = false)]
    [Index(nameof(Phone), IsUnique = false)]
    [Index(nameof(Mobile), IsUnique = false)]
    [Index(nameof(Email), IsUnique = false)]
    [Index(nameof(NationalityId), IsUnique = false)]
    public class Patient
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        
        [Required]
        [StringLength(50, MinimumLength = 1)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [StringLength(50, MinimumLength = 1)]
        [Display(Name = "Name")]
        public string Name => $"{FirstName} {LastName}";

        [Required]
        [StringLength(50, MinimumLength = 1)]
        [Display(Name = "Father Name")]
        public string FatherName { get; set; }
        
        [Required]
        [StringLength(50, MinimumLength = 1)]
        [Display(Name = "Mother Name")]
        public string MotherName { get; set; }

        public Gender Gender { get; set; }

        [Display(Name = "Marital Status")]
        public MaritalStatus MaritalStatus { get; set; }

        public int Children { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [Display(Name = "Birth Date")]
        public DateTime BirthDate { get; set; }

        public int Age => DateTime.Today.Year - BirthDate.Year;

        [StringLength(30)]
        public string Phone { get; set; }

        [StringLength(30)]
        public string Mobile { get; set; }

        [StringLength(200)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [StringLength(150)]
        public string Address { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 1)]
        [Display(Name = "Identity No.")]
        public string IdentityNo { get; set; }

        [StringLength(2)]
        [Display(Name = "Nationality")]
        public string NationalityId { get; set; }

        [Display(Name = "Nationality")]
        public Country Nationality { get; set; }

        [StringLength(5)]
        [Display(Name = "Blood Type")]
        public string BloodType { get; set; }

        [StringLength(50)]
        public string Occupation { get; set; }

        [StringLength(30)]
        [Display(Name = "Work Phone")]
        public string WorkPhone { get; set; }

        [StringLength(50)]
        [Display(Name = "Emergency Contact")]
        public string EmergencyContact { get; set; }

        [StringLength(30)]
        [Display(Name = "Emergency Phone")]
        public string EmergencyPhone { get; set; }

        [StringLength(30)]
        [Display(Name = "Emergency Mobile")]
        public string EmergencyMobile { get; set; }

        [StringLength(150)]
        [Display(Name = "Emergency Address")]
        public string EmergencyAddress { get; set; }

        [StringLength(50)]
        [Display(Name = "Sponsor Contact")]
        public string SponsorContact { get; set; }

        [StringLength(30)]
        [Display(Name = "Sponsor Phone")]
        public string SponsorPhone { get; set; }

        [StringLength(30)]
        [Display(Name = "Sponsor Mobile")]
        public string SponsorMobile { get; set; }

        [StringLength(150)]
        [Display(Name = "Sponsor Address")]
        public string SponsorAddress { get; set; }

        public List<RoomAllocation> Allocations { get; set; } = new();
    }

    [Index(nameof(Bed), IsUnique = false)]
    [Index(nameof(AdmissionDate), IsUnique = false)]
    [Index(nameof(DischargeDate), IsUnique = false)]
    [Index(nameof(GLAccount), IsUnique = false)]
    [Index(nameof(FileNo), IsUnique = false)]
    [Index(nameof(PoliceRef), IsUnique = false)]
    [Index(nameof(Active), IsUnique = false)]
    public class Inpatient
    {
        public int Id { get; set; }

        [Display(Name = "Patient")]
        public int PatientId { get; set; }

        [Display(Name = "Patient")]
        public Patient Patient { get; set; }

        [Display(Name = "Booking")]
        public int? BookingId { get; set; }

        public Booking Booking { get; set; }

        [Display(Name = "Referrer")]
        public int? ReferrerId { get; set; }

        public Doctor Referrer { get; set; }

        [Display(Name = "Ward")]
        public int WardId { get; set; }

        [Display(Name = "Ward")]
        public Ward Ward { get; set; }
        
        [StringLength(5, MinimumLength = 1)]
        [Display(Name = "Room No.")]
        public string RoomNo { get; set; }

        [Display(Name = "Room")]
        public Room Room { get; set; }

        [Display(Name = "Room Grade")]
        public int RoomGradeId { get; set; }

        [Display(Name = "Room Grade")]
        public RoomGrade RoomGrade { get; set; }

        public int GradeLevelFactor { get; set; }

        public bool IsUpgrade => GradeLevelFactor > 0;
        public bool IsDowngrade => GradeLevelFactor < 0;

        [StringLength(50)]
        public string Bed { get; set; }

        public DateTime? BarCodeGenerated { get; set; }

        public string BarCodeUrl { get; set; }

        [Display(Name = "Status")]
        public int? StatusId { get; set; }

        public InpatientStatus Status { get; set; }

        [Display(Name = "File No.")]
        public string FileNo { get; set; }

        [Display(Name = "Admission Type")]
        public int? AdmissionTypeId { get; set; }

        [Display(Name = "Admission Type")]
        public AdmissionType AdmissionType { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-ddTHH:mm:ss}", ApplyFormatInEditMode = true)]
        [Display(Name = "Admet On")]
        public DateTime? AdmissionDate { get; set; }

        [Display(Name = "Admission Note")]
        public string AdmissionNote { get; set; }

        [Display(Name = "Police Ref.")]
        public string PoliceRef { get; set; }

        [Display(Name = "Discharge Type")]
        public int? DischargeTypeId { get; set; }

        [Display(Name = "Discharge Type")]
        public DischargeType DischargeType { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-ddTHH:mm:ss}", ApplyFormatInEditMode = true)]
        [Display(Name = "Discharged On")]
        public DateTime? DischargeDate { get; set; }

        [Display(Name = "Discharge Note")]
        public string DischargeNote { get; set; }

        public bool Deceased { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-ddTHH:mm:ss}", ApplyFormatInEditMode = true)]
        [Display(Name = "Deceased On")]
        public DateTime? DeceasedDate { get; set; }

        [Display(Name = "Decease Note")]
        public string DeceaseNote { get; set; }

        public string Companion { get; set; }

        public string Meals { get; set; }

        [Display(Name = "Medical Allergies")]
        public string MedicalAllergies { get; set; }

        [Display(Name = "Medical Allergy Note")]
        public string MedicalAllergyNote { get; set; }

        [Display(Name = "Food Allergies")]
        public string FoodAllergies { get; set; }

        [Display(Name = "Food Allergy Note")]
        public string FoodAllergyNote { get; set; }

        public string Diabeties { get; set; }

        [Display(Name = "Diabeties Notes")]
        public string DiabetiesNotes { get; set; }

        public string Diseases { get; set; }

        [Display(Name = "Diseases Notes")]
        public string DiseasesNotes { get; set; }

        public string Medicines { get; set; }
        
        [Display(Name = "Medicines Notes")]
        public string MedicinesNotes { get; set; }

        public string Smoking { get; set; }
        public string Alcohol { get; set; }

        [Display(Name = "Min. Down Payment")]
        public int MinDownPayment { get; set; }

        [StringLength(30)]
        [Display(Name = "GL. Account")]
        public string GLAccount { get; set; }

        public bool Active { get; set; } = true;

        public List<RoomAllocation> Allocations { get; set; } = new();
        public List<InpatientStatus> Statuses { get; set; } = new();
        public List<Bill> Bills { get; set; } = new();
    }

    [Index(nameof(Name), IsUnique = false)]
    [Index(nameof(StatusTime), IsUnique = false)]
    public class InpatientStatus
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string Name { get; set; }

        [Display(Name = "Inpatient")]
        public int InpatientId { get; set; }

        [Display(Name = "Inpatient")]
        public Inpatient Inpatient { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-ddTHH:mm:ss}", ApplyFormatInEditMode = true)]
        [Display(Name = "Status Time")]
        public DateTime StatusTime { get; set; } = DateTime.Now;

        public string Description { get; set; }

        [Display(Name = "User Name")]
        public string UserName { get; set; }
    }

    [Index(nameof(BillNo), IsUnique = false)]
    [Index(nameof(CreatedOn), IsUnique = false)]
    [Index(nameof(DueDate), IsUnique = false)]
    [Index(nameof(Status), IsUnique = false)]
    public class Bill
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Bill No.")]
        public string BillNo { get; set; }

        [Display(Name = "Inpatient")]
        public int? InpatientId { get; set; }

        [Display(Name = "Inpatient")]
        public Inpatient Inpatient { get; set; }

        [Display(Name = "Created On")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime CreatedOn { get; set; }

        [Display(Name = "Due Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? DueDate { get; set; }

        [Display(Name = "Amount (SYP)")]
        public decimal Amount { get; set; }

        [Display(Name = "Status")]
        public BillStatusType Status { get; set; }

        public ICollection<Payment> Payments { get; set; }
        public ICollection<Expense> ExpenseItems { get; set; }
    }

    public enum BillStatusType
    {
        [Display(Name = "Open")]
        Open,

        [Display(Name = "Partially Paid")]
        PartiallyPaid,

        [Display(Name = "Paid")]
        Paid
    }

    [Index(nameof(ItemCode), IsUnique = false)]
    [Index(nameof(PurchaseDate), IsUnique = false)]
    [Index(nameof(RoomNo), IsUnique = false)]
    [Index(nameof(Status), IsUnique = false)]
    public class Expense
    {
        public int Id { get; set; }

        [Display(Name = "Bill")]
        public int BillId { get; set; }

        [Display(Name = "Bill")]
        public Bill Bill { get; set; }

        [StringLength(50)]
        [Display(Name = "Item Code")]
        public string ItemCode { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name = "Item Description")]
        public string Description { get; set; }

        [StringLength(100)]
        [Display(Name = "Purchase From")]
        public string PurchaseFrom { get; set; }

        [Display(Name = "Purchase Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime PurchaseDate { get; set; }

        [StringLength(75)]
        [Display(Name = "Purchase By")]
        public string PurchasedBy { get; set; }

        [StringLength(10)]
        [Display(Name = "Room No.")]
        public string RoomNo { get; set; }

        [Display(Name = "Amount (SYP)")]
        public decimal Amount { get; set; }

        [Display(Name = "Status")]
        public ExpenseItemStatusType Status { get; set; }
    }

    public enum ExpenseItemStatusType
    {
        [Display(Name = "Approved")]
        Approved,

        [Display(Name = "Pending")]
        Pending
    }

    [Index(nameof(PaidDate), IsUnique = false)]
    public class Payment
    {
        public int Id { get; set; }

        [Display(Name = "Bill")]
        public int BillId { get; set; }

        [Display(Name = "Bill")]
        public Bill Bill { get; set; }

        [Display(Name = "Paid Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime PaidDate { get; set; }

        [Display(Name = "Paid Amount (SYP)")]
        public decimal PaidAmount { get; set; }

        [Display(Name = "Comments")]
        public string Comments { get; set; }
    }

    [Index(nameof(AppointmentDate), IsUnique = false)]
    [Index(nameof(Phone), IsUnique = false)]
    public class Appointment
    {
        public int Id { get; set; }

        [Display(Name = "Appointment Type")]
        public int AppointmentTypeId { get; set; }

        [Display(Name = "Appointment Type")]
        public AppointmentType AppointmentType { get; set; }

        [Display(Name = "Appointment Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime AppointmentDate { get; set; } = DateTime.Today;

        [Required]
        [StringLength(20)]
        [Display(Name = "Start Time")]
        public string StartTime { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "End Time")]
        public string EndTime { get; set; }

        [Required]
        [StringLength(75)]
        [Display(Name = "Visitor")]
        public string Visitor { get; set; }

        [Display(Name = "Patient")]
        public int? PatientId { get; set; }

        [Display(Name = "Patient")]
        public Patient Patient { get; set; }

        [StringLength(30)]
        [Display(Name = "Phone")]
        public string Phone { get; set; }

        [StringLength(30)]
        [Display(Name = "Mobile")]
        public string Mobile { get; set; }

        [Display(Name = "Doctor")]
        public int? DoctorId { get; set; }

        [Display(Name = "Doctor")]
        public Doctor Doctor { get; set; }

        [Display(Name = "Ward")]
        public int? WardId { get; set; }
        public Ward Ward { get; set; }

        [Display(Name = "Message")]
        public string Message { get; set; }

        [Display(Name = "Active")]
        public bool Active { get; set; }

        [Display(Name = "Appointment Time")]
        public string AppointmentTime => $"{StartTime} - {EndTime}";

        public string ActiveText => Active ? "Active" : "Inactive";
        public string ActiveCSS => Active ? "status-green" : "status-red";

    }
}
