using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NMC.Models
{
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

        [Display(Name = "Doctor")]
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
}
