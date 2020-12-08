using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NMC.Domain.Models
{
    public class Patient
    {
        public int Id { get; set; }

        [Display(Name = "Patient Name")]
        public string Name => $"{FirstName} {LastName}";

        [Required]
        [StringLength(75)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(75)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [StringLength(75)]
        [Display(Name = "Father Name")]
        public string FatherName { get; set; }

        [StringLength(75)]
        [Display(Name = "Mother Name")]
        public string MotherName { get; set; }

        [Display(Name = "Gender")]
        public Gender Gender { get; set; }

        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? DateOfBirth { get; set; }

        [Display(Name = "Married")]
        public bool Married { get; set; }

        [Display(Name = "Children")]
        public int? Children { get; set; }

        [StringLength(50)]
        [Display(Name = "National ID.")]
        public string NationalID { get; set; }

        [StringLength(50)]
        [Display(Name = "Passport No.")]
        public string PassportID { get; set; }

        [StringLength(50)]
        [Display(Name = "External ID.")]
        public string ExternalID { get; set; }

        [Display(Name = "Comments")]
        public string Comments { get; set; }

        [StringLength(75)]
        [Display(Name = "Nationality")]
        public string Nationality { get; set; }

        [StringLength(30)]
        [Display(Name = "Phone")]
        public string Phone { get; set; }

        [StringLength(30)]
        [Display(Name = "Mobile")]
        public string Mobile { get; set; }

        [StringLength(200)]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [StringLength(200)]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [StringLength(100)]
        [Display(Name = "Company")]
        public string Company { get; set; }

        [StringLength(75)]
        [Display(Name = "Occupation")]
        public string Occupation { get; set; }

        [StringLength(30)]
        [Display(Name = "Work Phone")]
        public string WorkPhone { get; set; }

        public IEnumerable<Admission> Admissions { get; set; }
        public IEnumerable<Appointment> Appointments { get; set; }
    }
}
