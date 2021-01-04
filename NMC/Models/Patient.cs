using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NMC.Models
{
    [Index(nameof(FirstName), IsUnique = false)]
    [Index(nameof(LastName), IsUnique = false)]
    [Index(nameof(IdNo), IsUnique = true)]
    public class Patient
    {
        public int Id { get; set; }

        public string Name => $"{FirstName} {LastName}";

        [Required, StringLength(50, MinimumLength = 1)]
        [Display(Name = "Identity No.")]
        public string IdNo { get; set; }

        [Display(Name = "ID. Type")]
        public IdType IdType { get; set; }

        [Required, StringLength(50, MinimumLength = 1)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required, StringLength(50, MinimumLength = 1)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        
        [Required, StringLength(50, MinimumLength = 1)]
        [Display(Name = "Father Name")]
        public string FatherName { get; set; }
        
        [Required, StringLength(50, MinimumLength = 1)]
        [Display(Name = "Mother Name")]
        public string MotherName { get; set; }

        public Gender Gender { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Birthdate")]
        public DateTime Birthdate { get; set; } = DateTime.Today;

        public int Age => DateTime.Today.Year - Birthdate.Year;

        [Display(Name = "Married")]
        public bool? IsMarried { get; set; }

        [StringLength(30)]
        public string Phone { get; set; }

        [StringLength(30)]
        public string Mobile { get; set; }

        [StringLength(100)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [StringLength(150)]
        public string Address { get; set; }

        [StringLength(50)]
        public string Occupation { get; set; }

        [StringLength(50)]
        public string Company { get; set; }
    }

}
