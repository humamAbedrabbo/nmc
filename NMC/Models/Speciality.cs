using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NMC.Models
{
    [Index(nameof(Name), IsUnique = true)]
    public class Speciality 
    {
        public int Id { get; set; }
        
        [Required, StringLength(50, MinimumLength = 1)]
        [Display(Name = "Speciality (English)")]
        public string Name { get; set; }

        [Required, StringLength(50, MinimumLength = 1)]
        [Display(Name = "Speciality (Arabic)")]
        public string NameAr { get; set; }

        public string this[string lang] => lang == "ar" ? NameAr : Name;

        [Display(Name = "Doctors")] 
        public List<Doctor> Doctors { get; set; } = new();
    }

}
