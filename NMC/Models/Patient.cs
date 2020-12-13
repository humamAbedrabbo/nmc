using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NMC.Models
{
    public class Patient : Entity<int>
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

        [MaxLength(50)]
        [MinLength(1)]
        [Display(Name = "Father Name")]
        public string FatherName { get; set; }

        [MaxLength(50)]
        [MinLength(1)]
        [Display(Name = "Mother Name")]
        public string MotherName { get; set; }

        [Display(Name = "Gender")]
        public Gender Gender { get; set; }

        [Display(Name = "Marital Status")]
        public MaritalStatus MaritalStatus { get; set; }

        [Display(Name = "Children")]
        public int Children { get; set; }

        [Display(Name = "Identity Type")]
        public IdentityType IdentityType { get; set; }

        [Required]
        [MaxLength(50)]
        [MinLength(1)]
        [Display(Name = "Identity No.")]
        public string IdentityNo { get; set; }

        [Required]
        [Display(Name = "Birth Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate  { get; set; }

        [Display(Name = "Current Age")]
        public int CurrentAge => (DateTime.Today.Year - BirthDate.Year);

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

        [Display(Name = "Occupation")]
        [MaxLength(50)]
        public string Occupation { get; set; }

        [Display(Name = "Blood Type")]
        public BloodType BloodType { get; set; } = BloodType.Unknown;

        [Display(Name = "RH")]
        public RH RH { get; set; } = RH.Unknown;

        [Display(Name = "Photo")]
        public string PhotoUrl { get; set; } = "img/user.jpg";
    }
}
