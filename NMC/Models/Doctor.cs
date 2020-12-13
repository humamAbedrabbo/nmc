using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NMC.Models
{
    public class Doctor : Entity<int>
    {
        [Required]
        [MaxLength(50)]
        [MinLength(1)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        [MinLength(1)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Name")]
        public string Name => $"{FirstName} {LastName}";

        [Required]
        [MaxLength(75)]
        [MinLength(1)]
        [Display(Name = "Title")]
        public string Title { get; set; }


        [Display(Name = "Gender")]
        public Gender Gender { get; set; }

        [Display(Name = "Doctor Type")]
        public DoctorType DoctorType { get; set; }
        
        [Display(Name = "Referrer")]
        public bool Referrer { get; set; }

        [Display(Name = "Surgeon")]
        public bool Surgeon { get; set; }

        [MaxLength(30)]
        [Display(Name = "Phone")]
        public string Phone { get; set; }

        [MaxLength(30)]
        [Display(Name = "Mobile")]
        public string Mobile { get; set; }

        [MaxLength(100)]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [MaxLength(100)]
        [Display(Name = "Address")]
        public string Address { get; set; }
        
        [Display(Name = "Joining Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? JoiningDate { get; set; }

        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Display(Name = "Photo")]
        public string PhotoUrl { get; set; } = "img/user.jpg";
    }

    public enum DoctorType
    {
        Resident,
        Consultant
    }
}
