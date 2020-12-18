using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NMC.Models
{
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
        [Display(Name = "Patient")]
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
}
