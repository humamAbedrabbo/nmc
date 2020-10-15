using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NMC.Models
{
    public class Doctor
    {
        public int Id { get; set; }

        [Display(Name = "Doctor Name")]
        public string Name => $"{FirstName} {LastName}";

        [Required]
        [StringLength(75)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(75)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Gender")]
        public Gender Gender { get; set; }

        [StringLength(75)]
        [Display(Name = "Speciality")]
        public string Speciality { get; set; }

        [Display(Name = "Biography")]
        public string Biography { get; set; }

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

        [Display(Name = "Username")]
        public string Username { get; set; }

        [Display(Name = "Joining Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:YYYY-MM-dd}")]
        public DateTime? JoiningDate { get; set; }

        [Display(Name = "Consultant")]
        public bool Consultant { get; set; }

        [Display(Name = "Surgeon")]
        public bool Surgeon { get; set; }

        [Display(Name = "Referrer")]
        public bool Referrer { get; set; }

        [Display(Name = "Photo")]
        public string PhotoPath { get; set; }

        [Display(Name = "Active")]
        public bool Active { get; set; }

        public IEnumerable<DepartmentDoctor> DepartmentDoctors { get; set; }
        public ICollection<DoctorEducation> EducationDetails { get; set; }
        public ICollection<DoctorExperience> ExperienceDetails { get; set; }
        public IEnumerable<DoctorSchedule> Schedules { get; set; }
        public IEnumerable<Appointment> Appointments { get; set; }

    }
}
