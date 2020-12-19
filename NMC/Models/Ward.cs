using Microsoft.EntityFrameworkCore;
using System;
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
    }
}
