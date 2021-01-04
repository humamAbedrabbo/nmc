using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NMC.Models
{
    [Index(nameof(LastName), IsUnique = false)]
    [Index(nameof(FirstName), IsUnique = false)]
    [Index(nameof(IsConsultant), IsUnique = false)]
    [Index(nameof(IsReferrer), IsUnique = false)]
    [Index(nameof(Phone), IsUnique = false)]
    [Index(nameof(Mobile), IsUnique = false)]
    [Index(nameof(Email), IsUnique = false)]
    public class Doctor
    {
        public int Id { get; set; }

        public string Name => $"{FirstName} {LastName}"; 

        [Required, StringLength(50, MinimumLength = 1)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required, StringLength(50, MinimumLength = 1)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public Gender Gender { get; set; }

        [Required, StringLength(50, MinimumLength = 1)]
        public string Title { get; set; }

        [Display(Name = "Consultant")]
        public bool IsConsultant { get; set; }

        [Display(Name = "Surgeon")]
        public bool IsSurgeon { get; set; }

        [Display(Name = "Referrer")]
        public bool IsReferrer { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Joining Date")]
        public DateTime? JoiningDate { get; set; }

        public string Biography { get; set; }

        [StringLength(30)]
        public string Phone { get; set; }

        [StringLength(30)]
        public string Mobile { get; set; }

        [StringLength(100)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [StringLength(150)]
        public string Address { get; set; }

        public string UserId { get; set; }

        public AppUser User { get; set; }

        public IEnumerable<Inpatient> Inpatients { get; set; }
    }
}
