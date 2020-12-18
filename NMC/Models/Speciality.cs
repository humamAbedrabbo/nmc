using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NMC.Models
{
    [Index(nameof(Name), IsUnique = true)]
    [Index(nameof(NameAr), IsUnique = true)]
    public class Speciality
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        [Display(Name = "Speciality")]
        public string Name { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        [Display(Name = "Speciality (ar)")]
        public string NameAr { get; set; }

        [Display(Name = "Sort Key")]
        public int SortKey { get; set; }

        public List<Doctor> Doctors { get; set; } = new();
    }
}
